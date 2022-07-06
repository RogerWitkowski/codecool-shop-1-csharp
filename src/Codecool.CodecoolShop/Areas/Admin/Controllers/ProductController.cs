using Codecool.DataAccess.Repository.IRepository;
using Codecool.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;

namespace Codecool.CodecoolShop.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductController : Controller
{


    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }


    public IActionResult Index()
    {
        return View();
    }


    //GET
    public IActionResult Upsert(int? id)
    {
        ProductVM productVm = new()
        {
            Product = new(),
            CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            })


        };
        if (id == null || id == 0)
        {
            //create product
            //ViewBag.CategoryList = CategoryList;
            //ViewData["CategoryList"] = CategoryList;
            return View(productVm);
        }
        else
        {
            productVm.Product = _unitOfWork.Product.GetFirstOrDefault(p => p.Id == id);
            //update product
            return View(productVm);
        }


    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(ProductVM objProduct, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\products");
                var extension = Path.GetExtension(file.FileName);

                if (objProduct.Product.ImageUrl != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, objProduct.Product.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }

                objProduct.Product.ImageUrl = @"\images\products\" + fileName + extension;
            }

            if (objProduct.Product.Id == 0)
            {
                _unitOfWork.Product.Add(objProduct.Product);
            }
            else
            {
                _unitOfWork.Product.Update(objProduct.Product);
            }


            _unitOfWork.Save();
            TempData["success"] = "Product created successfully!";
            return RedirectToAction("Index");
        }

        return View(objProduct);
    }

    //public IActionResult Delete(int? id)
    //{
    //    if (id == null || id == 0)
    //    {
    //        return NotFound();
    //    }
    //    //var productToDeleteFromDb = _unitOfWork.Products.Find(id);
    //    var productToDeleteFromDbFirst = _unitOfWork.Product.GetFirstOrDefault(p => p.Id == id);
    //    //var productToDeleteFromDb = _unitOfWork.Products.Find(p => p.Id == id);

    //    if (productToDeleteFromDbFirst == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(productToDeleteFromDbFirst);
    //}

    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public IActionResult DeletePost(int? id)
    //{
    //    var objToDelete = _unitOfWork.Product.GetFirstOrDefault(p => p.Id == id);
    //    if (objToDelete == null)
    //    {
    //        return NotFound();
    //    }

    //    _unitOfWork.Product.Remove(objToDelete);
    //    _unitOfWork.Save();
    //    TempData["success"] = "Product deleted successfully!";
    //    return RedirectToAction("Index");

    //}


    #region API CALLS

    [HttpGet]
    public IActionResult GetAll()
    {
        var productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
        return Json(new { data = productList });
    }


    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var objToDelete = _unitOfWork.Product.GetFirstOrDefault(p => p.Id == id);
        if (objToDelete == null)
        {
            return Json((new { success = false, message = "Error while deleting" }));
        }



        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, objToDelete.ImageUrl.TrimStart('\\'));
        if (System.IO.File.Exists(oldImagePath))
        {
            System.IO.File.Delete(oldImagePath);
        }

        _unitOfWork.Product.Remove(objToDelete);
        _unitOfWork.Save();
        TempData["success"] = "Product deleted successfully!";
        return Json((new { success = true, message = "Delete successful!" }));

    }

    #endregion
}

