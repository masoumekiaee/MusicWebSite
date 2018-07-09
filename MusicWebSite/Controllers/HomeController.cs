using MusicWebSite.Models;
using MusicWebSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWebSite.Controllers
{
    public class HomeController : Controller
    {
        private IHomeRepository repository;
        public HomeController()
        {
            this.repository = new Repository.HomeRepository(new Models.ApplicationDbContext());
        }
        // GET: Music
        public ActionResult Index()
        {
            List<MusicThumbnails> lst = repository.GetNewestMusic(8);
            return View(lst);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}