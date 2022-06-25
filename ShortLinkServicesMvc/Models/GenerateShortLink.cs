using ShortLinkServicesMvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortLinkServicesMvc.Models
{
    public static class GenerateShortLink
    {
        public static string Generate()  //Bu classı static olusturarak bi kere ramde olusuturulucak sonra heryerden cagırabılıcez sureklı newleyerek ramde yer kaplamıcaz.
        {
            string kisaLink = "";
            //shortLink = DateTime.Now.ToString("d/MM/yyyy/hh/HH/mm/ss");
            //Buradaki mantık random olusuturulan link zaman cinsinden aynı seylerın denk gelmedıgı ıcın tarih saat salise cinsinden veriliyor ve aynı anda 2 kısı butona basıp link alsa bile sıraya sokuyor aynı ınsana aynı zamanı vermıyor.
            kisaLink = DateTime.Now.TarihiCevir();
            //shortLink = shortLink.Replace(".", ""); /*string.Empty == "" */
            kisaLink = kisaLink.Temizle();
            return kisaLink;
        }
        //Static demedigimiz zaman methodlara erısmek ıcın ınstance almamız gerekıyordu static dedigimizde instance almamıza gerek kalmadan methodlara erısım saglayabılırız
        //Generate olustur anlamına geliyor



    }
}