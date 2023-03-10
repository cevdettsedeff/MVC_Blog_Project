using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc_Blog_Project.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AuthorLogin(Author author)
        {
            Context context = new Context();
            var userInfo = context.Authors.FirstOrDefault(x=>x.AuthorMail == author.AuthorMail && x.AuthorPassword == author.AuthorPassword);
            if(userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.AuthorMail, false);
                Session["Mail"] = userInfo.AuthorMail.ToString();
                return RedirectToAction("BlogList", "User");
            }
            else
            {
                return RedirectToAction("AuthorLogin", "Login");
            }
        }


        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            Context context = new Context();
            var adminInfo = context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (adminInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminInfo.UserName, false);
                Session["UserName"] = adminInfo.UserName.ToString();
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Login");
            }
        }
    }
}