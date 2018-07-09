using MusicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWebSite.Areas.Administrator.Repository
{
    public interface IMusicCategoryRepository
    {
        void Insert(MusicCategory musicCategory);
        List<MusicCategory> GetMusicCategoriesList();

        MusicCategory GetMusicCategoryById(int id);

        void EditMusicCategory(MusicCategory singer);

        void DeleteMusicCategory(int id);
    }
}
