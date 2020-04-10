using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingPlatform.BusinessLayer.BusinessObjects;

namespace WritingPlatform.BusinessLayer.BInterfaces
{
    public interface IRatings
    {
        void Create(RatingsBO rating);
        void Update(RatingsBO rating);
        RatingsBO GetRating(int id);
        IEnumerable<RatingsBO> GetRatings();
        void DeleteRating(int id);
        void Dispose();
    }
}
