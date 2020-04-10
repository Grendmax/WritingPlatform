using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WritingPlatform.Models
{
    public class WorksViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата публикации")]
        public DateTime DateOfPublication { get; set; }

        [Required]
        public string Content { get; set; }
        [Display(Name = "Жанр")]
        public int GenreId { get; set; }
        [Display(Name = "Автор")]
        public int UserId { get; set; }

    }
}