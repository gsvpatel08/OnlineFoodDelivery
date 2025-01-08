using System.Data.Common;
using AutoMapper;
using OnlineFoodDelivery.Models;
using OnlineFoodDelivery.Models.Dto;
using OnlineFoodDelivery.Repository;
using OnlineFoodDelivery.Service.Interfaces;
using OnlineFoodDelivery.Utility;

namespace OnlineFoodDelivery.Service
{
    public class OrdersService : IOrderService
    {

        public readonly IOrdersRepository _ordersRepository;
        public readonly IMapper _mapper;

        public OrdersService(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> DeleteOrderAsync(OrderDeleteDto orderDeleteDto)
        {
            var orderId =   await _ordersRepository.GetOrderByIDAsync(orderDeleteDto.Id);
            if (orderId != null)
            {
                await _ordersRepository.DeleteOrdersAsync(orderId);
                return new ServiceResponse<string>
                {
                    Success = true,
                    Message = "Order is deleted successfully!"
                };
            }
         
            return new ServiceResponse<string>
            {
                Success = false,
                Message = "OrderId is not found"

            };
        }
        public async Task<ServiceResponse<string>> RegisterOrdersAsync(RegisterOrderDto registerOrderDto)
        {
            try
            {
                var oders = _mapper.Map<Orders>(registerOrderDto);
                await _ordersRepository.RegisterOrdersAsync(oders);
                return new ServiceResponse<string>
                {
                    Success = true,
                    Message = "Order is conformed!"
                };
            }
            catch (DbException ex)
            {

                Console.WriteLine($"Db exception is occur", ex.Message);

                return new ServiceResponse<string>
                {

                    Success = false,
                    Message = "unexcepted error is occur"

                };
            }
        }
    }
}