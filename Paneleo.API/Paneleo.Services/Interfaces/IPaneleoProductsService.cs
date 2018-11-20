using System.Threading.Tasks;
using Paneleo.Models.BindingModel;
using Paneleo.Models.ModelDto;

namespace Paneleo.Services.Interfaces
{
    public interface IPaneleoProductsService
    {
        Task<Response<object>> AddAsync(AddProductBindingModel bindingModel);
        Task<Response<object>> UpdateAsync(UpdateProductBindingModel bindingModel);
        Task<Response<object>> DeleteAsync(int productId);
    }
}