using AutoMapper;
using Paneleo.API.Dtos;
using Paneleo.API.Models;
using Paneleo.API.Models.Model;
using Paneleo.API.Models.ModelDto;
using Paneleo.API.Services.Interfaces;

namespace Paneleo.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<User, UserForDetailsDto>();
            CreateMap<AddProductBindingModel, Product>();
            CreateMap<UpdateProductBindingModel, Product>();


        }

    }
}