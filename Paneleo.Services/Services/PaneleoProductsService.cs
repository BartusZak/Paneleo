using System.Threading.Tasks;
using AutoMapper;
using Paneleo.Data.Repository.Interfaces;
using Paneleo.Models.BindingModel;
using Paneleo.Models.Model;
using Paneleo.Models.ModelDto;
using Paneleo.Services.Interfaces;

namespace Paneleo.Services.Services
{
    public class PaneleoProductsService : IPaneleoProductsService
    {
        private readonly IRepository<Product> _productRepository;
        public readonly IMapper _mapper;

        public PaneleoProductsService(IRepository<Product> productRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this._productRepository = productRepository;
        }

        public async Task<Response<object>> AddAsync(AddProductBindingModel bindingModel)
        {
            var response = await ValidateAddingViewModel(bindingModel);
            if (response.ErrorOccurred)
            {
                return response;
            }
            var product = _mapper.Map<Product>(bindingModel);

            bool addSucceed = await _productRepository.AddAsync(product);
            if (!addSucceed)
            {
                response.AddError(Key.Product, Error.ProductAddError);
            }

            return response;
        }

        public async Task<Response<object>> UpdateAsync(UpdateProductBindingModel bindingModel)
        {
            var response = await ValidateUpdateViewModel(bindingModel);
            if (response.ErrorOccurred)
            {
                return response;
            }

            var product = await _productRepository.GetByAsync(x => x.Id == bindingModel.Id);

            _productRepository.Detach(product);
            var updatedProduct = _mapper.Map<Product>(bindingModel);

            bool updateSucceed = await _productRepository.UpdateAsync(updatedProduct);
            if (!updateSucceed)
            {
                response.AddError(Key.Product, Error.ProductUpdateError);
            }

            return response;
        }

        public async Task<Response<object>> DeleteAsync(int productId)
        {
            var response = new Response<object>();
            var product = await _productRepository.GetByAsync(x => x.Id == productId);
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
            bool productExists = await _productRepository.ExistAsync(x => x.Id == bindingModel.Id);
            if (!productExists)
            {
                response.AddError(Key.Product, Error.ProductNotExist);
            }

            return response;
        }
    }

}