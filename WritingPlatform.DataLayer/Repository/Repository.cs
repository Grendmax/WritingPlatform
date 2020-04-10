using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingPlatform.DataLayer.Entities;

namespace WritingPlatform.DataLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private Model1 db;
        private DbSet<T> table = null;

        public Repository(Model1 db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public void Create(T entity)
        {
            table.Add(entity);
        }

        public void Delete(int id)
        {
            T existingEntity = table.Find(id);
            if (existingEntity != null)
                table.Remove(existingEntity);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return table.Where(predicate);
        }

        public T Get(int? id)
        {
            return table.Find(id);
        }
        public T Get(int id)
        {
            return table.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            //db.Entry(entity).State = EntityState.Modified;

            using (var db = new Model1())
            {
                db.Entry(entity).State = EntityState.Modified;

                db.SaveChanges();
            }
        }
    }
}
