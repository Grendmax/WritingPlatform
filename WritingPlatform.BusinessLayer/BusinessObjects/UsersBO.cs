using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingPlatform.BusinessLayer.BusinessObjects
{
    public class UsersBO
    {
        public int Id { get; set; }    
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsDelete { get; set; }
    }
}
