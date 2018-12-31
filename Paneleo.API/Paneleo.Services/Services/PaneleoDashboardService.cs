using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paneleo.Data.Repository.Interfaces;
using Paneleo.Models.Model.Contractor;
using Paneleo.Models.Model.Order;
using Paneleo.Models.ModelDto;
using Paneleo.Models.ModelDto.Dashboard;
using Paneleo.Services.Interfaces;

namespace Paneleo.Services.Services
{
    public class PaneleoDashboardService : IPaneleoDashboardService
    {
        private readonly IRepository<OrderProduct> _orderProductRepository;
        private readonly IRepository<Contractor> _contractorRepository;

        public PaneleoDashboardService(IRepository<OrderProduct> orderProductRepository, IRepository<Contractor> contractorRepository)
        {
            _orderProductRepository = orderProductRepository;
            _contractorRepository = contractorRepository;

        }

        public async Task<Response<DashboardStatisticsDto>> GetStatisticsAsync()
        {
            var response = new Response<DashboardStatisticsDto>
            {
                SuccessResult = new DashboardStatisticsDto
                {
                    TotalOrdersValue = await CalculateTotalOrdersValue(),
                    ContractorsCount = await CountContactors()
                }
            };



            return response;
        }

        private async Task<int> CountContactors()
        {

            return (await _contractorRepository.GetAllAsync()).ToList().Count();
            
        }

        private async Task<double> CalculateTotalOrdersValue()
        {
            double totalOrderValue = 0;

            var orders = await _orderProductRepository.GetAllAsync();

            foreach (var orderProduct in orders)
            {
                totalOrderValue += orderProduct.TotalCost;
            }

            return Math.Round(totalOrderValue * 100)/100;
        }

    }
}
