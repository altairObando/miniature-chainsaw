using AutoMapper;

namespace BL.Mapper
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper() 
        {
            CreateMap<DAL.Contacts.Contact, DTO.Contacts.ContactDto>()
                .ForMember(dto => dto.Addresses, con => con.MapFrom(i => i.Addresses))
                .ReverseMap();
            CreateMap<DAL.Contacts.Address, DTO.Contacts.AddressDto>()
                .ReverseMap();
                
        }
    }
}
