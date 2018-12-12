using AutoMapper;
using Paneleo.Models;
using Paneleo.Models.BindingModel;
using Paneleo.Models.BindingModel.Contractor;
using Paneleo.Models.BindingModel.Order;
using Paneleo.Models.Dtos;
using Paneleo.Models.Model;
using Paneleo.Models.Model.Contractor;
using Paneleo.Models.Model.Order;
using Paneleo.Models.Model.Product;
using Paneleo.Models.ModelDto;

namespace Paneleo.Services.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<User, UserForDetailsDto>();

            CreateMap<AddProductBindingModel, Product>().ReverseMap();
            CreateMap<UpdateProductBindingModel, Product>();
            CreateMap<ProductDetailedDto, Product>().ReverseMap();

            CreateMap<AddContractorBindingModel, Contractor>();
            CreateMap<UpdateContractorBindingModel, Contractor>();

            CreateMap<Order, AddOrderBindingModel>().ReverseMap();

            //CreateMap<AddOrderBindingModel, Order>().AfterMap((x,y)=>y.OrderProducts = x.Products);
            //CreateMap<AddOrderBindingModel, Order>().ForMember(dest => dest.Products, opt => opt.MapFrom(src=>src.Products));

            //CreateMap<UpdateOrderBindingModel, Order>();

            //CreateMap<Product, AddProductBindingModel>();
            //CreateMap<Order, AddOrderBindingModel>();



        }

    }
}