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
    public class GenresHelper : IGenres
    {
        IUnitOfWork Database { get; set; }
        public GenresHelper(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(GenresBO genre)
        {
            Genres newGenre = new Genres() { Name=genre.Name };
            Database.GenresUowRepository.Create(newGenre);
            Database.Save();
        }

        public void Update(GenresBO genre)
        {
            Genres newGenre = AutoMapper<GenresBO, Genres>.Map(genre);
            Database.GenresUowRepository.Update(newGenre);
            Database.Save();
        }

        public GenresBO GetGenre(int id)
        {
            if (id != 0)
            {
                return AutoMapper<Genres, GenresBO>.Map(Database.GenresUowRepository.Get, id);
            }
            return new GenresBO();
        }

        public IEnumerable<GenresBO> GetGenres()
        {
            return AutoMapper<IEnumerable<Genres>, List<GenresBO>>.Map(Database.GenresUowRepository.GetAll);
        }

        public void DeleteGenre(int id)
        {
            Database.GenresUowRepository.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
