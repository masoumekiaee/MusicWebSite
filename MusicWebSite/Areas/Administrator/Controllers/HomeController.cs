using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWebSite.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Administrator")]
        // GET: Administrator/Home
        public ActionResult Index()
        {

            return View();
        }
    }
}