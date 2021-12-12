using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3.Model.User
{
    // User tablosu üzerinde login işlemi yapmak için oluşurulan model
    public class UserLoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
