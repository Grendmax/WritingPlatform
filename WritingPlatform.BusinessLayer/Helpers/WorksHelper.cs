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
    public class WorksHelper : IWorks
    {
        IUnitOfWork Database { get; set; }
        public WorksHelper(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(WorksBO work)
        {
            Works newWork = new Works() { Name=work.Name,DateOfPublication=work.DateOfPublication.Date,Content=work.Content,GenreId=work.GenreId,UserId=work.UserId};
            Database.WorksUowRepository.Create(newWork);
            Database.Save();
        }

        public void Update(WorksBO work)
        {
            Works newWork = AutoMapper<WorksBO, Works>.Map(work);
            Database.WorksUowRepository.Update(newWork);
            Database.Save();
        }

        public WorksBO GetWork(int id)
        {
            if (id != 0)
            {
                return AutoMapper<Works, WorksBO>.Map(Database.WorksUowRepository.Get, id);
            }
            return new WorksBO();
        }

        public IEnumerable<WorksBO> GetWorks()
        {
            return AutoMapper<IEnumerable<Works>, List<WorksBO>>.Map(Database.WorksUowRepository.GetAll());
        }

        public void DeleteWork(int id)
        {
            Database.WorksUowRepository.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
