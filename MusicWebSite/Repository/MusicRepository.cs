using MusicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWebSite.Repository
{
    public class MusicRepository : IMusicRepository, IDisposable
    {

        #region context and constructor
        private ApplicationDbContext context;

        public MusicRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        #endregion context and constructor


        public MusicShow GetShowMusicByMusicId(int id)
        {
            MusicShow lst = (from row in context.Musics
                             where row.Id == id
                             select new MusicShow
                             {
                                 EngName = row.EngName,
                                 FarsiName = row.FarsiName,
                                 Id = row.Id,
                                 PictureName = row.PictureName,
                                 FileName = row.FileName,
                                 SingerFarsiName = row.Singer.FarsiName,
                                 TimeAdded = row.TimeAdded,
                                 Title = row.Title,
                                 Description = row.Description,
                                 Lyrics = row.Lyrics,
                                 Comments = row.Comments.ToList()
                             }).FirstOrDefault();

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