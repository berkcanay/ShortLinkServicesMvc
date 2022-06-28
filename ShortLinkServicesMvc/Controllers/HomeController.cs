using ShortLinkServicesMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShortLinkServicesMvc.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            Link link = new Link();

            
            return View(link.TümLinkleriGetir());
        }
        [HttpPost]
        public JsonResult LinkKisalt(string uzunLink)
        {
            string kisaLink = GenerateShortLink.Generate();
            Link link = new Link();
            link.KısaLink = kisaLink;
            link.UzunLink = uzunLink;

            link.Ekle();
            return Json(kisaLink);
        }
        //[HttpGet]
        //public JsonResult Vgetir()
    }
}