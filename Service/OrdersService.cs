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

        public async Task<List<ServiceResponse<string>>> GetOrdersByRestaurantName(string restaurantName)
        {
            var response = new List<ServiceResponse<string>>();

            // Fetch all restaurants and orders
            var restaurants = await Task.Run(() => _ordersRepository.GetAllRestaurants());
            var orders = await Task.Run(() => _ordersRepository.GetAllOrders());

            // Find the restaurant by name
            var restaurant = restaurants.FirstOrDefault(r => r.RestaurantName == restaurantName);

            if (restaurant == null)
            {
                response.Add(new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Restaurant not found.",
                    Data = null
                });

                return response;
            }

            // Get orders for the matching restaurant ID
            var filteredOrders = orders.Where(o => o.RestaurantID == restaurant.RestaurantID).ToList();

            if (!filteredOrders.Any())
            {
                response.Add(new ServiceResponse<string>
                {
                    Success = false,
                    Message = "No orders found for the given restaurant.",
                    Data = null
                });
            }
            else
            {
                response.AddRange(filteredOrders.Select(order => new ServiceResponse<string>
                {
                    Success = true,
                    Message = "Order retrieved successfully.",
                    Data = $"Order ID: {order.OrderID}"
                }));
            }

            return response;
        }


        

        public async Task<ServiceResponse<string>> RegisterOrdersAsync(PlaceOrderDto registerOrderDto)
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