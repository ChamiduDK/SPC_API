using AutoMapper;
using SPC_API.DTO;
using SPC_API.Model;

namespace SPC_API.Profiles
{
    public class StaffProfile : Profile
    {
        public StaffProfile() 
        {
            CreateMap<Staff, DTOStaffRead>();
            CreateMap<DTOStaffWrite, Staff>();
        }
    }
}
