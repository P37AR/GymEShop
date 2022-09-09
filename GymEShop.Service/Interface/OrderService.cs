using GymEShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymEShop.Service.Interface
{
    public interface OrderService
    {
        List<Order> getAllOrders();

        Order getDetails(BaseEntity model);
    }
}
