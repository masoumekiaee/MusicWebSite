using Microsoft.AspNet.Identity;
using MusicWebSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWebSite.Controllers
{
    public class CommentController : Controller
    {
        private ICommentRepository repository;
        public CommentController()
        {
            this.repository = new Repository.CommentRepository(new Models.ApplicationDbContext());
        }

        [HttpPost]
        // GET: Comment
        public ActionResult Send(string text, int musicId)
        {
            string email = User.Identity.GetUserName().ToLower();
            int userInfoId = repository.GetUserInfoId(email);

            object obj = repository.SendComment(userInfoId, text, musicId);

            return Json(obj);
        }
    }
}