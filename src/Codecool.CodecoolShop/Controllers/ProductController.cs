using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductService ProductService { get; set; }

        public ProductDaoMemory ProductDao { get; set; }

        public SupplierDaoMemory SupplierDao { get; set; }

        public ProductCategoryDaoMemory ProductCategoryDao { get; set; }


        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance());

            ProductDao = ProductDaoMemory.GetInstance();

            SupplierDao = SupplierDaoMemory.GetInstance();

            ProductCategoryDao = ProductCategoryDaoMemory.GetInstance();

        }

        public IActionResult Index()
        {
            var products = ProductDao.GetAll();
            var categories = ProductCategoryDao.GetAll();
            var suppliers = SupplierDao.GetAll();
            return View((products.ToList(), categories.ToList(), suppliers.ToList()));
        }

        [Route("/getProducts")]
        public IActionResult GetProducts([FromQuery] string filterBy, [FromQuery] int filter)
        {
            IEnumerable<Product> products;
            _logger.LogDebug(filter.ToString());
            if (filter != 0)
            {
                if (filterBy == "category")
                {
                    _logger.LogDebug("category");
                    products = ProductService.GetProductsForCategory(filter);
                }
                else
                {
                    _logger.LogDebug("supplier");
                    products = ProductService.GetProductsForSupplier(filter);
                }
            }
            else {
                products = ProductDao.GetAll();
            }
            string jsonString = JsonSerializer.Serialize(products);
            return Ok(jsonString);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
