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
        private PostDAO DAO;
        public HomeController(PostDAO DAO)
        {
            this.DAO = DAO;
        }
        // GET: Home
        public ActionResult Index()
        {
            var lista = DAO.ListaPublicados();
            return View(lista);
        }

        public ActionResult Categorias([Bind(Prefix="id")] string categoria)
        {
            var lista = DAO.PostsPorCategoria(categoria);
            return View("Index", lista);            
        }

        public ActionResult Busca(string termo)
        {
            var lista = DAO.BuscaPorTermo(termo);
            ViewBag.Titulo1 = "Busca por: " + termo; 
            return View("Index", lista);
        }
    }
}