using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3.Model;
using Week3.Model.User;

namespace Week3.Service.User
{
    public interface IUserService
    {

        //UserService içerisinde kullanılacak işlemleri bu interface içerisinde tanımladım.

        public General<UserLoginViewModel> Login(UserLoginViewModel user);
        public General<UserViewModel> GetUsers();
        public General<UserViewModel> InsertUser(UserViewModel newUser);
        public General<UserViewModel> UpdateUser(int id, UserViewModel user);
        // public General<UserViewModel> DeleteUser(int id);
        public General<UserViewModel> DeleteUser(int id, UserViewModel user);
        
    }
}
