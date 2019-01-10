using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paneleo.Models.BindingModel;
using Paneleo.Models.BindingModel.Order;
using Paneleo.Models.Utility;
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
        private readonly IConverter _converter;

        public OrdersController(IPaneleoOrdersService orderService, IConverter converter)
        {
            this._orderService = orderService;
            _converter = converter;
        }
        
        [HttpGet("{orderId}")]
        public async Task<IActionResult> Get(int orderId)
        {
            var result = await _orderService.GetAsync(orderId);
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

        [HttpGet("LastOrderDetails")]
        public async Task<IActionResult> GetLastOrderDetails()
        {
            var result = await _orderService.GetLastOrderDetailsAsync();
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            return Ok(result);
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
        [HttpGet("pdf/{orderId}")]
        public async Task<IActionResult> CreatePdf(int orderId)
        {
            var result = await _orderService.CreatePdf(orderId);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            var file = _converter.Convert(result.SuccessResult);

            return File(file, "application/pdf", "Zamowienie_"+ orderId + ".pdf");
        }

    }
}