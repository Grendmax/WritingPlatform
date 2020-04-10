using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingPlatform.DataLayer.Entities;
using WritingPlatform.DataLayer.Repository;

namespace WritingPlatform.DataLayer.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private Model1 db;
        private bool disposed = false;

        Repository<Users> _usersRoomsUowRepository;
        Repository<Comments> _commentsLogosUowRepository;
        Repository<Genres> _genresUowRepository;
        Repository<Works> _worksUowRepository;
        Repository<Ratings> _ratingsUowRepository;

        public UnitOfWork(string connection)
        {
            db = new Model1(connection);
        }

        public Repository<Comments> CommentsUowRepository
        {
            get
            {
                if (this._commentsLogosUowRepository == null)
                    _commentsLogosUowRepository = new Repository<Comments>(db);
                return _commentsLogosUowRepository;
            }
        }

        public Repository<Genres> GenresUowRepository
        {
            get
            {
                if (this._genresUowRepository == null)
                    _genresUowRepository = new Repository<Genres>(db);
                return _genresUowRepository;
            }
        }

        public Repository<Ratings> RatingsUowRepository
        {
            get
            {
                if (this._ratingsUowRepository == null)
                    _ratingsUowRepository = new Repository<Ratings>(db);
                return _ratingsUowRepository;
            }
        }

        public Repository<Users> UsersUowRepository
        {
            get
            {
                if (this._usersRoomsUowRepository == null)
                    _usersRoomsUowRepository = new Repository<Users>(db);
                return _usersRoomsUowRepository;
            }
        }

        public Repository<Works> WorksUowRepository
        {
            get
            {
                if (this._worksUowRepository == null)
                    _worksUowRepository = new Repository<Works>(db);
                return _worksUowRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
