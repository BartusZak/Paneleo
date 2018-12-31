using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paneleo.Services.Helpers;
using Paneleo.Services.Interfaces;

namespace Paneleo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogUserActivity))]
    public class DashboardController : ControllerBase
    {
        private readonly IPaneleoDashboardService _dashboardService;

        public DashboardController(IPaneleoDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        // GET: api/Dashboard
        [HttpGet]
        public async Task<IActionResult> GetStatistics()
        {
            var result = await _dashboardService.GetStatisticsAsync();
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //// GET: api/Dashboard/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Dashboard
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Dashboard/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
