using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WritingPlatform.Models
{
    public class UsersViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Имя пользователя")]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }

        public string Email { get; set; }
        public bool IsDelete { get; set; }
    }
}