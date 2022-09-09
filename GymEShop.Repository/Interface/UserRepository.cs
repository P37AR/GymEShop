using GymEShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymEShop.Repository.Interface
{
    public interface UserRepository
    {
        IEnumerable<EShopApplicationUser> GetAll();

        EShopApplicationUser Get(string id);

        void insert(EShopApplicationUser entity);

        void update(EShopApplicationUser entity);

        void delete(EShopApplicationUser entity);
    }
}
