using MusicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWebSite.Repository
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


        public List<MusicThumbnails> GetNewestMusic(int takeCount)
        {
            List<MusicThumbnails> lst = (from rows in context.Musics
                                         select new MusicThumbnails
                                         {
                                             EngName = rows.EngName,
                                             FarsiName = rows.FarsiName,
                                             Id = rows.Id,
                                             PictureName = rows.PictureName,
                                             SingerFarsiName = rows.Singer.FarsiName,
                                             TimeAdded = rows.TimeAdded,
                                             Title = rows.Title
                                         }).OrderByDescending(s => s.TimeAdded).Skip(0).Take(takeCount).ToList();
            return lst;
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