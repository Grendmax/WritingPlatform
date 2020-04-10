using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingPlatform.BusinessLayer.BInterfaces
{
    public interface IAuthen
    {
        bool CheckLogin(string login, string password);

        int GetUserId(string login, string password);
        bool GetUserStatus(string login, string password);
        bool Logout();
    }
}
