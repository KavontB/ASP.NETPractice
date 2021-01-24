using System;
using Microsoft.AspNetCore.Mvc;
using NathansCRUDWebsite.Models;

namespace NathansCRUDWebsite.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ProductRepo repo = new ProductRepo();
            ProductViewsModel.Products = repo.GetProducts();
            return View();
        }

        public IActionResult UpdatePage(Product p)
        {
            ProductViewsModel pvm = new ProductViewsModel();
            pvm.ProductUpdate = p;
            return View(pvm);
        }

        public IActionResult NewProduct()
        {
            return View();
        }

        public IActionResult CreateProduct(Product p)
        {
            ProductRepo repo = new ProductRepo();
            repo.CreateProducts(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int idToDelete)
        {
            ProductRepo repo = new ProductRepo();
            repo.DeleteProduct(idToDelete);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateProduct(Product p)
        {
            ProductRepo repo = new ProductRepo();
            repo.UpdateProduct(p);
            return RedirectToAction("Index");
        }
    }
}
