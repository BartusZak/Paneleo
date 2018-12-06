using System.Threading.Tasks;
using Paneleo.Models.BindingModel;
using Paneleo.Models.ModelDto;

namespace Paneleo.Services.Interfaces
{
    public interface IPaneleoOrdersService
    {
        Task<Response<object>> AddAsync(AddOrderBindingModel bindingModel);
        Task<Response<object>> UpdateAsync(UpdateOrderBindingModel bindingModel);
        Task<Response<object>> DeleteAsync(int orderId);
        Task<Response<SearchResults<OrderDetailedDto>>> GetAllAsync(SearchParamsBindingModel searchParams);
    }
}