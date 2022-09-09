using GymEShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymEShop.Repository.Interface
{
    public interface ProductRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T Get(Guid? id);

        void insert(T entity);

        void update(T entity);

        void delete(T entity);
    }
}
