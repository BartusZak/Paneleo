using System.Collections.Generic;
using System.Threading.Tasks;
using Paneleo.Models.BindingModel;
using Paneleo.Models.BindingModel.Contractor;
using Paneleo.Models.BindingModel.Order;
using Paneleo.Models.ModelDto;
using Paneleo.Models.ModelDto.Contractor;

namespace Paneleo.Services.Interfaces
{
    public interface IPaneleoContractorsService
    {
        Task<Response<object>> AddAsync(AddContractorBindingModel bindingModel, int userId);
        Task<Response<object>> UpdateAsync(UpdateOrderBindingModel bindingModel);
        Task<Response<object>> DeleteAsync(int contractorId);
        Task<Response<ContractorDetailedDto>> GetAsync(int contractorId);
        Task<Response<SearchResults<ContractorDetailedDto>>> GetAllAsync(SearchParamsBindingModel searchParams);
        Task<Response<List<ContractorDto>>> SearchAsync(string query);
        Response<object> GetFromGusByNipAsync(string nip);
    }
}