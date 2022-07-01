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
        public int Id { get; set; }
        public string UzunLink { get; set; }
        public string KısaLink { get; set; }
        public int TiklanmaSayac { get; set; }


        public void Ekle()
        {
            proces.SetExecuteNonQuery("Insert into [UserLink] (UzunLink,KisaLink) values (@uzunlink,@kisalink)",
                new SqlParameter("@uzunlink", UzunLink),
                new SqlParameter("@kisalink", KısaLink)

                );
        }
        public Link UzunLinkGetir()
        {
           
            DataTable dt = proces.SetExecuteReader("Select * from [UserLink] where KisaLink=@kisalink",
                new SqlParameter("@kisalink", KısaLink)
                );
            Link link = new Link();
            if (dt.Rows.Count > 0) 
            {
                link.UzunLink=dt.Rows[0]["UzunLink"].ToString();
                link.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                link.TiklanmaSayac = Convert.ToInt32(dt.Rows[0]["TiklanmaSayac"]);
                return link;
            }
            else
            {
                return new Link();
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

        public void SayacArttir()
        {
            proces.SetExecuteNonQuery("Update [UserLink] set TiklanmaSayac+=1 where Id=@id",
                new SqlParameter("@id", Id)
                );
            

        }
        public void HakArttir()
        {
            proces.SetExecuteNonQuery("Update [UserLink] set TiklanmaSayac-=5");
        }
    }
}