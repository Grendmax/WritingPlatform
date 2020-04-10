using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingPlatform.BusinessLayer.BusinessObjects
{
    public class RatingsBO
    {
        public int Id { get; set; }

        public int Rank { get; set; }

        public int? WorkId { get; set; }

        public int? UserId { get; set; }

        public bool IsDeleteCheck { get; set; }

    }
}
