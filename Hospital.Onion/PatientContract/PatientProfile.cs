using System;
using AutoMapper;

namespace Hospital.Onion.PatientContract
{
    public class PatientProfile : Profile

    {
        public PatientProfile()
        {
            CreateMap<Core.Patients.Patient, Patient>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SurName, opt => opt.MapFrom(src => src.SurName))
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday))
               
                
                .ForMember(dest => dest.Sum, opt => opt.MapFrom(src => src.Sum));

        }
    }
}
