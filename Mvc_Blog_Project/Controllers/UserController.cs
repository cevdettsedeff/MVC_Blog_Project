using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc_Blog_Project.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        
        UserProfileManager userProfile = new UserProfileManager();

        BlogManager blogManager = new BlogManager(new EfBlogDal());

        CommentManager commentManager = new CommentManager(new EfCommentDal());

        Context context = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialProfile(string mail)
        {
            mail = (string)Session["Mail"];
            var profileValues = userProfile.GetAuthorByMail(mail);
            return PartialView(profileValues);
        }

        public ActionResult BlogList(string mail)
        {
            mail = (string)Session["Mail"];
            int id = context.Authors.Where(x=>x.AuthorMail == mail).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = userProfile.GetBlogByAuthor(id);
            return View(blogs);
        }

        public ActionResult UpdateUserProfile(Author author)
        {
            userProfile.EditAuthor(author);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {

            Blog blog = blogManager.GetByID(id);

            Context context = new Context();
            List<SelectListItem> values = (from x in context.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in context.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values2 = values2;

            return View(blog);

        }

        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            blogManager.TUpdate(p);
            return RedirectToAction("BlogList");
        }

        public ActionResult GetCommentByBlog(int id)
        {
            var commenList = commentManager.CommentByBlog(id);
            return View(commenList);
        }

        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context context = new Context();
            List<SelectListItem> values = (from x in context.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in context.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values2 = values2;

            return View();
        }

        [HttpPost]
        public ActionResult AddNewBlog(Blog blog)
        {
            blogManager.TAdd(blog);
            return RedirectToAction("BlogList");
        }

        public ActionResult DeleteBlog(int id)
        {
            Blog blog = blogManager.GetByID(id);
            blogManager.TDelete(blog);
            return RedirectToAction("BlogList");
        }

        public ActionResult AllBlogList()
        {
            var blogadmin1 = blogManager.GetList();
            return View(blogadmin1);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "User");
        }
    }
}