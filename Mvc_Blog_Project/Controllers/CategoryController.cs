using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Mvc_Blog_Project.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryvalues2 = categoryManager.GetAllOnlyTrue();
            return PartialView(categoryvalues2);
        }

        public ActionResult AdminCategoryList()
        {
            var categoryList = categoryManager.GetAll();
            return View(categoryList);
        }

        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminCategoryAdd(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {

                categoryManager.TAdd(category);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {

            Category category = categoryManager.GetByID(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult CategoryEdit(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {

                categoryManager.TUpdate(category);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

    public ActionResult CategoryStatusFalse(int id)
    {
        categoryManager.CategoryStatusFalseBL(id);
        return RedirectToAction("AdminCategoryList");

    }
    public ActionResult CategoryStatusTrue(int id)
    {
        categoryManager.CategoryStatusTrueBL(id);
        return RedirectToAction("AdminCategoryList");

    }
}
}