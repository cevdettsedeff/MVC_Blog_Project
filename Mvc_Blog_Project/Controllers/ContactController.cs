using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Blog_Project.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();


        [AllowAnonymous]
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SendMessage(Contact contact)
        {
            ValidationResult validationResult = contactValidator.Validate(contact);

            if (validationResult.IsValid)
            {
               
                contactManager.TAdd(contact);
                return RedirectToAction("Index", "Blog");
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

        public ActionResult ReceiveBox()
        {
            var messageList = contactManager.GetList();
            return View(messageList);
        }

        public ActionResult MessageDetails(int id)
        {
            Contact contact = contactManager.GetByID(id);
            return View(contact);
        }

    }
}