using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingPlatform.BusinessLayer.BInterfaces;
using WritingPlatform.BusinessLayer.BusinessObjects;
using WritingPlatform.DataLayer.Entities;
using WritingPlatform.DataLayer.UnitOfWork;

namespace WritingPlatform.BusinessLayer.Helpers
{
    public class UsersHelper : IUsers
    {
        IUnitOfWork Database { get; set; }
        public UsersHelper(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(UsersBO user)
        {
            Users NewUser = new Users() { Login=user.Login,Password=user.Password,Email=user.Email };
            Database.UsersUowRepository.Create(NewUser);
            Database.Save();
        }

        public void Update(UsersBO user)
        {
            Users NewUser = AutoMapper<UsersBO, Users>.Map(user);
            Database.UsersUowRepository.Update(NewUser);
            Database.Save();
        }

        public UsersBO GetUser(int id)
        {
            if (id != 0)
            {
                return AutoMapper<Users, UsersBO>.Map(Database.UsersUowRepository.Get, id);
            }
            return new UsersBO();
        }

        public IEnumerable<UsersBO> GetUsers()
        {
            return AutoMapper<IEnumerable<Users>, List<UsersBO>>.Map(Database.UsersUowRepository.GetAll);
        }

        public void DeleteUser(int id)
        {
            Database.UsersUowRepository.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
