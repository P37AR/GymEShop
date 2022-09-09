using GymEShop.Domain.Domain;
using GymEShop.Domain.DTO;
using GymEShop.Repository.Interface;
using GymEShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymEShop.Service.Impl
{
    public class ShoppingCartServiceImpl : ShoppingCartService
    {
        private readonly ProductRepository<ShoppingCart> productRepository;
        private readonly UserRepository userRepository;
        private readonly ProductRepository<Order> orderRepository;
        private readonly ProductRepository<ProductInOrder> productInOrderRepository;

        public ShoppingCartServiceImpl(ProductRepository<ShoppingCart> productRepository, UserRepository userRepository,
            ProductRepository<Order> orderRepository, ProductRepository<ProductInOrder> productInOrderRepository)
        {
            this.productRepository = productRepository;
            this.userRepository = userRepository;
            this.orderRepository = orderRepository;
            this.productInOrderRepository = productInOrderRepository;
        }


        public bool deleteProductFromShoppingCart(string userId, Guid id)
        {

            if(!string.IsNullOrEmpty(userId) && id!=null)
            {
                var loggedInUser = this.userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                var productToDelete = userShoppingCart.ProductInShoppingCarts.Where(x => x.Product.Id == id).FirstOrDefault();

                userShoppingCart.ProductInShoppingCarts.Remove(productToDelete);

                this.productRepository.update(userShoppingCart);
                return true;
            }
            return false;
        }

        public ProductInShoppingCartDto getShoppingCartInfo(string userId)
        {
            var loggedInUser = this.userRepository.Get(userId);

            var userShoppingCart = loggedInUser.UserCart;

            var allProducts = userShoppingCart.ProductInShoppingCarts.ToList();

            var productPrice = userShoppingCart.ProductInShoppingCarts.Select(x => new
            {
                ProductPrice = x.Product.Price,
                Quantity = x.Quantity
            }).ToList();

            double totalPrice = 0.00;

            foreach (var item in productPrice)
            {
                totalPrice += item.ProductPrice * item.Quantity;
            }

            ProductInShoppingCartDto shopiingCartDto = new ProductInShoppingCartDto
            {
                ProductInShoppingCartss = userShoppingCart.ProductInShoppingCarts.ToList(),
                TotalPrice = totalPrice
            };

            return shopiingCartDto;
        }

        public bool orderNow(string userId)
        {
            if(string.IsNullOrEmpty(userId))
            {
                return false;
            }
            else
            {
                var loggedInUser = this.userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                Order orderItem = new Order
                {
                    Id = new Guid(),
                    userId = userId,
                    User = loggedInUser
                };

                this.orderRepository.insert(orderItem);

                List<ProductInOrder> productInOrders = new List<ProductInOrder>();

                var productToOrder = userShoppingCart.ProductInShoppingCarts
                    .Select(x => new ProductInOrder
                    {
                        Id = Guid.NewGuid(),
                        OrderId = orderItem.Id,
                        ProductId = x.Product.Id,
                        SelectedProduct = x.Product,
                        UserOrder = orderItem
                    }).ToList();

                productInOrders.AddRange(productToOrder);

                foreach (var item in productInOrders)
                {
                    this.productInOrderRepository.insert(item);
                }

                loggedInUser.UserCart.ProductInShoppingCarts.Clear();
                this.userRepository.update(loggedInUser);
                return true;
            }
        }
    }
}
