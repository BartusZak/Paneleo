using AutoMapper;
using Paneleo.API.Dtos;
using Paneleo.API.Models;

namespace Paneleo.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
        }

    }
}