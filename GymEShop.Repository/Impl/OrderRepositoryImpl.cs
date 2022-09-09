using GymEShop.Domain.Domain;
using GymEShop.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymEShop.Repository.Impl
{
    public class OrderRepositoryImpl : OrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        string errorMessage = string.Empty;

        public OrderRepositoryImpl(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }

        public List<Order> getAllOrders()
        {
            return entities
                .Include(x => x.Products)
                .Include(x => x.User)
                .Include("Products.SelectedProduct")
                .ToListAsync()
                .Result;
        }

        public Order getDetails(BaseEntity model)
        {
            return entities
                .Include(x => x.Products)
                .Include(x => x.User)
                .Include("Products.SelectedProduct")
                .SingleOrDefaultAsync(x => x.Id.Equals(model.Id)).Result;
        }
    }
}
