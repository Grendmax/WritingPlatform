using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingPlatform.BusinessLayer.BusinessObjects
{
    public class CommentsBO
    {
        public int Id { get; set; }
        public string Comment { get; set; }

        public int? UserId { get; set; }
        public int? WorkId { get; set; }
    }
}
