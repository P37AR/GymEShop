using GymEShop.Domain.Domain;
using GymEShop.Domain.DTO;
using GymEShop.Domain.Identity;
using GymEShop.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GymEShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartService shoppingCartService;
        private readonly UserManager<EShopApplicationUser> _userManager;

        public ShoppingCartController(ShoppingCartService shoppingCartService, UserManager<EShopApplicationUser> userManager)
        {
            this.shoppingCartService = shoppingCartService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(this.shoppingCartService.getShoppingCartInfo(userId));
        }

        public IActionResult DeleteProductFromShoppingCart(Guid productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = this.shoppingCartService.deleteProductFromShoppingCart(userId, productId);


            if(result)
                return RedirectToAction("Index", "ShoppingCart");
            else
                return RedirectToAction("Index", "ShoppingCart");
        }

        public IActionResult OrderNow()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this.shoppingCartService.orderNow(userId);

            if(result)
                return RedirectToAction("Index", "ShoppingCart");
            else
                return RedirectToAction("Index", "ShoppingCart");
        }

        /*public IActionResult PayProducts(string email, string token)
        {
            var customerService = new CustomerService();
            var chargeService = new ChargeService();

            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var fullOrder = this.shoppingCartService.getShoppingCartInfo(userID);

            var customer = customerService.Create(new CustomerCreateOptions
            {
                Email=email,
                Source=token
            });

            var charge = chargeService.Create(new ChargeCreateOptions
            {
                Amount=(Convert.ToInt32(fullOrder.TotalPrice)*100),
                Description="Thank You For You Trust!",
                Currency="usd",
                Customer=customer.Id
            });

            if(charge.Status=="succeeded")
            {
                var result = this.OrderNow();
                if (result)
                    return RedirectToAction("Index", "ShoppingCart");
                else
                    return RedirectToAction("Index", "ShoppingCart");
            }
            return RedirectToAction("Index", "ShoppingCart");
        }*/
    }
}
