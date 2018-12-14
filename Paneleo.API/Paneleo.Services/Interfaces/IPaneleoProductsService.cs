using System.Security.Principal;
using System.Threading.Tasks;
using Paneleo.Models.BindingModel;
using Paneleo.Models.ModelDto;

namespace Paneleo.Services.Interfaces
{
    public interface IPaneleoProductsService
    {
        Task<Response<object>> AddAsync(AddProductBindingModel bindingModel, int identityName);
        Task<Response<object>> UpdateAsync(UpdateProductBindingModel bindingModel, int userId);
        Task<Response<object>> DeleteAsync(string productName);
        Task<Response<SearchResults<ProductDetailedDto>>> GetAllAsync(SearchParamsBindingModel searchParams);
    }
}