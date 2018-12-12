using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paneleo.Data.Repository.Interfaces;
using Paneleo.Models.BindingModel;
using Paneleo.Models.BindingModel.Contractor;
using Paneleo.Models.BindingModel.Order;
using Paneleo.Models.Model;
using Paneleo.Models.Model.Contractor;
using Paneleo.Models.ModelDto;
using Paneleo.Services.Interfaces;

namespace Paneleo.Services.Services
{
    public class PaneleoContractorsService : IPaneleoContractorsService
    {
        private readonly IRepository<Contractor> _contractorRepository;
        public readonly IMapper Mapper;

        public PaneleoContractorsService(IRepository<Contractor> contractorRepository, IMapper mapper)
        {
            this.Mapper = mapper;
            this._contractorRepository = contractorRepository;
        }

        public async Task<Response<object>> AddAsync(AddContractorBindingModel bindingModel)
        {
            var response = await ValidateAddingViewModel(bindingModel);
            if (response.ErrorOccurred)
            {
                return response;
            }
            var contractor = Mapper.Map<Contractor>(bindingModel);

            bool addSucceed = await _contractorRepository.AddAsync(contractor);
            if (!addSucceed)
            {
                response.AddError(Key.Contractor, Error.ContractorAddError);
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

            var product = await _contractorRepository.GetByAsync(x => x.ContractorId == bindingModel.Id);

            _contractorRepository.Detach(product);
            var updatedProduct = Mapper.Map<Contractor>(bindingModel);

            bool updateSucceed = await _contractorRepository.UpdateAsync(updatedProduct);
            if (!updateSucceed)
            {
                response.AddError(Key.Contractor, Error.ContractorUpdateError);
            }

            return response;
        }

        public async Task<Response<object>> DeleteAsync(int contractorId)
        {
            var response = new Response<object>();
            var contractor = await _contractorRepository.GetByAsync(x => x.ContractorId == contractorId);
            if (contractor == null)
            {
                response.AddError(Key.Contractor, Error.ContractorNotExist);
                return response;
            }

            bool deleteSucceed = await _contractorRepository.RemoveAsync(contractor);
            if (!deleteSucceed)
            {
                response.AddError(Key.Contractor, Error.ContractorRemoveError);
                return response;
            }
            return response;
        }

        public async Task<Response<SearchResults<ContractorDetailedDto>>> GetAllAsync(SearchParamsBindingModel searchParams)
        {
            var response = new Response<SearchResults<ContractorDetailedDto>>();

            var searchParamsValidated = SearchParametersValidate(searchParams);

            if (searchParamsValidated.ErrorOccurred)
            {
                response.Errors = searchParamsValidated.Errors;
                return response;
            }

            response.SuccessResult = await GetByParameters(searchParamsValidated.SuccessResult);

            //if (searchResults.TotalPageCount == 0)
            //{
            //    response.AddError(Key.Product, Error.PageLimit);
            //}


            return response;
        }

        public async Task<SearchResults<ContractorDetailedDto>> GetByParameters(SearchParamsBindingModel searchParams)
        {
            var contractors = await _contractorRepository.GetAllAsync();
            var contractorsCount = contractors.Count();
            var contractorsPageCount = (int)Math.Ceiling((decimal)contractors.Count() / searchParams.PageLimit);
            contractors = contractors.Skip(searchParams.PageLimit * (searchParams.PageNumber - 1)).Take(searchParams.PageLimit);


            return new SearchResults<ContractorDetailedDto>()
            {
                Results = Mapper.Map<List<ContractorDetailedDto>>(contractors),
                CurrentPage = searchParams.PageNumber,
                TotalPageCount = contractorsPageCount,
                TotalItemsCount = contractorsCount
            };
        }

        private Response<SearchParamsBindingModel> SearchParametersValidate(SearchParamsBindingModel searchParams)
        {
            var response = new Response<SearchParamsBindingModel>();
            if (searchParams.PageLimit == 0)
            {
                response.AddError(Key.Contractor, Error.PageLimit);
            }

            searchParams.PageNumber = Math.Abs(searchParams.PageNumber);
            searchParams.PageLimit = Math.Abs(searchParams.PageLimit);

            response.SuccessResult = searchParams;

            return response;
        }

        private async Task<Response<object>> ValidateAddingViewModel(AddContractorBindingModel viewModel)
        {
            var response = new Response<object>();
            bool contractorExists = await _contractorRepository.ExistAsync(x =>
               x.Name == viewModel.Name);
            if (contractorExists)
            {
                response.AddError(Key.Contractor, Error.ContractorAlreadyExists);
                return response;
            }
            return response;
        }

        private async Task<Response<object>> ValidateUpdateViewModel(UpdateOrderBindingModel bindingModel)
        {
            var response = new Response<object>();
            bool contractorExists = await _contractorRepository.ExistAsync(x => x.ContractorId == bindingModel.Id);
            if (!contractorExists)
            {
                response.AddError(Key.Contractor, Error.ContractorNotExist);
            }

            return response;
        }
    }

}