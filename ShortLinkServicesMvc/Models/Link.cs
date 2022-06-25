using ShortLinkServicesMvc.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShortLinkServicesMvc.Models
{
    public class Link
    {
        SqlProcess proces = new SqlProcess();
        public string UzunLink { get; set; }
        public string KısaLink { get; set; }

        public void Ekle()
        {
            proces.SetExecuteNonQuery("Insert into [UserLink] (UzunLink,KisaLink) values (@uzunlink,@kisalink)",
                new SqlParameter("@uzunlink", UzunLink),
                new SqlParameter("@kisalink", KısaLink)

                );
        }
        public string UzunLinkGetir()
        {
           
            DataTable dt = proces.SetExecuteReader("Select * from [UserLink] where KisaLink=@kisalink",
                new SqlParameter("@kisalink", KısaLink)
                );
            if (dt.Rows.Count > 0) //Burada dt icindeki rowun 1 den buyuk olması gerekıyor ki if şartı sağlansın.
            {
                return dt.Rows[0]["UzunLink"].ToString();
            }
            else
            {
                return "";
            }

        }
        public List<Link> TümLinkleriGetir()
        {
            DataTable dt = proces.SetExecuteReader("select * from UserLink");
       
            List<Link> linkler = new List<Link>();
            foreach (DataRow satir in dt.Rows)
            {
                linkler.Add(new Link
                {
                    UzunLink = satir["uzunlink"].ToString(),
                    KısaLink = satir["kisalink"].ToString()

                } );
            }
            return linkler;
        }

    }
}