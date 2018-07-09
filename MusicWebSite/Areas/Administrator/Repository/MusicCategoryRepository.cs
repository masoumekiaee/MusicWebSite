using MusicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWebSite.Areas.Administrator.Repository
{
    public class MusicCategoryRepository : IMusicCategoryRepository, IDisposable
    {
        #region context and constructor
        private ApplicationDbContext context;

        public MusicCategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        #endregion context and constructor

        #region methods
        public void Insert(MusicCategory musicCategory)
        {
            MusicCategory mc = new MusicCategory()
            {
                Description = musicCategory.Description,
                EngName = musicCategory.EngName,
                FarsiName = musicCategory.FarsiName,
                DisplayOrder = musicCategory.DisplayOrder
            };

            context.MusicCategories.Add(mc);
            context.SaveChanges();
        }

        public List<MusicCategory> GetMusicCategoriesList()
        {
            return context.MusicCategories.OrderBy(s => s.DisplayOrder).ToList();
        }

        public MusicCategory GetMusicCategoryById(int id)
        {
            return context.MusicCategories.FirstOrDefault(s => s.Id == id);
        }


        public void EditMusicCategory(MusicCategory musicCategory)
        {
            MusicCategory mc = context.MusicCategories.FirstOrDefault(s => s.Id == musicCategory.Id);
            mc.Description = musicCategory.Description;
            mc.EngName = musicCategory.EngName;
            mc.FarsiName = musicCategory.FarsiName;
            mc.DisplayOrder = musicCategory.DisplayOrder;

            context.SaveChanges();
        }

        public void DeleteMusicCategory(int id)
        {
            MusicCategory mc = context.MusicCategories.FirstOrDefault(s => s.Id == id);
            context.MusicCategories.Remove(mc);
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