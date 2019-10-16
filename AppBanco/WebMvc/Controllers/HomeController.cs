using AppBancoDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var metodousuario = new UsuarioDAO();
            var TodosUsuarios = metodousuario.Listar();
            return View(TodosUsuarios);
        }
    }
}