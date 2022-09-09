using GymEShop.Domain.Domain;
using GymEShop.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymEShop.Repository.Impl
{
    public class ProductRepositoryImpl<T> : ProductRepository<T> where T : BaseEntity
    {

        private readonly ApplicationDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public ProductRepositoryImpl(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public void delete(T entity)
        {
            if(entity==null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public T Get(Guid? id)
        {
            return entities.SingleOrDefault(x => x.Id.Equals(id));
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void insert(T entity)
        {
            if(entity==null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void update(T entity)
        {
            if(entity==null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
