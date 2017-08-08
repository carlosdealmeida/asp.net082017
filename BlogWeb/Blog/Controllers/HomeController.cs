using Blog.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private List<Post> lista = new List<Post>();

        public HomeController()
        {
            lista = new List<Post>();
            lista.Add(new Post { Titulo = "Harry Potter", Resumo = "Pedra Filosofal", Categoria = "Filme, Livro" });
            lista.Add(new Post { Titulo = "Cassino Royale", Resumo = "007", Categoria = "Filme" });
            lista.Add(new Post { Titulo = "Monge e o Executivo", Resumo = "Romance sobre Liderança", Categoria = "Livro" });
            lista.Add(new Post { Titulo = "New York, New York", Resumo = "Sucesso de Frank Sinatra", Categoria = "Música" });
        }
        // GET: Home
        public ActionResult Index()
        {
             return View(lista);
        }

        public ActionResult NovoPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaPost(Post post)
        {
            lista.Add(post);
            return View("Index", lista);
        }
    }
}