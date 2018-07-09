using MusicWebSite.Areas.Administrator.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MusicWebSite.Areas.Administrator.Repository
{
    interface IMusicRepository
    {
        List<MusicIndexViewModels> GetMusicsIndex();
        List<SelectListItem> GetSelectListSinger();
        List<SelectListItem> GetSelectListMusicCategory();
        void Insert(MusicUploadViewModels model, string path);
        MusicUploadViewModels GetMusicUploadByMusicId(int id);
        void EditMusic(MusicUploadViewModels model);
        void DeleteMusic(int id);
    }
}
