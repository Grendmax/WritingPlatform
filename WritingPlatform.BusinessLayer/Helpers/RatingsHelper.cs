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
    public class RatingsHelper : IRatings
    {
        IUnitOfWork Database { get; set; }
        public RatingsHelper(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(RatingsBO rating)
        {
            Ratings newRating = new Ratings() { Rank=rating.Rank,UserId=rating.UserId,WorkId=rating.WorkId };
            Database.RatingsUowRepository.Create(newRating);
            Database.Save();
        }

        public void Update(RatingsBO rating)
        {
            Ratings editRating = AutoMapper<RatingsBO, Ratings>.Map(rating);
            Database.RatingsUowRepository.Update(editRating);
            Database.Save();
        }

        public RatingsBO GetRating(int id)
        {
            if (id != 0)
            {
                return AutoMapper<Ratings, RatingsBO>.Map(Database.RatingsUowRepository.Get, id);
            }
            return new RatingsBO();
        }

        public IEnumerable<RatingsBO> GetRatings()
        {
            return AutoMapper<IEnumerable<Ratings>, List<RatingsBO>>.Map(Database.RatingsUowRepository.GetAll);
        }

        public void DeleteRating(int id)
        {
            Database.RatingsUowRepository.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
