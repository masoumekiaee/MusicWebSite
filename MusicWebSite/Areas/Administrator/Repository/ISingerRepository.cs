using MusicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWebSite.Areas.Administrator.Repository
{
    public interface ISingerRepository
    {
        void Insert(Singer singer);
        List<Singer> GetSingerList();

        Singer GetSingerById(int id);

        void EditSinger(Singer singer);

        void DeleteSinger(int id);
    }
}
