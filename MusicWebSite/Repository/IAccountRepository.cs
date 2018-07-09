using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWebSite.Repository
{
    public interface IAccountRepository
    {
        void InsertUserInfo(Models.UserInfo userInfo);

        void InsertRole(string IdentityUserId, string RoleId);
    }
}
