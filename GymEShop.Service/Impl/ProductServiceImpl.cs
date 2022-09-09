using GymEShop.Domain.Domain;
using GymEShop.Domain.DTO;
using GymEShop.Repository.Interface;
using GymEShop.Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymEShop.Service.Impl
{
    public class ProductServiceImpl : ProductService
    {
        private readonly ProductRepository<Product> productRepository;
        private readonly ProductRepository<ProductInShoppingCart> productInShoppingCartRepository;
        private readonly UserRepository userRepository;
        private readonly ILogger<ProductService> logger;

        public ProductServiceImpl(ProductRepository<Product> productRepository, UserRepository userRepository
            , ProductRepository<ProductInShoppingCart> productInShoppingCartRepository, ILogger<ProductService> logger)
        {
            this.productRepository = productRepository;
            this.userRepository = userRepository;
            this.productInShoppingCartRepository = productInShoppingCartRepository;
            this.logger = logger;
        }
        public bool addToShoppingCart(AddToShoppingCartDto item, string userId)
        {

            var loggedInUser = userRepository.Get(userId);
            var userCart = loggedInUser.UserCart;

            if (item.ProductId != null && userCart != null)
            {
                var product = this.getDetailsForProduct(item.ProductId);

                if (product != null)
                {
                    ProductInShoppingCart productToAdd = new ProductInShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        Product = product,
                        ProductId = product.Id,
                        ShoppingCart = userCart,
                        ShoppingCartId = userCart.Id,
                        Quantity = item.Quantity
                    };
                    this.productInShoppingCartRepository.insert(productToAdd);
                    logger.LogInformation("Product was successfuly added");
                    return true;
                }
                return false;
            }
            logger.LogInformation("Something was wrong. ProductId or UserShoppingCard may be unavailable!");
            return false;
        }

        public void createNewProduct(Product p)
        {
            this.productRepository.insert(p);
        }

        public void deleteProduct(Guid? id)
        {
            var product = this.getDetailsForProduct(id);
            this.productRepository.delete(product);
        }

        public List<Product> getAllProducts()
        {
            logger.LogInformation("Get All Products was called.");
            return this.productRepository.GetAll().ToList();
        }

        public Product getDetailsForProduct(Guid? id)
        {
            return this.productRepository.Get(id);
        }

        public AddToShoppingCartDto getShoppingCartInfo(Guid? id)
        {
            var product = this.getDetailsForProduct(id);

            AddToShoppingCartDto model = new AddToShoppingCartDto
            {
                SelectedProduct = product,
                ProductId = product.Id,
                Quantity = 1
            };

            return model;
        }

        public void updateExistingProduct(Product p)
        {
            this.productRepository.update(p);
        }
    }
}
