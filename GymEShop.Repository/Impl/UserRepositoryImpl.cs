using GymEShop.Domain.Identity;
using GymEShop.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymEShop.Repository.Impl
{
    public class UserRepositoryImpl : UserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<EShopApplicationUser> entities;
        string errorMessage = string.Empty;

        public UserRepositoryImpl(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<EShopApplicationUser>();
        }

        public void delete(EShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public EShopApplicationUser Get(string id)
        {
            return entities
                .Include(x => x.UserCart)
                .Include("UserCart.ProductInShoppingCarts")
                .Include("UserCart.ProductInShoppingCarts.Product")
                .SingleOrDefault(x => x.Id.Equals(id));
        }

        public IEnumerable<EShopApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void insert(EShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void update(EShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
