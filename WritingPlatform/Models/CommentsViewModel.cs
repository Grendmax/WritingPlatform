using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WritingPlatform.Models
{
    public class CommentsViewModel
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Comment { get; set; }

        public int? UserId { get; set; }

        public int? WorkId { get; set; }
    }
}