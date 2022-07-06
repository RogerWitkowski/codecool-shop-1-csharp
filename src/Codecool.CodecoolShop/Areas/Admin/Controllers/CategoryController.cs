using Codecool.CodecoolShop.Data;
using Codecool.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Codecool.DataAccess.Repository.IRepository;

namespace Codecool.CodecoolShop.Areas.Admin.Controllers;
[Area("Admin")]
    public class CategoryController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();

            return View(objCategoryList);
        }


        //GET

        public IActionResult Create()
        {
            return View();

        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category objCategory)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(objCategory);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }
            return View(objCategory);
        }





        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryToEditFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(p => p.Id == id);

            if (categoryToEditFromDbFirst == null)
            {
                return NotFound();
            }

            return View(categoryToEditFromDbFirst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category editCategory)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(editCategory);
                _unitOfWork.Save();
                TempData["success"] = "Category edited successfully!";
                return RedirectToAction("Index");
            }

            return View(editCategory);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryToDeleteFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(p => p.Id == id);

            if (categoryToDeleteFromDbFirst == null)
            {
                return NotFound();
            }

            return View(categoryToDeleteFromDbFirst);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var objToDelete = _unitOfWork.Category.GetFirstOrDefault(p => p.Id == id);
            if (objToDelete == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(objToDelete);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");

        }

    }

