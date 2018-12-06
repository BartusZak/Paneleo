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
    public class PaneleoContractorsService : IPaneleoContractorsService
    {
        private readonly IRepository<Contractor> _contractorRepository;
        public readonly IMapper _mapper;

        public PaneleoContractorsService(IRepository<Contractor> contractorRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this._contractorRepository = contractorRepository;
        }

        public async Task<Response<object>> AddAsync(AddContractorBindingModel bindingModel)
        {
            var response = await ValidateAddingViewModel(bindingModel);
            if (response.ErrorOccurred)
            {
                return response;
            }
            var contractor = _mapper.Map<Contractor>(bindingModel);

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

            var product = await _contractorRepository.GetByAsync(x => x.Id == bindingModel.Id);

            _contractorRepository.Detach(product);
            var updatedProduct = _mapper.Map<Contractor>(bindingModel);

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
            var contractor = await _contractorRepository.GetByAsync(x => x.Id == contractorId);
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

            response.SuccessResult = GetByParameters(searchParamsValidated.SuccessResult);

            //if (searchResults.TotalPageCount == 0)
            //{
            //    response.AddError(Key.Product, Error.PageLimit);
            //}


            return response;
        }

        public SearchResults<ContractorDetailedDto> GetByParameters(SearchParamsBindingModel searchParams)
        {
            var contractors = _contractorRepository.GetAllAsync();
            var contractorsCount = contractors.Count();
            var contractorsPageCount = (int)Math.Ceiling((decimal)contractors.Count() / searchParams.PageLimit);
            contractors = contractors.Skip(searchParams.PageLimit * (searchParams.PageNumber - 1)).Take(searchParams.PageLimit);


            return new SearchResults<ContractorDetailedDto>()
            {
                Results = _mapper.Map<List<ContractorDetailedDto>>(contractors),
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
            bool contractorExists = await _contractorRepository.ExistAsync(x => x.Id == bindingModel.Id);
            if (!contractorExists)
            {
                response.AddError(Key.Contractor, Error.ContractorNotExist);
            }

            return response;
        }
    }

}