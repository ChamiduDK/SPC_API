using AutoMapper;
using SPC_API.DTO;
using SPC_API.Model;

namespace SPC_API.Profiles
{
    public class TenderProfile : Profile
    {
        public TenderProfile()
        {
            CreateMap<Tender, DTOTenderRead>();
            CreateMap<DTOTenderWrite, Tender>();
        }
    }
}
