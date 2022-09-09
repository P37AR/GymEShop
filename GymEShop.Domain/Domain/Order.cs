using GymEShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymEShop.Domain.Domain
{
    public class Order : BaseEntity
    {
        public string userId { get; set; }

        public EShopApplicationUser User { get; set; }

        public virtual ICollection<ProductInOrder> Products { get; set; }
    }
}
