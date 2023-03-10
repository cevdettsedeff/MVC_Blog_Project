using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Blog_Project.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        BlogManager blogManager = new BlogManager(new EfBlogDal());

        CommentManager commentManager = new CommentManager(new EfCommentDal());

        Context context = new Context();


        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BlogList(int page = 1)
        {

            var bloglist = blogManager.GetList().ToPagedList(page, 6); //sayfada kaç post olacağını gösterir. 1 den başlayıp 6 tane alır.
            return PartialView(bloglist);
        }

        [AllowAnonymous]
        public PartialViewResult FeaturedPosts() // öne çıkan postlar
        {
 
            // 1.Post
            var posttitle1 =blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage1 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();
            var postdate1 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogDate).FirstOrDefault();
            var postblogid1 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.postdate1 = postdate1;
            ViewBag.postblogid1 = postblogid1;


            // 2.Post
            var posttitle2 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage2 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogImage).FirstOrDefault();
            var postdate2 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogDate).FirstOrDefault();
            var postblogid2 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle2 = posttitle2;
            ViewBag.postimage2 = postimage2;
            ViewBag.postdate2 = postdate2;
            ViewBag.postblogid2 = postblogid2;


            // 3.Post
            var posttitle3 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage3 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogImage).FirstOrDefault();
            var postdate3 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogDate).FirstOrDefault();
            var postblogid3 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle3 = posttitle3;
            ViewBag.postimage3 = postimage3;
            ViewBag.postdate3 = postdate3;
            ViewBag.postblogid3 = postblogid3;

            // 4.Post
            var posttitle4 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage4 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            var postdate4 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();
            var postblogid4 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle4 = posttitle4;
            ViewBag.postimage4 = postimage4;
            ViewBag.postdate4 = postdate4;
            ViewBag.postblogid4 = postblogid4;


            //Ortadaki post (5.Post)
            var posttitle5 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage5 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogImage).FirstOrDefault();
            var postdate5 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogDate).FirstOrDefault();
            var postblogid5 = blogManager.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle5 = posttitle5;
            ViewBag.postimage5 = postimage5;
            ViewBag.postdate5 = postdate5;
            ViewBag.postblogid5 = postblogid5;

            return PartialView();
        }


        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPosts() // diğer öne çıkan postlar
        {
            return PartialView();
        }

        [AllowAnonymous]
        public ActionResult BlogDetails()
        {

            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = blogManager.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }

        [AllowAnonymous]
        public PartialViewResult BlogReadMore(int id)
        {
            var BlogDetailsList = blogManager.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }

        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var BlogListByCategory = blogManager.GetBlogByCategory(id);
            var CategoryName = blogManager.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = CategoryName;

            var CategoryDescription = blogManager.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDescription = CategoryDescription;

            return View(BlogListByCategory);
        }

        public ActionResult AdminBlogList()
        {
            var blogadmin1 = blogManager.GetList();
            return View(blogadmin1);
        }

        public ActionResult AdminBlogList2()
        {
            var blogadmin2 = blogManager.GetList();
            return View(blogadmin2);
        }

        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult AddNewBlog()
        {

            List<SelectListItem> values = (from x in context.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in context.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values2 = values2;

            return View();
        }

        [Authorize(Roles ="A")]
        [HttpPost]
        public ActionResult AddNewBlog(Blog blog)
        {
            blogManager.TAdd(blog);
            return RedirectToAction("AdminBlogList");
        }

        public ActionResult DeleteBlog(int id)
        {
            Blog blog = blogManager.GetByID(id);
            blogManager.TDelete(blog);
            return RedirectToAction("AdminBlogList2");
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
            return RedirectToAction("AdminBlogList");
        }

        public ActionResult GetCommentByBlog(int id)
        {

            var commenList = commentManager.CommentByBlog(id);
            return View(commenList);
        }

        public ActionResult AuthorBlogList(int id)
        {
           
            var blogs = blogManager.GetBlogByAuthor(id);
            return View(blogs);
        }

    }
}