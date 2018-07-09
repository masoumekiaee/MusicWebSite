using MusicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWebSite.Repository
{
    public class CommentRepository : ICommentRepository, IDisposable
    {
        #region context and constructor
        private ApplicationDbContext context;

        public CommentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        #endregion context and constructor

        public int GetUserInfoId(string email)
        {
            return context.UserInfos.FirstOrDefault(u => u.Email.ToLower() == email).Id;
        }

        public object SendComment(int userInfoId, string text, int musicId)
        {
            UserInfo user = context.UserInfos.Where(u => u.Id == userInfoId).FirstOrDefault();

            Comment com = new Comment();

            com.MusicId_Fk = musicId;
            com.Text = text;
            com.TimeAdded = DateTime.Now;
            com.UserInfoId_Fk = userInfoId;

            context.Comments.Add(com);
            context.SaveChanges();

            object obj = new
            {
                Text = com.Text,
                FullName = user.FullName,
                Inserted  = true,
                Success = true
            };
            return obj;

        
        }


        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion Dispose
    }
}