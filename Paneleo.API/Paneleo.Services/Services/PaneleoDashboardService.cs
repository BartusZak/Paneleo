using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Paneleo.Data.Repository.Interfaces;
using Paneleo.Models.Model.Contractor;
using Paneleo.Models.Model.Order;
using Paneleo.Models.Model.Product;
using Paneleo.Models.ModelDto;
using Paneleo.Models.ModelDto.Contractor;
using Paneleo.Models.ModelDto.Dashboard;
using Paneleo.Models.ModelDto.Order;
using Paneleo.Models.ModelDto.Product;
using Paneleo.Services.Interfaces;

namespace Paneleo.Services.Services
{
    public class PaneleoDashboardService : IPaneleoDashboardService
    {
        private readonly IRepository<OrderProduct> _orderProductRepository;
        private readonly IRepository<Contractor> _contractorRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;

        private readonly IMapper _mapper;

        public PaneleoDashboardService(IRepository<OrderProduct> orderProductRepository, IRepository<Contractor> contractorRepository, IRepository<Order> orderRepository, IRepository<Product> productRepository, IMapper mapper)
        {
            _orderProductRepository = orderProductRepository;
            _contractorRepository = contractorRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;

            _mapper = mapper;

        }

        public async Task<Response<DashboardStatisticsDto>> GetStatisticsAsync()
        {
            var response = new Response<DashboardStatisticsDto>
            {
                SuccessResult = new DashboardStatisticsDto
                {
                    TotalOrdersValue = await CalculateTotalOrdersValue(),
                    ContractorsCount = await CountContactors(),
                    OrdersCount = await CountOrders(),
                    ProductsCount = await CountProducts(),
                    Contractors = await GetLast5Contractors(),
                    Orders = await GetLast5Orders(),
                    Products = await GetLast5Products()
                }
            };
            return response;
        }

        private async Task<ICollection<ProductShortDto>> GetLast5Products()
        {
            var products = (await _productRepository.GetAllAsync()).OrderByDescending(x => x.CreatedAt).Take(5);

            return _mapper.Map<ICollection<ProductShortDto>>(products);
        }

        private async Task<ICollection<OrderShortDto>> GetLast5Orders()
        {
            var orders = (await _orderRepository.GetAllAsync()).OrderByDescending(x => x.CreatedAt).Take(5);

            return _mapper.Map<ICollection<OrderShortDto>>(orders);
        }

        private async Task<ICollection<ContractorShortDto>> GetLast5Contractors()
        {
            var contractors = (await _contractorRepository.GetAllAsync()).OrderByDescending(x => x.CreatedAt).Take(5);

            return _mapper.Map<ICollection<ContractorShortDto>>(contractors);
        }

        private async Task<int> CountProducts()
        {
            return (await _productRepository.GetAllAsync()).Count();
        }

        private async Task<int> CountOrders()
        {
            return (await _orderRepository.GetAllAsync()).Count();
        }

        private async Task<int> CountContactors()
        {
            return (await _contractorRepository.GetAllAsync()).Count();
        }

        private async Task<double> CalculateTotalOrdersValue()
        {
            double totalOrderValue = 0;

            var orders = await _orderProductRepository.GetAllAsync();

            foreach (var orderProduct in orders)
            {
                totalOrderValue += orderProduct.TotalGrossPrice;
            }

            return Math.Round(totalOrderValue * 100)/100;
        }

    }
}
