using System.Threading.Tasks;
using Paneleo.Models.BindingModel;
using Paneleo.Models.ModelDto;

namespace Paneleo.Services.Interfaces
{
    public interface IPaneleoContractorsService
    {
        Task<Response<object>> AddAsync(AddContractorBindingModel bindingModel);
        Task<Response<object>> UpdateAsync(UpdateContractorBindingModel bindingModel);
        Task<Response<object>> DeleteAsync(int contractorId);
        Task<Response<SearchResults<ContractorDetailedDto>>> GetAllAsync(SearchParamsBindingModel searchParams);
    }
}