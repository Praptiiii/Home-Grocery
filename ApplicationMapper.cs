using AutoMapper;
using HomeGrocery.BLL.DTO;
using HomeGrocery.DAL.Models;

namespace HomeGrocery.Infrastructure.Mapper
{
    public class ApplicationMapper :Profile
    {
        public ApplicationMapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();


        }
    }
}
