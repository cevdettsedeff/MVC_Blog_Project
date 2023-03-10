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
    public class AuthorController : Controller
    {
        // GET: Author

        BlogManager blogManager = new BlogManager(new EfBlogDal());
        AuthorManager authorManager = new AuthorManager(new EfAuthorDal());
        AuthorValidator authorValidator = new AuthorValidator();

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail = blogManager.GetBlogByID(id);
            return PartialView(authordetail);
        }

        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid = blogManager.GetList().Where(x => x.BlogID == id).Select(y => y.AuthorID).FirstOrDefault();
            
            var authorblogs = blogManager.GetBlogByAuthor(blogauthorid);
            return PartialView(authorblogs);
        }

        public ActionResult AuthorList()
        {
            var authorList = authorManager.GetList();
            return View(authorList);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult AddAuthor(Author author)
        {
            ValidationResult validationResult = authorValidator.Validate(author);
            if (validationResult.IsValid)
            {

                authorManager.TAdd(author);
                return RedirectToAction("AuthorList");
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
        public ActionResult AuthorEdit(int id)
        {
            Author author = authorManager.GetByID(id);
            return View(author);
        }

        [HttpPost]
        public ActionResult AuthorEdit(Author author)
        {
            
            ValidationResult validationResult = authorValidator.Validate(author);
            if (validationResult.IsValid)
            {

                authorManager.TUpdate(author);
                return RedirectToAction("AuthorList");
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


    }
}