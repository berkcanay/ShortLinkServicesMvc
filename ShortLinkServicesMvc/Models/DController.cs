using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShortLinkServicesMvc.Models
{
    public class DController : Controller
    {
        public ActionResult In(string I)
        {
            try
            {
                //Request.ClientCertificate - Requestle tüm istekleri görebilirsin
                Link link = new Link();
                link.UzunLink = I;
                link = link.UzunLinkGetir();
                if (link.TiklanmaSayac < 10)
                {
                    //string param = Request.QueryString["I"].ToString();
                    link.SayacArttir();
                    Response.Redirect(link.UzunLink);
                }
            }
            catch (Exception ex)
            {
                string date = DateTime.Now.ToString();
                string hata = ex.Message;
                string trace = ex.StackTrace;
                string helplink = ex.HelpLink;
                string path = Server.MapPath("~/Log/" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt");
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine("--cof--cof--cof--cof--cof----cof--cof--cof--cof--cof--");
                    sw.Write(date + "");
                    sw.Write(hata + "");
                    sw.Write(helplink + " ");
                    sw.WriteLine(trace);
                    sw.WriteLine("--cof--cof--cof--cof--cof----cof--cof--cof--cof--cof--");
                }
            }
            return View();

        }
        [HttpPost]
        public JsonResult Art()
        {
            Link link = new Link();
            link.HakArttir();

            return Json("Başarılı");
        }

    }












}


