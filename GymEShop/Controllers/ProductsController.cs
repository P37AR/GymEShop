using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using GymEShop.Domain.DTO;
using GymEShop.Domain.Domain;
using GymEShop.Repository;
using GymEShop.Service.Interface;

namespace GymEShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService serviceInterface;
        private readonly ShoppingCartService shoppingCartService;

        public ProductsController(ProductService serviceInterface, ShoppingCartService shoppingCartService)
        {
            this.serviceInterface = serviceInterface;
            this.shoppingCartService = shoppingCartService;
        }

        // GET: Products
        public IActionResult Index()
        {
            var products = serviceInterface.getAllProducts();
            return View(products);
        }

        public IActionResult AddProductToCard(Guid? id)
        {
            var model = this.serviceInterface.getShoppingCartInfo(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProductToCard([Bind("ProductId", "Quantity")] AddToShoppingCartDto item)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this.serviceInterface.addToShoppingCart(item, userId);

            if(result)
            {
                return RedirectToAction("Index", "Products");
            }

            return View(item);
        }


        // GET: Products/Details/5 
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this.serviceInterface.getDetailsForProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ProductName,ProductImage,ProductDescription,Rating,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                this.serviceInterface.createNewProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this.serviceInterface.getDetailsForProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(Guid id, [Bind("Id,ProductName,ProductImage,ProductDescription,Rating,Price")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.serviceInterface.updateExistingProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this.serviceInterface.getDetailsForProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            this.serviceInterface.deleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(Guid id)
        {
            return this.serviceInterface.getDetailsForProduct(id)!=null;
        }
    }
}
