using AutoMapper;
using SPC_API.DTO;
using SPC_API.Model;

namespace SPC_API.Profiles
{
    public class SpcTenderAdProfile : Profile
    {
        public SpcTenderAdProfile()
        {
            CreateMap<SpcTenderAd, DTOSpcTenderAdRead>();
            CreateMap<DTOSpcTenderAdWrite, SpcTenderAd>();
        }
    }
}
