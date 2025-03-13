using AutoMapper;
using SPC_API.DTO;
using SPC_API.Model;

namespace SPC_API.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, DTOOrderRead>();
            CreateMap<DTODrugWrite, Order>(); 
        }
    }
}
