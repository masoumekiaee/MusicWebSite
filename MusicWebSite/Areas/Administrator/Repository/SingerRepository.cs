using MusicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWebSite.Areas.Administrator.Repository
{
    public class SingerRepository : ISingerRepository, IDisposable
    {
        #region context and constructor
        private ApplicationDbContext context;

        public SingerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        #endregion context and constructor

        #region methods
        public void Insert(Singer singer)
        {
            Singer s = new Singer()
            {
                Description = singer.Description,
                EngName = singer.EngName,
                FarsiName = singer.FarsiName
            };

            context.Singers.Add(s);
            context.SaveChanges();
        }

        public List<Singer> GetSingerList()
        {
            return context.Singers.ToList();
        }

        public Singer GetSingerById(int id)
        {
            return context.Singers.FirstOrDefault(s => s.Id == id);
        }


        public void EditSinger(Singer singer)
        {
            Singer sin = context.Singers.FirstOrDefault(s => s.Id == singer.Id);
            sin.Description = singer.Description;
            sin.EngName = singer.EngName;
            sin.FarsiName = singer.FarsiName;

            context.SaveChanges();
        }

        public void DeleteSinger(int id)
        {
            Singer sin = context.Singers.FirstOrDefault(s => s.Id == id);
            context.Singers.Remove(sin);
            context.SaveChanges();
        }
        #endregion methods


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