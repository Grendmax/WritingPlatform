using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingPlatform.BusinessLayer.BusinessObjects
{
    public class WorksBO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfPublication { get; set; }

        public string Content { get; set; }

        public int GenreId { get; set; }

        public int UserId { get; set; }
    }
}
