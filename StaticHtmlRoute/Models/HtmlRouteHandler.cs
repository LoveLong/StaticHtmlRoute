using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace StaticHtmlRoute.Models
{
    public class StaticFileRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var htmlHandler = new StaticHtmlHandler();
            htmlHandler.InitStaticHtmlHandler(requestContext);
            return htmlHandler;
        }
    }
}