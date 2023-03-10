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
    public class CommentController : Controller
    {
      
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        CommentValidator commenttValidator = new CommentValidator();

        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var commentlist = commentManager.CommentByBlog(id);
            return PartialView(commentlist);
        }

        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }

        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment c)
        {
            ValidationResult validationResult = commenttValidator.Validate(c);

            if (validationResult.IsValid)
            {

                c.CommentStatus = true;
                commentManager.TAdd(c);
                return PartialView();
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return PartialView();
            }

        }

        public ActionResult AdminCommentListTrue()
        {
            var commentList = commentManager.CommentByStatusTrue();
            return View(commentList);
        }

        public ActionResult AdminCommentListFalse()
        {
            var commentList = commentManager.CommentByStatusFalse();
            return View(commentList);
        }

        public ActionResult StatusChangeToFalse(int id)
        {
            commentManager.CommentStatusChangeToFalse(id);
            return RedirectToAction("AdminCommentListTrue");
        }

        public ActionResult StatusChangeToTrue(int id)
        {
            commentManager.CommentStatusChangeToTrue(id);
            return RedirectToAction("AdminCommentListFalse");
        }
    }
}