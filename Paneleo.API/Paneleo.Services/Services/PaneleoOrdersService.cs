using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paneleo.Data.Repository.Interfaces;
using Paneleo.Models.BindingModel;
using Paneleo.Models.BindingModel.Order;
using Paneleo.Models.BindingModel.Product;
using Paneleo.Models.Model;
using Paneleo.Models.Model.Contractor;
using Paneleo.Models.Model.Order;
using Paneleo.Models.Model.Product;
using Paneleo.Models.ModelDto;
using Paneleo.Models.ModelDto.Order;
using Paneleo.Models.ModelDto.Product;
using Paneleo.Services.Interfaces;

namespace Paneleo.Services.Services
{
    public class PaneleoOrdersService : IPaneleoOrdersService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Contractor> _contractorRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        private readonly IPaneleoContractorsService _contractorService;
        private readonly IPaneleoProductsService _productsService;

        public PaneleoOrdersService(IRepository<Order> orderRepository, IRepository<Contractor> contractorRepository, IRepository<Product> productRepository, IPaneleoContractorsService contractorService, IPaneleoProductsService productsService,IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _contractorRepository = contractorRepository;
            _productRepository = productRepository;

            _contractorService = contractorService;
            _productsService = productsService;

        }

        public async Task<Response<object>> AddAsync(AddOrderBindingModel bindingModel)
        {
            var response = new Response<object>();
            return response;
        }





        public async Task<Response<object>> UpdateAsync(UpdateOrderBindingModel bindingModel)
        {
            var response = await ValidateUpdateViewModel(bindingModel);
            if (response.ErrorOccurred)
            {
                return response;
            }

            var product = await _orderRepository.GetByAsync(x => x.OrderId == bindingModel.Id);

            _orderRepository.Detach(product);
            var updatedProduct = _mapper.Map<Order>(bindingModel);

            bool updateSucceed = await _orderRepository.UpdateAsync(updatedProduct);
            if (!updateSucceed)
            {
                response.AddError(Key.Order, Error.OrderUpdateError);
            }

            return response;
        }

        public async Task<Response<object>> DeleteAsync(int orderId)
        {
            var response = new Response<object>();
            var order = await _orderRepository.GetByAsync(x => x.OrderId == orderId);
            if (order == null)
            {
                response.AddError(Key.Order, Error.OrderNotExist);
                return response;
            }

            bool deleteSucceed = await _orderRepository.RemoveAsync(order);
            if (!deleteSucceed)
            {
                response.AddError(Key.Order, Error.OrderRemoveError);
                return response;
            }
            return response;
        }

        public async Task<Response<SearchResults<OrderDetailedDto>>> GetAllAsync(SearchParamsBindingModel searchParams)
        {
            var response = new Response<SearchResults<OrderDetailedDto>>();

            var searchParamsValidated = SearchParametersValidate(searchParams);

            if (searchParamsValidated.ErrorOccurred)
            {
                response.Errors = searchParamsValidated.Errors;
                return response;
            }

            response.SuccessResult = await GetByParameters(searchParamsValidated.SuccessResult);

            return response;
        }

        public async Task<SearchResults<OrderDetailedDto>> GetByParameters(SearchParamsBindingModel searchParams)
        {
            var orders = await _orderRepository.GetAllAsync();
            var ordersCount = orders.Count();
            var ordersPageCount = (int)Math.Ceiling((decimal)orders.Count() / searchParams.PageLimit);
            orders = orders.Skip(searchParams.PageLimit * (searchParams.PageNumber - 1)).Take(searchParams.PageLimit);


            return new SearchResults<OrderDetailedDto>()
            {
                Results = _mapper.Map<List<OrderDetailedDto>>(orders),
                CurrentPage = searchParams.PageNumber,
                TotalPageCount = ordersPageCount,
                TotalItemsCount = ordersCount
            };
        }

        private Response<SearchParamsBindingModel> SearchParametersValidate(SearchParamsBindingModel searchParams)
        {
            var response = new Response<SearchParamsBindingModel>();
            if (searchParams.PageLimit == 0)
            {
                response.AddError(Key.Order, Error.PageLimit);
            }

            searchParams.PageNumber = Math.Abs(searchParams.PageNumber);
            searchParams.PageLimit = Math.Abs(searchParams.PageLimit);

            response.SuccessResult = searchParams;

            return response;
        }
        
        private async Task<Response<object>> ValidateUpdateViewModel(UpdateOrderBindingModel bindingModel)
        {
            var response = new Response<object>();
            bool orderExists = await _orderRepository.ExistAsync(x => x.OrderId == bindingModel.Id);
            if (!orderExists)
            {
                response.AddError(Key.Order, Error.OrderNotExist);
            }

            return response;
        }
    }

}