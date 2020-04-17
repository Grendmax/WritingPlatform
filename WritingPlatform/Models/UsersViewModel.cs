using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WritingPlatform.Models
{
    public class UsersViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Имя пользователя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Remote("CheckUserName", "Users", HttpMethod = "POST", ErrorMessage = "UserName already in use.")]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        public bool IsDelete { get; set; }
    }
}