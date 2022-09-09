using GymEShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymEShop.Domain.DTO
{
    public class AddToShoppingCartDto
    {
        public Product SelectedProduct { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
