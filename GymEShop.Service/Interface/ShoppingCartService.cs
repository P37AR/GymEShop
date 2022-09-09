using GymEShop.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymEShop.Service.Interface
{
    public interface ShoppingCartService
    {
        ProductInShoppingCartDto getShoppingCartInfo(string userId);
        bool deleteProductFromShoppingCart(string userId, Guid id);
        bool orderNow(string userId);
    }
}
