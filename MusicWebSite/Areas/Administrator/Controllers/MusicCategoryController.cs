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
    public class MusicCategoryController : Controller
    {
        // GET: Administrator/MusicCategory
        private IMusicCategoryRepository repository;
        public MusicCategoryController()
        {
            this.repository = new Repository.MusicCategoryRepository(new ApplicationDbContext());
        }

        // GET: Administrator/mc
        public ActionResult Index()
        {
            List<MusicCategory> lst = repository.GetMusicCategoriesList();

            return View(lst);
        }

        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(MusicCategory model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);
                return RedirectToAction("Index", "MusicCategory");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            MusicCategory mc = repository.GetMusicCategoryById(id);
            return View(mc);
        }

        [HttpPost]
        public ActionResult Edit(MusicCategory model)
        {
            if (ModelState.IsValid)
            {
                repository.EditMusicCategory(model);
            }
            return RedirectToAction("Index", "MusicCategory");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                repository.DeleteMusicCategory(id);
            }
            return RedirectToAction("Index", "MusicCategory");
        }
    }
}