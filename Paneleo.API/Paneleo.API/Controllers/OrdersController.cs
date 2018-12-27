using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paneleo.Models.BindingModel;
using Paneleo.Models.BindingModel.Order;
using Paneleo.Services.Helpers;
using Paneleo.Services.Interfaces;

namespace Paneleo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IPaneleoOrdersService _orderService;

        public OrdersController(IPaneleoOrdersService orderService)
        {
            this._orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddOrderBindingModel bindingModel)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _orderService.AddAsync(bindingModel, userId);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateOrderBindingModel bindingModel)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _orderService.UpdateAsync(bindingModel, userId);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteAsync(int orderId)
        {
            var result = await _orderService.DeleteAsync(orderId);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]SearchParamsBindingModel searchParams)
        {
            var result = await _orderService.GetAllAsync(searchParams);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("LastOrderId")]
        public async Task<IActionResult> GetLastOrderId()
        {
            var result = await _orderService.GetLastOrderIdAsync();
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}