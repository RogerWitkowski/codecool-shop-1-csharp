using System;
using Codecool.CodecoolShop.Data;
using Codecool.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Codecool.DataAccess.Repository.IRepository;
using Codecool.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Codecool.CodecoolShop.Areas.Admin.Controllers;
[Area("Admin")]
    public class CompanyController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;
        

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            return View();
        }


    //GET
        public IActionResult Upsert(int? id)
        {
            Company company = new();
            
            if (id == null || id == 0)
            {
                return View(company);
            }
            else
            {
                company = _unitOfWork.Company.GetFirstOrDefault(p=> p.Id==id);
                return View(company);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company objCompany)
        {
            if (ModelState.IsValid)
            {
                if (objCompany.Id == 0)
                {
                    _unitOfWork.Company.Add(objCompany);
                    TempData["success"] = "Company created successfully!";
                }
                else
                {

                    _unitOfWork.Company.Update(objCompany);
                    TempData["success"] = "Company updated successfully!";
                }

                _unitOfWork.Save();
                
                return RedirectToAction("Index");
            }

            return View(objCompany);
        }



    #region API CALLS

    [HttpGet]
    public IActionResult GetAll()
    {
        var companyListAll = _unitOfWork.Company.GetAll();
        return Json(new { data = companyListAll });
    }


    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var objToDelete = _unitOfWork.Company.GetFirstOrDefault(p => p.Id == id);
        if (objToDelete == null)
        {
            return Json((new { success = false, message = "Error while deleting" }));
        }

        _unitOfWork.Company.Remove(objToDelete);
        _unitOfWork.Save();
        return Json((new { success = true, message = "Delete successful!" }));

    }

    #endregion
}

