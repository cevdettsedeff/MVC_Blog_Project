using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Blog_Project.Controllers
{
    [AllowAnonymous]
    public class SubscribeMailController : Controller
    {
        // GET: MailSubscribe
        SubscribeMailManager mailManager = new SubscribeMailManager(new EfSubscribeMailDal());

        
        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail subscribeMail)
        {
            mailManager.TAdd(subscribeMail);
            return PartialView();
        }
    }
}