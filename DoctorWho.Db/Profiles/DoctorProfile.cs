using AutoMapper;
using CourseLibrary.Db.Helpers;
using DoctorWho.Db.Entities;
using DoctorWho.Db.Models;


namespace DoctorWho.Db.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorDto>()
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.BirthDate.GetCurrentAge()));

            CreateMap<DoctorUpdateDto, Doctor>();
        }
    }
}
