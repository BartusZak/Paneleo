using AutoMapper;
using Paneleo.Models;
using Paneleo.Models.BindingModel;
using Paneleo.Models.BindingModel.Contractor;
using Paneleo.Models.BindingModel.Order;
using Paneleo.Models.BindingModel.Product;
using Paneleo.Models.Dtos;
using Paneleo.Models.Model;
using Paneleo.Models.Model.Contractor;
using Paneleo.Models.Model.Order;
using Paneleo.Models.Model.Product;
using Paneleo.Models.ModelDto;
using Paneleo.Models.ModelDto.Product;

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
            CreateMap<Contractor, ContractorDto>();

            CreateMap<Product,AddProductOrderBindingModel>().ReverseMap();
            CreateMap<Product,DetailsProductOrderDto >();

            CreateMap<AddOrderBindingModel, Order>();

                //.ForMember(x => x.ContractorId, x => x.MapFrom(y=>y.ContractorId))
                //.ForMember(x => x.Products, x=>x.MapFrom(y => y.Products));

            CreateMap<AddProductOrderBindingModel, OrderProduct>();

            //CreateMap<AddOrderBindingModel, Order>().AfterMap((x,y)=>y.OrderProducts = x.Products);
            //CreateMap<AddOrderBindingModel, Order>().ForMember(dest => dest.Products, opt => opt.MapFrom(src=>src.Products));

            //CreateMap<UpdateOrderBindingModel, Order>();

            //CreateMap<Product, AddProductBindingModel>();
            //CreateMap<Order, AddOrderBindingModel>();



        }

    }
}