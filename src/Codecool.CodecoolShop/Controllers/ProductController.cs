using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using Codecool.CodecoolShop.Data;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        //private readonly ILogger<ProductController> _logger;
        //public ProductService ProductService { get; set; }

        //public ProductController(ILogger<ProductController> logger)
        //{
        //    _logger = logger;
        //    ProductService = new ProductService(
        //        ProductDaoMemory.GetInstance(),
        //        ProductCategoryDaoMemory.GetInstance(),
        //        CartDaoMemory.GetInstance()
        //    );
        //}


        private readonly ApplicationDbContext _dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult Index()
        {
            IEnumerable<Product> products = _dbContext.Products;
            //var objProductList = _dbContext.Products.ToList();
            return View(products);
        }


        //GET

        public IActionResult Create()
        {
            return View();

        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product objProduct)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(objProduct);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objProduct);
        }
    


    
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        //TODO:Edit Product

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var productFromDb = _dbContext.Products.Find(id);
            var productFromDb = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            //var productFromDb = _dbContext.Products.Find(p => p.Id == id);
            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product editProduct)
        {
            return View();
        }

    }
}
