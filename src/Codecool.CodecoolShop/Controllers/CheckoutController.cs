using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.FinancialConnections;

namespace Codecool.CodecoolShop.Controllers;

public class CheckoutController : Controller
{   [TempData]
    public string TotalAmount { get; set; }

    public IActionResult Index()
    {
        var cart = HttpContext.Session.GetObjectFromJson<List<Item>>("cart");
        ViewBag.cart = cart;
        ViewBag.itemQty = cart.Sum(item => item.Quantity);
        return View();
    };
    
    [HttpPost]
    public IActionResult Processing(string stripeToken, string stripeEmail)
    {
        var optionCust = new CustomerCreateOptions()
        {
            Email = stripeEmail,
            Name = "Robert",
            Phone = "04-234567"
        };
        var sericeCust = new CustomerService();
        Customer customer = sericeCust.Create(optionCust);
        var optionsCharge = new ChargeCreateOptions
        {
            Amount = Convert.ToInt64(TempData["TotalAmount"]),
            Description = "Codecool Shop",
            Source = stripeToken,
            ReceiptEmail = stripeEmail
        };
        var serviceCharge = new ChargeService();
        Charge charge = serviceCharge.Create(optionsCharge);
        if (charge.Status == "succeeded")
        {
            ViewBag.AmountPaid = Convert.ToDecimal(charge.Amount);
            ViewBag.Customer = customer.Name;
        }

        return View();
    }
    
}