using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingPlatform.BusinessLayer.BusinessObjects;

namespace WritingPlatform.BusinessLayer.BInterfaces
{
    public interface IGenres
    {
        void Create(GenresBO genre);
        void Update(GenresBO genre);
        GenresBO GetGenre(int id);
        IEnumerable<GenresBO> GetGenres();
        void DeleteGenre(int id);
        void Dispose();
    }
}
