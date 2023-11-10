using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        /*product product = new product()
        {
        id = 1,
            name="pencil",
            price = 12.4f,
            quantity = 5,
            discount=5,
            description = "used for writing and drawing",
            picture = "~/images/pencil.jpg",
            rating=3
        };
        public iactionresult index()
        {
            return view(product);
        }*/
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            var result = _productService.AddProduct(product);
            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
