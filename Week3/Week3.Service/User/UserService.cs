using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3.DB.Entities.DataContext;
using Week3.Model;
using Week3.Model.User;

namespace Week3.Service.User
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;

        public UserService(IMapper _mapper)
        {
            mapper = _mapper;
        }
        public General<UserViewModel> Delete(int id)
        {
            var result = new General<UserViewModel>();

            using (var context = new GrootContext())
            {
                var user = context.User.SingleOrDefault(i => i.Id == id);

                if (user is not null)
                {
                    context.User.Remove(user);
                    context.SaveChanges();

                    result.Entity = mapper.Map<UserViewModel>(user);
                    result.IsSuccess = true;
                }
                else
                {
                    result.ExceptionMessage = "Kullanıcı bulunamadı. Bilgileri kontrol ediniz";
                    result.IsSuccess = false;
                }
            }

            return result;
        }

        public General<UserViewModel> GetUsers()
        {
            var result = new General<UserViewModel>();

            using (var context = new GrootContext())
            {
                var data = context.User
                    .Where(x => x.IsActive && !x.IsDeleted)
                    .OrderBy(x => x.Id);

                if (data.Any())
                {
                    result.List = mapper.Map<List<UserViewModel>>(data);
                    result.IsSuccess = true;
                }
                else
                {
                    result.ExceptionMessage = "Sistemde hiçbir kullanıcı yok";
                }
            }

            return result;
        }

        public General<UserViewModel> Insert(UserViewModel newUser)
        {
            var result = new General<UserViewModel>();
            var model = mapper.Map<Week3.DB.Entities.User>(newUser);

            using (var context = new GrootContext())
            {
                model.Idate = DateTime.Now;
                model.IsActive = true;
                context.User.Add(model);
                context.SaveChanges();

                result.Entity = mapper.Map<UserViewModel>(model);
                result.IsSuccess = true;
            }

            return result;
        }

        public General<UserViewModel> Login(UserViewModel user)
        {
            var result = new General<UserViewModel>();
            var model = mapper.Map<Week3.DB.Entities.User>(user);

            using (var context = new GrootContext())
            {
                result.Entity = mapper.Map<UserViewModel>(model);
                result.IsSuccess = context.User.Any(
                    x => x.UserName == user.UserName &&
                                       x.IsActive &&
                                       !x.IsDeleted &&
                                       x.Password == user.Password);
            }

            return result;
        }

        public General<UserViewModel> Update(int id, UserViewModel user)
        {
            var result = new General<UserViewModel>();

            using (var context = new GrootContext())
            {
                var updateUser = context.User.SingleOrDefault(i => i.Id == id);

                if (updateUser is not null)
                {
                    updateUser.Name = user.Name;
                    updateUser.UserName = user.UserName;
                    updateUser.Email = user.Email;
                    updateUser.Password = user.Password;

                    context.SaveChanges();

                    result.Entity = mapper.Map<UserViewModel>(updateUser);
                    result.IsSuccess = true;
                }
                else
                {
                    result.ExceptionMessage = "Aranan kullanıcı bulunamadı. Bilgileri kontrol ediniz.";
                }
            }

            return result;
        }
    }
}
