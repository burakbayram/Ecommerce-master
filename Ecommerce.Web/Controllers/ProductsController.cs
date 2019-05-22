using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Model;
using Ecommerce.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var products = productService.GetAll();
            return View(products);
        }

        public IActionResult Create()
        {
            var product = new Product();
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid) {
                product.CreatedAt = DateTime.Now;
                product.CreatedBy = User.Identity.Name;
                product.UpdatedAt = DateTime.Now;
                product.UpdatedBy = User.Identity.Name;
                productService.Insert(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);

        }
        public IActionResult Delete(string id)
        {
            productService.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(string id)
        {
            var product = productService.Get(id);
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var oldProduct = productService.Get(product.Id);
                oldProduct.Name = product.Name;
                oldProduct.Description = product.Description;
                oldProduct.Price = product.Price;
                oldProduct.CategoryId = product.CategoryId;
                oldProduct.UpdatedAt = DateTime.Now;
                oldProduct.UpdatedBy = User.Identity.Name;
                productService.Update(oldProduct);
                return RedirectToAction("index");
            }
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        public IActionResult Details(string id)
        {
            var product = productService.Get(id);
            return View(product);
        }
    }
}