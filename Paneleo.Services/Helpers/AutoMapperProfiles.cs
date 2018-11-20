using AutoMapper;
using Paneleo.Models;
using Paneleo.Models.BindingModel;
using Paneleo.Models.Dtos;
using Paneleo.Models.Model;

namespace Paneleo.Services.Helpers
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