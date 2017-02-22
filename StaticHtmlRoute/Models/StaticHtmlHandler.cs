using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Routing;
using System.Web.SessionState;
using StaticHtmlRoute.Common;

namespace StaticHtmlRoute.Models
{
    public class StaticHtmlHandler : IHttpHandler, IReadOnlySessionState//IRequiresSessionState
    {
        private RequestContext _currentContext;
        public void InitStaticHtmlHandler(RequestContext context)
        {
            _currentContext = context;
        }

        public void ProcessRequest(HttpContext context)
        {
            ProcessRequest(_currentContext);
        }

        private void ProcessRequest(RequestContext requestContext)
        {
            var url = string.Empty;
            var path = requestContext.HttpContext.Server.MapPath("~/StaticHtml/");
            var filename = requestContext.RouteData.Values["filename"].ToString();
            var errorname = "error.html";
            if (filename.ToLower() != errorname && requestContext.HttpContext.Session != null)
            {
                var canAccessStaticHtml = requestContext.HttpContext.Session[SessionName.GobalSession_CanAccessStaticHtml];
                if (canAccessStaticHtml != null)
                {
                    var canAccess = Convert.ToBoolean(canAccessStaticHtml);
                    if (canAccess)
                    {
                        url = path + filename;
                    }
                }
            }
            if (string.IsNullOrEmpty(url))
            {
                url = path + errorname;
            }
            var response = requestContext.HttpContext.Response;
            using (StreamReader sr = new StreamReader(url))
            {
                var content = sr.ReadToEnd();
                response.Write(content);
            }
            response.End();
        }

        public bool IsReusable { get { return false; } }
    }
}