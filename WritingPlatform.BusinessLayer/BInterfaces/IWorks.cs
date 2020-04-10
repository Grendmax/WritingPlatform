using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingPlatform.BusinessLayer.BusinessObjects;

namespace WritingPlatform.BusinessLayer.BInterfaces
{
    public interface IWorks
    {
        void Create(WorksBO work);
        void Update(WorksBO work);
        WorksBO GetWork(int id);
        IEnumerable<WorksBO> GetWorks();
        void DeleteWork(int id);
        void Dispose();
    }
}
