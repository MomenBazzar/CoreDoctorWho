using AutoMapper;
using DoctorWho.Db.Entities;
using DoctorWho.Db.Models;


namespace DoctorWho.Db.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>();
        }
    }
}
