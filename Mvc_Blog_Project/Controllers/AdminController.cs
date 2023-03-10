using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc_Blog_Project.Controllers
{
    public class AdminController : Controller
    {

        AdminManager adminManager = new AdminManager(new EfAdminDal());
        AdminValidator adminValidator = new AdminValidator();

        public ActionResult AdminList()
        {
            var adminList = adminManager.GetList();
            return View(adminList);
        }

        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminAdd(Admin admin)
        {

            ValidationResult validationResult = adminValidator.Validate(admin);
            if (validationResult.IsValid)
            {

                adminManager.TAdd(admin);
                return RedirectToAction("AdminList");
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
        public ActionResult AdminEdit(int id)
        {
            Admin admin = adminManager.GetByID(id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult AdminEdit(Admin admin)
        {
            ValidationResult validationResult = adminValidator.Validate(admin);
            if (validationResult.IsValid)
            {
                adminManager.TUpdate(admin);
                return RedirectToAction("AdminList");
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

        public ActionResult DeleteAdmin(int id)
        {
            Admin admin = adminManager.GetByID(id); 
            adminManager.TDelete(admin);
            return RedirectToAction("AdminList");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin", "Admin");
        }

    }
}
