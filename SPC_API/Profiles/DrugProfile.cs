using AutoMapper;
using SPC_API.DTO;
using SPC_API.Model;

namespace SPC_API.Profiles
{
    public class DrugProfile : Profile
    {
        public DrugProfile() 
        {
            CreateMap<Drug, DTODrugRead>();
            CreateMap<DTODrugWrite, Drug>();
        }
    }
}
