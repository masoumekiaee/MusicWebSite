using Microsoft.AspNet.Identity.EntityFramework;
using MusicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWebSite.Repository
{
    public class AccountRepository : IAccountRepository, IDisposable
    {

        #region context and constructor
        private ApplicationDbContext context;

        public AccountRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        #endregion context and constructor

        public void InsertUserInfo(Models.UserInfo userInfo)
        {
            context.UserInfos.Add(userInfo);
            context.SaveChanges();
        }

        public void InsertRole(string IdentityUserId, string RoleId)
        {
            ApplicationUser user = context.Users.FirstOrDefault(s => s.Id == IdentityUserId);

            var role = context.Roles.FirstOrDefault(s => s.Id == RoleId);

            user.Roles.Add(new IdentityUserRole { RoleId = role.Id });

            context.SaveChanges();

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