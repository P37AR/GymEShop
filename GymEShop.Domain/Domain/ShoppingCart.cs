using GymEShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymEShop.Domain.Domain
{
    public class ShoppingCart : BaseEntity
    {
        public string OwnerId { get; set; }

        public EShopApplicationUser Owner { get; set; }

        public virtual ICollection<ProductInShoppingCart> ProductInShoppingCarts { get; set; }
    }
}
