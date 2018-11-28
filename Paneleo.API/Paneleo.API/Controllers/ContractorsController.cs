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
    public class ContractorsController : ControllerBase
    {
        private readonly IPaneleoContractorsService _contractorService;

        public ContractorsController(IPaneleoContractorsService contractorService)
        {
            this._contractorService = contractorService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddContractorBindingModel bindingModel)
        {
            var result = await _contractorService.AddAsync(bindingModel);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateContractorBindingModel bindingModel)
        {
            var result = await _contractorService.UpdateAsync(bindingModel);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{contractorId}")]
        public async Task<IActionResult> DeleteAsync(int contractorId)
        {
            var result = await _contractorService.DeleteAsync(contractorId);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]SearchParamsBindingModel searchParams)
        {
            var result = await _contractorService.GetAllAsync(searchParams);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}