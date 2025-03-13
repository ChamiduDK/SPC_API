using AutoMapper;
using SPC_API.DTO;
using SPC_API.Model;

namespace SPC_API.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, DTOSupplierRead>();
            CreateMap<DTOSupplierWrite, Supplier>();
        }
    }
}
