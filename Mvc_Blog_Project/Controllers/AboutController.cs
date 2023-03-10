using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Blog_Project.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        // GET: About

        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        AuthorManager authorManager = new AuthorManager(new EfAuthorDal());

        public ActionResult Index()
        {
            var aboutcontent = aboutManager.GetList();
            return View(aboutcontent);
        }

        public PartialViewResult Footer()
        {
            var aboutcontentlist = aboutManager.GetList();
            return PartialView(aboutcontentlist);
        }

        public PartialViewResult MeetTheTeam()
        {
            var authorlist = authorManager.GetList();
            return PartialView(authorlist);
        }

        [HttpGet]
        public ActionResult UpdateAboutList()
        {
            var aboutList = aboutManager.GetList();
            return View(aboutList);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            aboutManager.TUpdate(about);
            return RedirectToAction("UpdateAboutList");
        }

    }
}