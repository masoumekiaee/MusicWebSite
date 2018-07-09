using MusicWebSite.Areas.Administrator.Models.ViewModels;
using MusicWebSite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWebSite.Areas.Administrator.Repository
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

        #region methods
        public List<MusicIndexViewModels> GetMusicsIndex()
        {
            List<MusicIndexViewModels> lst = (from rows in context.Musics
                                              orderby rows.TimeAdded descending
                                              select new MusicIndexViewModels
                                              {
                                                  FarsiName = rows.FarsiName,
                                                  Id = rows.Id,
                                                  SingerFarsiName = rows.Singer.FarsiName,
                                                  Title = rows.Title
                                              }).ToList();

            return lst;
        }


        public List<SelectListItem> GetSelectListSinger()
        {
            List<SelectListItem> lst = (from rows in context.Singers
                                        select new SelectListItem
                                        {
                                            Text = rows.FarsiName,
                                            Value = rows.Id.ToString()
                                        }).ToList();
            return lst;
        }
        public List<SelectListItem> GetSelectListMusicCategory()
        {
            List<SelectListItem> lst = (from rows in context.MusicCategories
                                        select new SelectListItem
                                        {
                                            Text = rows.FarsiName,
                                            Value = rows.Id.ToString()
                                        }).ToList();
            return lst;
        }


        public void Insert(MusicUploadViewModels model, string path)
        {
            Music mus = new Music();
            mus.CategoryMusicId_Fk = model.SelectMusicCategory;
            mus.Description = model.Description;
            mus.EngName = model.EngName;
            mus.FarsiName = model.FarsiName;
            mus.Lyrics = model.Lyrics;
            mus.SingerId_Fk = model.SelectSinger;
            mus.TimeAdded = DateTime.Now;
            mus.Title = model.Title;

            string fileMusicName = model.UpMusicFile.FileName;
            fileMusicName = fileMusicName.Replace(" ", "");

            string musicPath = path + @"\Music\" + fileMusicName;

            if (System.IO.File.Exists(musicPath))
            {
                int number = 1;
                string exmusic = Path.GetExtension(musicPath);
                string mnmusic = Path.GetFileNameWithoutExtension(musicPath);
                while (System.IO.File.Exists(musicPath))
                {
                    musicPath = musicPath.Replace("_" + number, "");
                    musicPath = path + @"\Music\" + mnmusic + "_" + number + exmusic;
                    number++;
                }
            }

            mus.FileName = Path.GetFileName(musicPath);

            model.UpMusicFile.SaveAs(musicPath);

            string fileMusicPictureName = model.UpMusicPictureFile.FileName;
            fileMusicPictureName = fileMusicPictureName.Replace(" ", "");

            string musicPicturePath = path + @"\MusicPicture\" + fileMusicPictureName;


            if (System.IO.File.Exists(musicPicturePath))
            {
                int number = 1;
                string exmusic = Path.GetExtension(musicPicturePath);
                string mnmusic = Path.GetFileNameWithoutExtension(musicPicturePath);
                while (System.IO.File.Exists(musicPicturePath))
                {
                    musicPicturePath = musicPicturePath.Replace("_" + number, "");
                    musicPicturePath = path + @"\MusicPicture\" + mnmusic + "_" + number + exmusic;
                    number++;
                }
            }

            model.UpMusicPictureFile.SaveAs(musicPicturePath);

            mus.PictureName = Path.GetFileName(musicPicturePath);

            context.Musics.Add(mus);
            context.SaveChanges();

        }


        public MusicUploadViewModels GetMusicUploadByMusicId(int id)
        {
            MusicUploadViewModels mv = (from row in context.Musics
                                        where row.Id == id
                                        select new MusicUploadViewModels
                                        {
                                            Id = row.Id,
                                            Description = row.Description,
                                            EngName = row.EngName,
                                            FarsiName = row.FarsiName,
                                            FileName = row.FileName,
                                            Lyrics = row.Lyrics,
                                            PictureName = row.PictureName,
                                            SelectMusicCategory = row.CategoryMusicId_Fk,
                                            SelectSinger = row.SingerId_Fk,
                                            Title = row.Title
                                        }).FirstOrDefault();

            mv.MusicCategoryList = GetSelectListMusicCategory();
            mv.SingerList = GetSelectListSinger();


            return mv;
        }


        public void EditMusic(MusicUploadViewModels model)
        {
            Music mus = (from row in context.Musics
                         where row.Id == model.Id
                         select row).FirstOrDefault();

            if (mus != null)
            {
                mus.CategoryMusicId_Fk = model.SelectMusicCategory;
                mus.Description = model.Description;
                mus.EngName = model.EngName;
                mus.FarsiName = model.FarsiName;
                mus.Lyrics = model.Lyrics;
                mus.SingerId_Fk = model.SelectSinger;
                mus.TimeAdded = DateTime.Now;
                mus.Title = model.Title;
            }

            context.SaveChanges();
        }

        public void DeleteMusic(int id)
        {
            Music mus = context.Musics.FirstOrDefault(s => s.Id == id);
            context.Musics.Remove(mus);
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