using AutoMapper;
using SPC_API.DTO;
using SPC_API.Model;

namespace SPC_API.Profiles
{
        public class PharmacyProfile: Profile
        {
            public PharmacyProfile()
        {
            CreateMap<Pharmacy, DTOPharmacyRead>();
            CreateMap<DTOPharmacyWrite, Pharmacy>();
        }
   }
}

