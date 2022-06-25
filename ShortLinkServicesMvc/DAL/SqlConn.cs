using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortLinkServicesMvc.DAL
{
    public class SqlConn
    {
        private string _connectionString = @"Server=BERKCAN;Database=ShortLink;Trusted_Connection=True;";
        public string ConnectionString { get { return _connectionString; } }
    }
}