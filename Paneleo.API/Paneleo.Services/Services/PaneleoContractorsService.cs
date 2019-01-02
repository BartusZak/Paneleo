using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NIP24;
using Paneleo.Data.Repository.Interfaces;
using Paneleo.Models.BindingModel;
using Paneleo.Models.BindingModel.Contractor;
using Paneleo.Models.BindingModel.Order;
using Paneleo.Models.Model;
using Paneleo.Models.Model.Contractor;
using Paneleo.Models.ModelDto;
using Paneleo.Models.ModelDto.Contractor;
using Paneleo.Services.Interfaces;

namespace Paneleo.Services.Services
{
    public class PaneleoContractorsService : IPaneleoContractorsService
    {
        private readonly IRepository<Contractor> _contractorRepository;
        private readonly IPaneleoRepository _paneleoRepository;
        private readonly IMapper _mapper;

        public PaneleoContractorsService(IRepository<Contractor> contractorRepository, IMapper mapper,
            IPaneleoRepository paneleoRepository)
        {
            _paneleoRepository = paneleoRepository;
            _mapper = mapper;
            _contractorRepository = contractorRepository;
        }

        public async Task<Response<object>> AddAsync(AddContractorBindingModel bindingModel, int userId)
        {
            var response = new Response<object>();

            if (bindingModel == null)
            {
                response.AddError(Key.Contractor, Error.ContractorAddError);
                return response;
            }

            if ((!bindingModel.IsCompany && bindingModel.Name == null) || bindingModel.Nip == null)
            {
                bindingModel.Name = bindingModel.FirstName + " " + bindingModel.LastName;
            }
            else
            {
                bindingModel.IsCompany = true;
            }

            bindingModel.Name = bindingModel.Name.Trim();
            if (bindingModel.Name.Length == 0)
            {
                response.AddError(Key.Contractor, Error.OrderAddError);
                return response;
            }
            
            response = await ValidateAddingViewModel(bindingModel);
            if (response.ErrorOccurred)
            {
                var existingContractor = await _contractorRepository.GetByAsync(x => x.Name == bindingModel.Name);
                response.SuccessResult = existingContractor;
                return response;
            }

            var contractor = _mapper.Map<Contractor>(bindingModel);

            var user = (await _paneleoRepository.GetUser(userId));
            contractor.CreatedBy = user;

            bool addSucceed = await _contractorRepository.AddAsync(contractor);
            if (!addSucceed)
            {
                response.AddError(Key.Contractor, Error.ContractorAddError);
            }

            response.SuccessResult = contractor;

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

        public async Task<Response<ContractorDetailedDto>> GetAsync(int contractorId)
        {
            var response = new Response<ContractorDetailedDto>();

            var contractor = await _contractorRepository.GetByAsync(x => x.Id == contractorId);

            if (contractor == null)
            {
                response.AddError(Key.Contractor, Error.ContractorNotExist);
                return response;
            }

            response.SuccessResult = _mapper.Map<ContractorDetailedDto>(contractor);

            return response;
        }

        public async Task<Response<SearchResults<ContractorDetailedDto>>> GetAllAsync(
            SearchParamsBindingModel searchParams)
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
            var contractorsPageCount = (int) Math.Ceiling((decimal) contractors.Count() / searchParams.PageLimit);
            contractors = contractors.Skip(searchParams.PageLimit * (searchParams.PageNumber - 1))
                .Take(searchParams.PageLimit);


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

        public async Task<Response<List<ContractorDto>>> SearchAsync(string query)
        {
            var result = new Response<List<ContractorDto>>();

            var queryUpper = query.ToUpperInvariant();

            var contractorsFromDatabase = (await _contractorRepository
                    .GetAllByAsync(x =>
                        x.Name.ToUpperInvariant().Contains(queryUpper) ||
                        x.Nip.ToUpperInvariant().Contains(queryUpper)))
                .Take(10).ToListAsync().Result;

            if (contractorsFromDatabase == null)
            {
                return result;
            }

            var contractorsDto = _mapper.Map<List<ContractorDto>>(contractorsFromDatabase);

            result.SuccessResult = contractorsDto;

            return result;
        }

        public Response<object> GetFromGusByNipAsync(string nip)
        {
            var response = new Response<object>();

            if (!NipValidate(nip))
            {
                response.AddError(Key.Contractor, Error.NipIsNotValid);
                return response;
            }

            //NIP24Client nip24 = new NIP24Client("8K0YH4O5Jrys", "nVghdUKwc05t");
            NIP24Client nip24 = new NIP24Client("DWiuhJbNFDol", "ZBAdTB899Y11");

            InvoiceData invoice = nip24.GetInvoiceData(Number.NIP, nip, true);

            if (invoice != null)
            {
                response.SuccessResult = invoice;
                return response;
            }

            response.AddError(Key.Contractor, nip24.LastError);
            return response;
        }


        private static bool NipValidate(string nipValidate)
        {
            const byte lenght = 10;

            var weights = new byte[] {6, 5, 7, 2, 3, 4, 5, 6, 7};

            if (nipValidate.Length.Equals(lenght).Equals(false)) return false;

            if (ulong.TryParse(nipValidate, out _).Equals(false)) return false;
            string sNip = nipValidate.ToString();
            var digits = new byte[lenght];

            for (int i = 0; i < lenght; i++)
            {
                if (byte.TryParse(sNip[i].ToString(), out digits[i]).Equals(false)) return false;
            }

            var checksum = 0;

            for (var i = 0; i < lenght - 1; i++)
            {
                checksum += digits[i] * weights[i];
            }

            return (checksum % 11 % 10).Equals(digits[digits.Length - 1]);

        }

    }

}