using AutoMapper;
using Week3.Model.User;
using Week3.DB.Entities;
using Week3.Model.Product;
using Week3.Model.Category;

namespace Week3.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();

            CreateMap<UserLoginViewModel, User>();
            CreateMap<User, UserLoginViewModel>();


            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, ProductViewModel>();


            CreateMap<CategoryViewModel, Category>();
            CreateMap<Category, CategoryViewModel>();


        }
    }
}
