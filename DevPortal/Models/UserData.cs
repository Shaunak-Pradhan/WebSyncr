using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevPortal.Models
{
    public class UserData
    {
        public string Login { set; get; }
        public string Password { set; get; }
        public IEnumerable<UserRole> Role { set; get; }
        public int CompanyID { set; get; }
        public string Email { get; set; }
    }
}