﻿using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext dbContext;
        public OrderService(ApplicationDbContext dbContext)
        {
                this.dbContext = dbContext;
        }

        public Task<Order> GetOrder()
        {
            return dbContext.Orders.OrderByDescending(x => x.Quantity * x.Price).FirstOrDefaultAsync();
        }

        public Task<List<Order>> GetOrders()
        {
            return dbContext.Orders.Where(x => x.Quantity > 10).ToListAsync();
        }
    }
}
