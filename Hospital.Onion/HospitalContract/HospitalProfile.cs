using System;
using AutoMapper;

namespace Hospital.Onion.HospitalContract
{
    public class HospitalProfile : Profile
    {
        public HospitalProfile()
        {
            CreateMap<Core.Hospitals.Hospital, Hospital>()
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count));
        }
    }
}
