using MusicWebSite.Models;
using MusicWebSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWebSite.Controllers
{
    public class MusicController : Controller
    {
        private IMusicRepository repository;
        public MusicController()
        {
            this.repository = new Repository.MusicRepository(new Models.ApplicationDbContext());
        }
        // GET: Music
        public ActionResult Index()
        {
            return Content("404");
        }

        public ActionResult Show(int id)
        {
            MusicShow model = repository.GetShowMusicByMusicId(id);
            return View(model);
        }
    }
}