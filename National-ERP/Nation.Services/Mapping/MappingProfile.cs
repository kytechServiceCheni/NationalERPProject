using AutoMapper;
using National.Repository.Entity;
using National.Services.ServiceRequest;

namespace National.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {          
            CreateMap<UserRequest, User>();
           
        }
    }
}
