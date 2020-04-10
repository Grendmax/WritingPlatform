using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WritingPlatform.Models
{
    public class InfoModelWithComments
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Comment { get; set; }

        public int? WorkId { get; set; }

        public int Rank { get; set; }

        public bool IsDelete { get; set; }
    }
}