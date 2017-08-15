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

        public HomeController()
        {
            DAO = new PostDAO();
        }
        // GET: Home
        public ActionResult Index()
        {
            var lista = DAO.Lista();
            return View(lista);
        }

        public ActionResult NovoPost()
        {
            return View(new Post());
        }

        [HttpPost]
        public ActionResult AdicionaPost(Post p)
        {
            if (ModelState.IsValid)
            {
                DAO.Adiciona(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View("NovoPost",p);
            }
        }

        public ActionResult Categorias([Bind(Prefix="id")] string categoria)
        {
            var lista = DAO.PostsPorCategoria(categoria);
            return View("Index", lista);            
        }

        public ActionResult RemovePost(int id)
        {
            DAO.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult AlteraPost(int id)
        {
            return View(DAO.BuscaPorId(id));
        }

        public ActionResult Update(Post p)
        {
            if (ModelState.IsValid)
            {
                DAO.Adiciona(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View("NovoPost", p);
            }
        }

        public ActionResult Publicar(int id)
        {
            var post = DAO.BuscaPorId(id);
            post.Publicado = true;
            post.Data = DateTime.Now;
            DAO.Update(post);
            return RedirectToAction("Index");
        }
    }
}