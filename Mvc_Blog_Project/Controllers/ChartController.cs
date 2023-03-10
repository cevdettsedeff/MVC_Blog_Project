using Mvc_Blog_Project.Models;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Blog_Project.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VisualizeResult()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);

        }

        public List<ChartExample> BlogList()
        {
            List<ChartExample> chartExamples = new List<ChartExample>();
            using(var context = new Context())
            {
                chartExamples = context.Blogs.Select(x => new ChartExample
                {
                    BlogName = x.BlogTitle,
                    Rating = x.BlogRating
                }).ToList();
            }
            return chartExamples;
        }

        public ActionResult VisualizeResult2()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);

        }

        public ActionResult Chart1()
        {
            return View();
        }

        public ActionResult Chart2()
        {
            return View();
        }

        public ActionResult Chart3()
        {
            return View();
        }
    }
}