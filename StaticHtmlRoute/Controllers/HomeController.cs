using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StaticHtmlRoute.Common;

namespace StaticHtmlRoute.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";
            ViewBag.SessionId = Session.SessionID;
            return View("ActionName");
        }

        public ActionResult AddPower()
        {
            Session[SessionName.GobalSession_CanAccessStaticHtml] = true;
            return GetJsonResult(true, "添加授权成功！");
        }

        public ActionResult CancelPower()
        {
            Session.Remove(SessionName.GobalSession_CanAccessStaticHtml);
            return GetJsonResult(true,"取消授权成功！");
        }

        private JsonResult GetJsonResult(bool status, string message)
        {
            var dic = new Dictionary<string, object> {{"Status", status}, {"Message", message}};
            return Json(dic);
        }
    }
}
