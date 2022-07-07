using Codecool.CodecoolShop.Data;
using Codecool.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Codecool.DataAccess.Repository.IRepository;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Build.Framework.ILogger;

namespace Codecool.CodecoolShop.Areas.Customer.Controllers;
[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _logger.LogDebug(1, "NLog injected into HomeController");
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Hello, this is the index!");
        IEnumerable<Product> productsList = _unitOfWork.Product.GetAll(includeProperties:"Category");
        return View(productsList);
    }

    public IActionResult Details(int id)
    {
        ShoppingCart cartObj = new()
        {
            Count = 1,
            Product = _unitOfWork.Product.GetFirstOrDefault(i => i.Id == id, includeProperties: "Category")

        };
        return View(cartObj);
    }
}

    

