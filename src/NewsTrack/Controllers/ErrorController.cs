using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsTrack.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        public ActionResult BadRequest()
        {
            return View();
        }

        public ActionResult Forbidden()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PageNotFound()
        {
            return View();
        }

        public ActionResult ServerError()
        {
            return View();
        }

        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}