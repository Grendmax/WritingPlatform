using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingPlatform.BusinessLayer.BusinessObjects;

namespace WritingPlatform.BusinessLayer.BInterfaces
{
    public interface IUsers
    {
        void Create(UsersBO user);
        void Update(UsersBO user);
        UsersBO GetUser(int id);
        IEnumerable<UsersBO> GetUsers();
        void DeleteUser(int id);
        void Dispose();
    }
}
