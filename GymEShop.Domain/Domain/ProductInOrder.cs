using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymEShop.Domain.Domain
{
    public class ProductInOrder : BaseEntity
    {
        public Guid ProductId { get; set; }

        public Guid OrderId { get; set; }

        public Product SelectedProduct { get; set; }

        public Order UserOrder { get; set; }

        public int Quantity { get; set; }
    }
}
