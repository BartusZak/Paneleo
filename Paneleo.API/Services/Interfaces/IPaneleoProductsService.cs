using System.Threading.Tasks;
using Paneleo.API.Models.ModelDto;

namespace Paneleo.API.Services.Interfaces
{
    public interface IPaneleoProductsService
    {
        Task<Response<object>> AddAsync(AddProductBindingModel bindingModel);
        Task<Response<object>> UpdateAsync(UpdateProductBindingModel bindingModel);
        Task<Response<object>> DeleteAsync(int productId);
    }
}