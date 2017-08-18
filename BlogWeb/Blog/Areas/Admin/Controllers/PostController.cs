using Blog.DAL;
using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private PostDAO DAO;

        public PostController()
        {
            DAO = new PostDAO();
        }

        public ActionResult Index()
        {
            var lista = DAO.Lista();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Novo()
        {
            return View(new Post());
        }

        [HttpPost]
        public ActionResult Novo(Post p)
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

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            return View(DAO.BuscaPorId(id));
        }

        [HttpPost]
        public ActionResult Alterar(Post p)
        {
            if (ModelState.IsValid)
            {
                DAO.Update(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View("AlteraPost", p);
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

        public ActionResult Excluir(int id)
        {
            DAO.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CategoriaAutocomplete(string term)
        {
            var lista = DAO.CategoriasPorTermo(term);
            var model = lista.Select(s => new { label = s });
            return Json(model);
        }

    }
}