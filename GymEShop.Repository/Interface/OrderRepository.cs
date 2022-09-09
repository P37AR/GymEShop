using GymEShop.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymEShop.Repository.Interface
{
    public interface OrderRepository
    {
        List<Order> getAllOrders();

        Order getDetails(BaseEntity model);
    }
}
