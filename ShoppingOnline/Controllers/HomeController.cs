using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Models;
using ShoppingOnline.Models.ViewModels;
using System.Diagnostics;

namespace ShoppingOnline.Controllers
{
    public class HomeController : Controller
    {
        private IWebHostEnvironment _webHostEnvironment;

        public IProductRepository _productRepository;

        public HomeController(IWebHostEnvironment w, IProductRepository p)
        {
            _webHostEnvironment = w;
            _productRepository = p;
        }

        public IActionResult Index(string category)
        {
            ProductListViewModel productListViewModel = new ProductListViewModel()
            {
                Products = _productRepository.GetAllProducts().Where(p => category == null || p.Category == category),
                CurrentCategory = category
            };
            return View(productListViewModel.Products);
        }

        public IActionResult Details(int id)
        {
            return View(_productRepository.GetProduct(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string filename = null;
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "images");

                filename = model.photoPath.FileName;
                string filepath = Path.Combine(path, filename);

                model.photoPath.CopyTo(new FileStream(filepath,FileMode.Create));

                Product p = new Product()
                {
                    ID = model.ID,
                    Name = model.Name,
                    shortDescription = model.shortDescription,
                    longDescription = model.longDescription,
                    Price = model.Price,
                    Instock = model.Instock,
                    Category = model.Category,
                    photoPath = filename
                };
                _productRepository.AddProduct(p);
                return View("Details", _productRepository.GetProduct(p.ID));
                //RedirectToAction("Details", new {id = p.ID});
            }
            return View();
        }
    }
}