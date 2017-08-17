using Blog.DAL;
using Blog.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
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
    }
}