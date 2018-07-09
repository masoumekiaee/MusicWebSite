using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWebSite.Repository
{
    public interface ICommentRepository
    {
        int GetUserInfoId(string email);
        object SendComment(int userInfoId, string text, int musicId);
    }
}
