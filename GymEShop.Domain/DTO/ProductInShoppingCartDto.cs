using GymEShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymEShop.Domain.DTO
{
    public class ProductInShoppingCartDto
    {
        public List<ProductInShoppingCart> ProductInShoppingCartss { get; set; }

        public double TotalPrice { get; set; }
    }
}
