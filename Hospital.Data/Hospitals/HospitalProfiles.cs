using AutoMapper;

namespace Hospital.Data.Hospitals
{
    public class HospitalDaoProfile : Profile
    {
        public HospitalDaoProfile()
        {
            CreateMap<Core.Hospitals.Hospital, Hospital>()
                .ForMember(dest => dest.Id, memberOptions: opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Count, memberOptions: opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.Address, memberOptions: opt => opt.MapFrom(src => src.Address))
                .ReverseMap();
        }

    }
   
}