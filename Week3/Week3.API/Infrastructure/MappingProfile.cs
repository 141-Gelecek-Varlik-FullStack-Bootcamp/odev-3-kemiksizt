using AutoMapper;
using Week3.Model.User;
using Week3.DB.Entities;


namespace Week3.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();
        }
    }
}
