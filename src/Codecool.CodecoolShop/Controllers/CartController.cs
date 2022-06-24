using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;

namespace Codecool.CodecoolShop.Controllers;

public class CartController : Controller
{
    private readonly ILogger<CartController> _logger;
    public ProductService ProductService { get; set; }



    public CartController(ILogger<CartController> logger)
    {
        _logger = logger;
        ProductService = new ProductService(
            ProductDaoMemory.GetInstance(),
            ProductCategoryDaoMemory.GetInstance(),
            CartDaoMemory.GetInstance()
        );
    }

    
    public ActionResult Add(string Command)
    {
        string[] commands = Command.Split(',');
        int ID = Convert.ToInt32(commands.First());
        int categoryId = Convert.ToInt32(commands.Last());
        var products = ProductService.GetProductsForCategory(categoryId);
        Product product = products.Where(t => t.Id == ID).First();
        List<Product> InCart = (List<Product>)ProductService.GetCart();
        ProductService.cartDao.Add(product);
        return RedirectToAction("Index", "Product");
    }


    
    public ActionResult Remove(int Id)
    {
        ProductService.cartDao.Remove(Id);

        return RedirectToAction("Index", "Product");
    }


    
    public ActionResult ViewCart()
    {
        List<Product> InCart = (List<Product>)ProductService.GetCart();
        return View("Cart", InCart);
    }

}