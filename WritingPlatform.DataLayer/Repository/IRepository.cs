using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingPlatform.DataLayer.Repository
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        T Get(int? id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
