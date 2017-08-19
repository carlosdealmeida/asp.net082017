using Blog.DAL;
using Blog.Infra;
using Blog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
        public PostController(PostDAO DAO)
        {
            this.DAO = DAO;
        }

        public ActionResult Index()
        {
            var lista = DAO.ListaPublicados();
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
                var manager = HttpContext.GetOwinContext().GetUserManager<UsuarioManager>();
                p.AutorId = User.Identity.GetUserId();
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