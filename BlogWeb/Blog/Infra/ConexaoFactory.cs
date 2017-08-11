using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Blog.Infra
{
    public class ConexaoFactory
    {
        public static IDbConnection Criar()
        {
            var cfg = ConfigurationManager.ConnectionStrings["blog"].ConnectionString;
            SqlConnection cnx = new SqlConnection(cfg);
            cnx.Open();
            return cnx;
        }
    }
}