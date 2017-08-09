using Blog.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var lista = new List<Post>();
            var cfg = ConfigurationManager.ConnectionStrings["blog"].ConnectionString;
            using(var cnx = new SqlConnection(cfg))
            {
                cnx.Open();
                SqlCommand comando = cnx.CreateCommand();
                comando.CommandText = "select * from Posts";
                SqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Post post = new Post()
                    {
                        Id = Convert.ToInt32(leitor["id"]),
                        Titulo = Convert.ToString(leitor["titulo"]),
                        Resumo = Convert.ToString(leitor["resumo"]),
                        Categoria = Convert.ToString(leitor["categoria"])
                    };
                    lista.Add(post);
                }
            }
            return View(lista);
        }

        public ActionResult NovoPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaPost(Post p)
        {
            var cfg = ConfigurationManager.ConnectionStrings["blog"].ConnectionString;
            using (var cnx = new SqlConnection(cfg))
            {
                cnx.Open();
                SqlCommand comando = cnx.CreateCommand();
                comando.CommandText = "insert into posts (titulo, resumo, categoria) values (@titulo, @resumo, @categoria)";
                comando.Parameters.Add(new SqlParameter("titulo", p.Titulo));
                comando.Parameters.Add(new SqlParameter("resumo", p.Resumo));
                comando.Parameters.Add(new SqlParameter("categoria", p.Categoria));
                comando.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
        }
    }
}