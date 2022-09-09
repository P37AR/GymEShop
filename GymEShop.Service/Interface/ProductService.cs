using GymEShop.Domain.Domain;
using GymEShop.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymEShop.Service.Interface
{
    public interface ProductService
    {
        List<Product> getAllProducts();

        Product getDetailsForProduct(Guid? id);

        void createNewProduct(Product p);

        void updateExistingProduct(Product p);

        AddToShoppingCartDto getShoppingCartInfo(Guid? id);

        void deleteProduct(Guid? id);

        bool addToShoppingCart(AddToShoppingCartDto item, string userId);
    }
}
