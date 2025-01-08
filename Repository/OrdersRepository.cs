﻿using Microsoft.EntityFrameworkCore;
using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.Models;

namespace OnlineFoodDelivery.Repository
{
    public class OrdersRepository : IOrdersRepository
    {

        public readonly  OnlineFoodDeliveryDB _DbContext;

        public OrdersRepository(OnlineFoodDeliveryDB dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task DeleteOrdersAsync(Orders orders)
        {
            _DbContext.Orders.Remove(orders);
            _DbContext.SaveChanges();
        }

        public async Task<Orders> GetOrderByIDAsync(int OrderID)
        {
           return await _DbContext.Orders.FirstOrDefaultAsync(i => i.OrderID == OrderID);
        }

        public async Task RegisterOrdersAsync(Orders orders)
        {
            await _DbContext.Orders.AddAsync(orders);
             await _DbContext.SaveChangesAsync();
        }

        public Task UpdateOrdersAsync(Orders orders)
        {
            throw new NotImplementedException();
        }
    }
}
