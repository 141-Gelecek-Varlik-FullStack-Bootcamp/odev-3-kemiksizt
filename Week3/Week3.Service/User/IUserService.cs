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
        public General<UserViewModel> Login(UserViewModel user);
        public General<UserViewModel> GetUsers();
        public General<UserViewModel> Insert(UserViewModel newUser);
        public General<UserViewModel> Update(int id, UserViewModel user);
        public General<UserViewModel> Delete(int id);
    }
}
