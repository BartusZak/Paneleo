using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paneleo.API.Helpers;
using Paneleo.API.Services.Interfaces;

namespace Paneleo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IPaneleoProductsService _productService;

        public ProductsController(IPaneleoProductsService productService)
        {
            this._productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddProductBindingModel bindingModel)
        {
            var result = await _productService.AddAsync(bindingModel);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateProductBindingModel bindingModel)
        {
            var result = await _productService.UpdateAsync(bindingModel);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteAsync(int productId)
        {
            var result = await _productService.DeleteAsync(productId);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}