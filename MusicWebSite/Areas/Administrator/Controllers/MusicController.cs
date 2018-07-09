using MusicWebSite.Areas.Administrator.Models.ViewModels;
using MusicWebSite.Areas.Administrator.Repository;
using MusicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWebSite.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MusicController : Controller
    {
        private IMusicRepository repository;
        public MusicController()
        {
            this.repository = new Repository.MusicRepository(new ApplicationDbContext());
        }
        // GET: Administrator/Music
        public ActionResult Index()
        {
            List<MusicIndexViewModels> lst = repository.GetMusicsIndex();
            return View(lst);
        }

        public ActionResult Insert()
        {
            MusicUploadViewModels mu = new MusicUploadViewModels();
            mu.SingerList = repository.GetSelectListSinger();
            mu.MusicCategoryList = repository.GetSelectListMusicCategory();

            return View(mu);
        }

        [HttpPost]
        public ActionResult Insert(MusicUploadViewModels model)
        {

            if (ModelState.IsValid)
            {
                string path = Server.MapPath("~/Content/Uploads/");

                repository.Insert(model, path);

                return RedirectToAction("Index", "Music");
            }
            else
            {
                MusicUploadViewModels mu = new MusicUploadViewModels();
                mu.SingerList = repository.GetSelectListSinger();
                mu.MusicCategoryList = repository.GetSelectListMusicCategory();
                return View(mu);
            }



        }

        public ActionResult Edit(int id)
        {
            MusicUploadViewModels mu = repository.GetMusicUploadByMusicId(id);
            return View(mu);
        }

        [HttpPost]
        public ActionResult Edit(MusicUploadViewModels model)
        {
            if (ModelState.IsValid)
            {
                repository.EditMusic(model);

            }
            return RedirectToAction("Index", "Music");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                repository.DeleteMusic(id);
            }
            return RedirectToAction("Index", "Music");
        }
    }
}