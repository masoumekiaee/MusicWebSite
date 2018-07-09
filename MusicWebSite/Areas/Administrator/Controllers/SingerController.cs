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
    public class SingerController : Controller
    {

        private ISingerRepository repository;
        public SingerController()
        {
            this.repository = new Repository.SingerRepository(new ApplicationDbContext());
        }

        // GET: Administrator/Singer
        public ActionResult Index()
        {
            List<Singer> lst = repository.GetSingerList();

            return View(lst);
        }

        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Singer model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);
                return RedirectToAction("Index", "Singer");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            Singer singer = repository.GetSingerById(id);
            return View(singer);
        }

        [HttpPost]
        public ActionResult Edit(Singer model)
        {
            if (ModelState.IsValid)
            {
                repository.EditSinger(model);
            }
            return RedirectToAction("Index", "Singer");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                repository.DeleteSinger(id);
            }
            return RedirectToAction("Index", "Singer");
        }
    }
}