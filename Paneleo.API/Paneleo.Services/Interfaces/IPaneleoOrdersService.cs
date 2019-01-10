using Paneleo.Models.BindingModel;
using Paneleo.Models.BindingModel.Order;
using Paneleo.Models.ModelDto;
using System.Threading.Tasks;
using DinkToPdf.Contracts;
using Paneleo.Models.ModelDto.Order;

namespace Paneleo.Services.Interfaces
{
    public interface IPaneleoOrdersService
    {
        Task<Response<object>> AddAsync(AddOrderBindingModel bindingModel, int userId);
        Task<Response<object>> UpdateAsync(UpdateOrderBindingModel bindingModel, int userId);
        Task<Response<object>> DeleteAsync(int orderId);
        Task<Response<OrderDetailedDto>> GetAsync(int orderId);
        Task<Response<IDocument>> CreatePdf(int orderId);
        Task<Response<SearchResults<OrderDetailedDto>>> GetAllAsync(SearchParamsBindingModel searchParams);
        Task<Response<object>> GetLastOrderDetailsAsync();
    }
}