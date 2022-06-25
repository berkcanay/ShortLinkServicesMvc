using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortLinkServicesMvc.Extensions
{
    public static class Extension
    {
        //Extension methodları kesınlikle static olması gerekiyor.
        //Extension methodları genısletme methodları anlamına gelir
        public static string TarihiCevir(this DateTime dt) // buradaki örneğe göre buradaki this, kendisinden sonra gelen date time gibi veri tipinde diğer classlarda aynı veritipinden "."'dan sonra çalışması için ön ayak olmaktadır.
        {
            return dt.ToString("d/MM/yyyy/hh/HH/mm/ss");
        }
        public static string Temizle(this string kisaLink)
        {
            return kisaLink.Replace(".", "");
        }

    }
}