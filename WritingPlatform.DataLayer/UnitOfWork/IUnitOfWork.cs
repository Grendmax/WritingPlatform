using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingPlatform.DataLayer.Entities;
using WritingPlatform.DataLayer.Repository;

namespace WritingPlatform.DataLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<Users> UsersUowRepository { get; }
        Repository<Comments> CommentsUowRepository { get; }
        Repository<Genres> GenresUowRepository { get; }
        Repository<Works> WorksUowRepository { get; }
        Repository<Ratings> RatingsUowRepository { get; }
        void Save();
    }
}
