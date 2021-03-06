﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;

namespace Streetwood.Core.Domain.Implementation.Repositories
{
    internal class OrdersRepository : Repository<Order>, IOrdersRepository
    {
        private readonly IDbContext dbContext;

        public OrdersRepository(IDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(Order order)
            => await dbContext.Orders.AddAsync(order);

        public async Task<Order> GetFullAndEnsureExistsAsync(int id)
        {
            var order = await dbContext
                .Orders
                .Where(s => s.Id == id)
                .Include(s => s.Address)
                .Include(s => s.OrderDiscount)
                .Include(s => s.OrderShipment)
                .Include(x => x.OrderPayment)
                .Include(s => s.User)
                .Include(s => s.ProductOrders)
                    .ThenInclude(s => s.ProductCategoryDiscount)
                .Include(s => s.ProductOrders)
                    .ThenInclude(s => s.Product)
                        .ThenInclude(s => s.Images)
                .Include(s => s.ProductOrders)
                    .ThenInclude(s => s.ProductOrderCharms)
                        .ThenInclude(s => s.Charm)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                throw new StreetwoodException(ErrorCode.GenericNotExist(typeof(Order), $"Order id: {id} not found"));
            }

            return order;
        }

        public async Task<Order> GetAndEnsureExistAsync(int id)
        {
            var order = await dbContext.Orders.FindAsync(id);
            if (order == null)
            {
                throw new StreetwoodException(ErrorCode.GenericNotExist(typeof(Order), "Order id: {id} not found"));
            }

            return order;
        }
    }
}
