using System;
using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.FinancialConnections;

namespace Codecool.CodecoolShop.Areas.Admin.Controllers;

public class CheckoutController : Controller
{
    [TempData]
    public string TotalAmount { get; set; }
    public IActionResult Index()
    {
        var cart = HttpContext.Session.GetObjectFromJson<List<Product>>("cart");
        ViewBag.cart = cart;
        ViewBag.DollarAmount = 1200;
        ViewBag.total = ViewBag.DollarAmount;
        ViewBag.total = Convert.ToInt64(ViewBag.total);
        long total = ViewBag.total;
        TotalAmount = total.ToString();
        return View();
    }
    [HttpPost]
    public IActionResult Processing(string stripeToken, string stripeEmail)
    {
        var optionsCust = new CustomerCreateOptions
        {
            Email = stripeEmail,
            Name = "Robert",
            Phone = "04-234567"

        };
        var serviceCust = new CustomerService();
        Stripe.Customer customer = serviceCust.Create(optionsCust);
        var optionsCharge = new ChargeCreateOptions
        {
            /*Amount = HttpContext.Session.GetLong("Amount")*/
            Amount = 1200,
            Currency = "PLN",
            Description = "Codecool",
            Source = stripeToken,
            ReceiptEmail = stripeEmail,

        };
        var service = new ChargeService();
        Charge charge = service.Create(optionsCharge);
        if (charge.Status == "succeeded")
        {
            string BalanceTransactionId = charge.BalanceTransactionId;
            ViewBag.AmountPaid = 120;
            ViewBag.BalanceTxId = BalanceTransactionId;
            ViewBag.Customer = customer.Name;
            //return View();
        }

        return View();
    }


}