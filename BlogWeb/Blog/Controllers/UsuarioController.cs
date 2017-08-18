using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class UsuarioController : Controller
    {

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel l)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Post", new { area = "Admin" });
            }
            else
            {
                return View(l);
            }
        }
    }
}