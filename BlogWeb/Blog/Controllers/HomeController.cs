using Blog.DAL;
using Blog.Infra;
using Blog.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            var DAO = new PostDAO();
            var lista = DAO.Lista();
            return View(lista);
        }

        public ActionResult NovoPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaPost(Post p)
        {
            var DAO = new PostDAO();
            DAO.Adiciona(p);
            return RedirectToAction("Index");
        }

        public ActionResult Categorias([Bind(Prefix="id")] string categoria)
        {
            var DAO = new PostDAO();
            var lista = DAO.PostsPorCategoria(categoria);
            return View("Index", lista);            
        }

    }
}