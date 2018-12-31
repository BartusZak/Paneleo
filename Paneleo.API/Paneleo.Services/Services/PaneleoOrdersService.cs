using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paneleo.Data.Repository;
using Paneleo.Data.Repository.Interfaces;
using Paneleo.Models;
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
        private readonly IRepository<OrderProduct> _orderProductRepository;
        private readonly IRepository<Contractor> _contractorRepository;
        private readonly IRepository<Product> _productRepository;

        private readonly IPaneleoRepository _paneleoRepository;

        private readonly IMapper _mapper;

        private readonly IPaneleoContractorsService _contractorService;
        private readonly IPaneleoProductsService _productsService;

        public PaneleoOrdersService(IRepository<Order> orderRepository, IRepository<OrderProduct> orderProductRepository, IRepository<Contractor> contractorRepository, IRepository<Product> productRepository, IPaneleoContractorsService contractorService, IPaneleoProductsService productsService, IPaneleoRepository paneleoRepository, IMapper mapper)
        {
            _paneleoRepository = paneleoRepository;
            _orderRepository = orderRepository;
            _orderProductRepository = orderProductRepository;
            _contractorRepository = contractorRepository;
            _productRepository = productRepository;

            _contractorService = contractorService;
            _productsService = productsService;

            _mapper = mapper;
        }

        public async Task<Response<object>> AddAsync(AddOrderBindingModel bindingModel, int userId)
        {
            var user = (await _paneleoRepository.GetUser(userId));
            var response = await ValidateBindingModelAsync(bindingModel);

            if (response.ErrorOccurred)
            {
                return response;
            }

            response = await _contractorService.AddAsync(bindingModel.Contractor, userId);
            response.RemoveError(Key.Contractor);

            if (bindingModel.Products != null)
            {
                await AddNotExistingProductsToDatabaseAsync(bindingModel.Products, user);
                bindingModel.Products = await AssignProductIdToProducts(bindingModel.Products);
            }

            var addedContractor = _mapper.Map<Contractor>(response.SuccessResult);
            var mappedOrder = _mapper.Map<Order>(bindingModel);
            mappedOrder.CreatedBy = user;
            mappedOrder.ContractorId = addedContractor.Id;

            var orderAddSuccess = await _orderRepository.AddAsync(mappedOrder);

            if (!orderAddSuccess)
            {
                response.AddError(Key.Order, Error.OrderAddError);
            }

            response.SuccessResult = mappedOrder;

            return response;
        }

        private async Task<ICollection<ProductOrderDto>> AssignProductIdToProducts(ICollection<ProductOrderDto> bindingModelProducts)
        {
            foreach (var product in bindingModelProducts)
            {
                var productId = (await _productRepository.GetByAsync(x => x.Name == product.Name)).Id;
                product.ProductId = productId;
            }

            return bindingModelProducts;
        }

        private async Task AddNotExistingProductsToDatabaseAsync(ICollection<ProductOrderDto> bindingModelProducts,
            User user)
        {
            foreach (var product in bindingModelProducts)
            {
                var productsExists = await _productRepository.ExistAsync(x => x.Name == product.Name);

                if (!productsExists)
                {
                    var newProduct = _mapper.Map<Product>(product);
                    newProduct.CreatedBy = user;
                    await _productRepository.AddAsync(newProduct);
                }
            }
        }

        private async Task<Response<object>> ValidateBindingModelAsync(AddOrderBindingModel bindingModel)
        {
           
            var response  =  bindingModel.Products != null ? CheckProducts(bindingModel.Products) : new Response<object>();

            //response = bindingModel.Products != null
            //    ? await CheckIfProductsExist(bindingModel.Products, response)
            //    : response;

            //response = await CheckIfContractorExistsAsync(bindingModel.ContractorId, response);

            return response;
        }

        private async Task<Response<object>> CheckIfProductsExist(ICollection<ProductOrderDto> bindingModelProducts, Response<object> response)
        {
            var productsFromRepo = (await _productRepository.GetAllAsync()).ToList();
            foreach (var product in bindingModelProducts)
            {
                if (productsFromRepo.All(w => w.Id != product.ProductId))
                {
                    response.AddError(Key.Product, Error.ProductNotExist);
                }
            }

            return response;
        }
     
        private async Task<Response<object>> CheckIfContractorExistsAsync(int bindingModelContractorId, Response<object> response)
        {
            var contractorExists = await _contractorRepository.ExistAsync(x => x.Id == bindingModelContractorId);

            if (!contractorExists)
            {
                response.AddError(Key.Contractor, Error.ContractorNotExist);
            }

            return response;
        }

        private Response<object> CheckProducts(ICollection<ProductOrderDto> bindingModelProducts)
        {
            var productsList = new List<ProductOrderDto>();
            var response = new Response<object>();

            foreach (var product in bindingModelProducts)
            {
                if (productsList.Any(x => x.Name == product.Name))
                {
                    response.AddError(Key.Product, "Produkt " + product.Name + " " + Error.AlreadyInList);
                }
                else
                {
                    productsList.Add(product);
                }
            }

            return response;
        }

        public async Task<Response<object>> UpdateAsync(UpdateOrderBindingModel bindingModel, int userId)
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

        public async Task<Response<object>> DeleteAsync(int orderId)
        {
            var response = new Response<object>();
            var order = await _orderRepository.GetByAsync(x => x.Id == orderId);
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

        public async Task<Response<object>> GetLastOrderDetailsAsync()
        {
            var response = new Response<object>();

            var lastOrder = (await _orderRepository.GetAllAsync()).OrderByDescending(x => x.Id).FirstOrDefault();

            if (lastOrder == null)
            {
                response.SuccessResult = new Contractor
                    {
                        Id = 0
                    };
                return response;
            }

            response.SuccessResult = lastOrder;

            return response;
        }

        public async Task<SearchResults<OrderDetailedDto>> GetByParameters(SearchParamsBindingModel searchParams)
        {
            var orders = await _orderRepository.GetAllAsync();
            var ordersCount = orders.Count();
            var ordersPageCount = (int)Math.Ceiling((decimal)orders.Count() / searchParams.PageLimit);
            orders = orders.Skip(searchParams.PageLimit * (searchParams.PageNumber - 1)).Take(searchParams.PageLimit);

            var ordersDto = _mapper.Map<List<OrderDetailedDto>>(orders);
            var i = 0;

            foreach (var order in orders)
            {
                var contractor = await _contractorRepository.GetByAsync(x => x.Id == order.ContractorId);
                //ordersDto[i++].ContractorName = contractor.Name;
                ordersDto[i++].Contractor.Name = contractor.Name;
            }

            return new SearchResults<OrderDetailedDto>()
            {
                Results = ordersDto,
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
            bool orderExists = await _orderRepository.ExistAsync(x => x.Id == bindingModel.Id);
            if (!orderExists)
            {
                response.AddError(Key.Order, Error.OrderNotExist);
            }

            return response;
        }

        public async Task<Response<OrderDetailedDto>> GetAsync(int orderId)
        {
            var response = new Response<OrderDetailedDto>();

            if (orderId == 0)
            {
                response.AddError(Key.Contractor, Error.ContractorNotExist);
                return response;
            }

            var order = (await _orderRepository.GetByAsync(x => x.Id == orderId));

            if (order == null)
            {
                response.AddError(Key.Contractor, Error.ContractorNotExist);
                return response;
            }

            var orderDto = _mapper.Map<OrderDetailedDto>(order);

            var contractor = await _contractorRepository.GetByAsync(x => x.Id == order.ContractorId);

            orderDto.Contractor = _mapper.Map<ContractorDto>(contractor);

            var productIds = await _orderProductRepository.GetAllByAsync(x => x.OrderId == orderId);

            foreach (var product in productIds)
            {
                var productDto =
                    _mapper.Map<ProductOrderDto>(await _productRepository.GetByAsync(x => x.Id == product.ProductId));
                orderDto.Products.Add(productDto);
            }

            response.SuccessResult = orderDto;

            return response;
        }
    }

}