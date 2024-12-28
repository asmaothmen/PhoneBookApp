using AutoMapper;
using PhoneBookApi.DTOs;

namespace PhoneBookApi.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();
        }
    }
}
