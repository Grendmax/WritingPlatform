using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WritingPlatform.BusinessLayer.BInterfaces;
using WritingPlatform.DataLayer.UnitOfWork;

namespace WritingPlatform.BusinessLayer.BusinessObjects
{
    public class UserAuthentication : IAuthen
    {
        private IUnitOfWork Database { get; set; }

        public UserAuthentication(IUnitOfWork uow)
        {
            Database = uow;
        }

        public bool CheckLogin(string login, string password)
        {
            
            return Database.UsersUowRepository.GetAll().SingleOrDefault(c => c.Login == login && c.Password == password) != null;
        }

        public int GetUserId(string login, string password) {

            if (Database.UsersUowRepository.GetAll().SingleOrDefault(c => c.Login == login && c.Password == password) != null)
            {
               return Database.UsersUowRepository.GetAll().SingleOrDefault(c => c.Login == login && c.Password == password).Id;
            }

            return 0;
        }



        public bool Logout()
        {
            return true;
        }

        public bool GetUserStatus(string login, string password)
        {
           return Database.UsersUowRepository.GetAll().SingleOrDefault(c => c.Login == login && c.Password == password).IsDelete;             
        }
    }
}
