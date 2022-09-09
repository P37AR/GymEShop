using GymEShop.Domain.Domain;
using GymEShop.Repository.Interface;
using GymEShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymEShop.Service.Impl
{
    public class OrderServiceImpl : OrderService
    {
        private readonly OrderRepository orderRepository;

        public OrderServiceImpl(OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public List<Order> getAllOrders()
        {
            return this.orderRepository.getAllOrders();
        }

        public Order getDetails(BaseEntity model)
        {
            return this.orderRepository.getDetails(model);
        }
    }
}
