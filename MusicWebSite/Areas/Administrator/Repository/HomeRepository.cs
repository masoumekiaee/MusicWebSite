using MusicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWebSite.Areas.Administrator.Repository
{
    public class HomeRepository : IHomeRepository, IDisposable
    {
        #region context and constructor
        private ApplicationDbContext context;

        public HomeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        #endregion context and constructor




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