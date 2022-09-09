using GymEShop.Domain.Domain;
using GymEShop.Domain.Identity;
using GymEShop.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymEShop.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly OrderService orderService;
        private readonly UserManager<EShopApplicationUser> userManager;

        public AdminController (OrderService orderService, UserManager<EShopApplicationUser> userManager)
        {
            this.orderService = orderService;
            this.userManager = userManager;
        }

        [HttpGet("[action]")]
        public List<Order> GetAllActiveOrders()
        {
            return this.orderService.getAllOrders();
        }

        [HttpPost("[action]")]
        public Order GetOrderDetails(BaseEntity model)
        {
            return this.orderService.getDetails(model);
        }

        [HttpPost("[action]")]
        public bool ImportUsers(List<UserRegistrationDto> model)
        {
            bool status = true;

            foreach(var userr in model)
            {
                var checkingUser = userManager.FindByEmailAsync(userr.Email).Result;

                if(checkingUser == null)
                {
                    var user = new EShopApplicationUser
                    {
                        UserName = userr.Email,
                        NormalizedUserName = userr.Email,
                        Email = userr.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        UserCart = new ShoppingCart()
                    };
                    var result = userManager.CreateAsync(user, userr.Password).Result;

                    status = status && result.Succeeded;
                }
                else
                {
                    continue;
                }
            }

            return status;
        }
    }
}
