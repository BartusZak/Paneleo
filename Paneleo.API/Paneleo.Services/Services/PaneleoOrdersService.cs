using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paneleo.Data.Repository.Interfaces;
using Paneleo.Models.BindingModel;
using Paneleo.Models.Model;
using Paneleo.Models.ModelDto;
using Paneleo.Services.Interfaces;

namespace Paneleo.Services.Services
{
    public class PaneleoOrdersService : IPaneleoOrdersService
    {
        private readonly IRepository<Order> _orderRepository;
        public readonly IMapper _mapper;

        public PaneleoOrdersService(IRepository<Order> orderRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this._orderRepository = orderRepository;
        }

        public async Task<Response<object>> AddAsync(AddOrderBindingModel bindingModel)
        {
            var response = await ValidateAddingViewModel(bindingModel);
            if (response.ErrorOccurred)
            {
                return response;
            }
            var order = _mapper.Map<Order>(bindingModel);

            bool addSucceed = await _orderRepository.AddAsync(order);
            if (!addSucceed)
            {
                response.AddError(Key.Order, Error.OrderAddError);
            }

            return response;
        }

        public async Task<Response<object>> UpdateAsync(UpdateOrderBindingModel bindingModel)
        {
            var response = await ValidateUpdateViewModel(bindingModel);
            if (response.ErrorOccurred)
            {
                return response;
            }

            var product = await _orderRepository.GetByAsync(x => x.Id == bindingModel.Id);

            _orderRepository.Detach(product);
            var updatedProduct = _mapper.Map<Order>(bindingModel);

            bool updateSucceed = await _orderRepository.UpdateAsync(updatedProduct);
            if (!updateSucceed)
            {
                response.AddError(Key.Order, Error.OrderUpdateError);
            }

            return response;
        }

        public async Task<Response<object>> DeleteAsync(int OrderId)
        {
            var response = new Response<object>();
            var Order = await _orderRepository.GetByAsync(x => x.Id == OrderId);
            if (Order == null)
            {
                response.AddError(Key.Order, Error.OrderNotExist);
                return response;
            }

            bool deleteSucceed = await _orderRepository.RemoveAsync(Order);
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

            response.SuccessResult = GetByParameters(searchParamsValidated.SuccessResult);

            return response;
        }

        public SearchResults<OrderDetailedDto> GetByParameters(SearchParamsBindingModel searchParams)
        {
            var orders = _orderRepository.GetAllAsync();
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

        private async Task<Response<object>> ValidateAddingViewModel(AddOrderBindingModel viewModel)
        {
            var response = new Response<object>();
            bool orderExists = await _orderRepository.ExistAsync(x =>
               x.Id == viewModel.Id);
            if (orderExists)
            {
                response.AddError(Key.Order, Error.OrderAlreadyExists);
                return response;
            }
            return response;
        }

        private async Task<Response<object>> ValidateUpdateViewModel(UpdateOrderBindingModel bindingModel)
        {
            var response = new Response<object>();
            bool orderExists = await _orderRepository.ExistAsync(x => x.Id == bindingModel.Id);
            if (!orderExists)
            {
                response.AddError(Key.Order, Error.OrderNotExist);
            }

            return response;
        }
    }

}