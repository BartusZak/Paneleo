using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paneleo.Models.BindingModel;
using Paneleo.Services.Helpers;
using Paneleo.Services.Interfaces;

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

        [HttpDelete("{productName}")]
        public async Task<IActionResult> DeleteAsync(string productName)
        {
            var result = await _productService.DeleteAsync(productName);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]SearchParamsBindingModel searchParams)
        {
            var result = await _productService.GetAllAsync(searchParams);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}