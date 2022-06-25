using ShortLinkServicesMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShortLinkServicesMvc.Controllers
{
    public class DController : Controller
    {
        //Linkleri yonlendırme controllerı
        public ActionResult In(String I)
        {
            Link link = new Link();

            link.KısaLink=I;
            string directLink=link.UzunLinkGetir();
            Response.Redirect(directLink);
            return View();
        }

    }
}