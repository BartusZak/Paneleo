using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paneleo.Data.Repository.Interfaces;
using Paneleo.Models;
using Paneleo.Models.BindingModel;
using Paneleo.Models.Model;
using Paneleo.Models.Model.Product;
using Paneleo.Models.ModelDto;
using Paneleo.Models.ModelDto.Product;
using Paneleo.Services.Interfaces;

namespace Paneleo.Services.Services
{
    public class PaneleoProductsService : IPaneleoProductsService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IPaneleoRepository _paneleoRepository;

        private readonly IMapper _mapper;

        public PaneleoProductsService(IRepository<Product> productRepository, IMapper mapper, IPaneleoRepository paneleoRepository)
        {
            _paneleoRepository = paneleoRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Response<object>> AddAsync(AddProductBindingModel bindingModel, int userId)
        {
            var response = await ValidateAddingViewModel(bindingModel);

            if (response.ErrorOccurred)
            {
                return response;
            }
            var product = _mapper.Map<Product>(bindingModel);
            var user = (await _paneleoRepository.GetUser(userId));
            product.CreatedBy = user;

            bool addSucceed = await _productRepository.AddAsync(product);
            if (!addSucceed)
            {
                response.AddError(Key.Product, Error.ProductAddError);
            }

            var productDto = _mapper.Map<AddProductDto>(product);

            response.SuccessResult = productDto;

            return response;
        }

        public async Task<Response<object>> UpdateAsync(UpdateProductBindingModel bindingModel, int userId)
        {
            var response = await ValidateUpdateViewModel(bindingModel);
            if (response.ErrorOccurred)
            {
                return response;
            }

            var product = await _productRepository.GetByAsync(x => x.Name == bindingModel.Name);

            _productRepository.Detach(product);
            var updatedProduct = _mapper.Map<Product>(bindingModel);

            bool updateSucceed = await _productRepository.UpdateAsync(updatedProduct);
            if (!updateSucceed)
            {
                response.AddError(Key.Product, Error.ProductUpdateError);
            }

            return response;
        }

        public async Task<Response<object>> DeleteAsync(string productName)
        {
            var response = new Response<object>();
            var product = await _productRepository.GetByAsync(x => x.Name == productName);
            if (product == null)
            {
                response.AddError(Key.Product, Error.ProductNotExist);
                return response;
            }

            bool deleteSucceed = await _productRepository.RemoveAsync(product);
            if (!deleteSucceed)
            {
                response.AddError(Key.Product, Error.ProductRemoveError);
                return response;
            }
            return response;
        }

        public async Task<Response<ProductDetailedDto>> GetAsync(int productId)
        {
            var response = new Response<ProductDetailedDto>();

            var product = await _productRepository.GetByAsync(x => x.Id == productId);

            if (product == null)
            {
                response.AddError(Key.Product, Error.ProductNotExist);
                return response;
            }

            response.SuccessResult = _mapper.Map<ProductDetailedDto>(product);

            return response;
        }

        public async Task<Response<SearchResults<ProductDetailedDto>>> GetAllAsync(SearchParamsBindingModel searchParams)
        {
            var response = new Response<SearchResults<ProductDetailedDto>>();

            var searchParamsValidated = SearchParametersValidate(searchParams);

            if (searchParamsValidated.ErrorOccurred)
            {
                response.Errors = searchParamsValidated.Errors;
                return response;
            }

            response.SuccessResult = await GetByParameters(searchParamsValidated.SuccessResult);

            return response;
        }

        public async Task<SearchResults<ProductDetailedDto>> GetByParameters(SearchParamsBindingModel searchParams)
        {
            var products = await _productRepository.GetAllAsync();
            var productsCount = products.Count();
            var productsPageCount = (int)Math.Ceiling((decimal)products.Count() / searchParams.PageLimit);
            products = products.Skip(searchParams.PageLimit * (searchParams.PageNumber - 1)).Take(searchParams.PageLimit);


            return new SearchResults<ProductDetailedDto>()
            {
                Results = _mapper.Map<List<ProductDetailedDto>>(products),
                CurrentPage = searchParams.PageNumber,
                TotalPageCount = productsPageCount,
                TotalItemsCount = productsCount
            };
        }
        private Response<SearchParamsBindingModel> SearchParametersValidate(SearchParamsBindingModel searchParams)
        {
            var response = new Response<SearchParamsBindingModel>();
            if (searchParams.PageLimit == 0)
            {
                response.AddError(Key.Product, Error.PageLimit);
            }

            searchParams.PageNumber = Math.Abs(searchParams.PageNumber);
            searchParams.PageLimit = Math.Abs(searchParams.PageLimit);

            response.SuccessResult = searchParams;

            return response;
        }


        private async Task<Response<object>> ValidateAddingViewModel(AddProductBindingModel viewModel)
        {
            var response = new Response<object>();
            bool productExists = await _productRepository.ExistAsync(x =>
               x.Name == viewModel.Name);
            if (productExists)
            {
                response.AddError(Key.Product, Error.ProductAlreadyExists);
                return response;
            }
            return response;
        }

        private async Task<Response<object>> ValidateUpdateViewModel(UpdateProductBindingModel bindingModel)
        {
            var response = new Response<object>();
            bool productExists = await _productRepository.ExistAsync(x => x.Name == bindingModel.Name);
            if (!productExists)
            {
                response.AddError(Key.Product, Error.ProductNotExist);
            }

            return response;
        }
    }

}