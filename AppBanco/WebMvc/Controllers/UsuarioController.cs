using AppBancoDLL;
using AppBancoDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDAO metodousuario = new UsuarioDAO();
        private Usuario usuario = new Usuario();

        public ActionResult Index(string searchString)
        {
            ViewBag.CurrentFilter = searchString;
            var usuario = metodousuario.Listar();

            if (!String.IsNullOrEmpty(searchString))
            {
                usuario = usuario.Where(s => s.NomeUsu.Contains(searchString)).ToList();
            }

            return View(usuario);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                metodousuario.Insert(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        [HttpGet]
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario = metodousuario.Listar1(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                metodousuario.Atualizar(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        [HttpGet]
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario = metodousuario.Listar1(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpGet]
        public ActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario = metodousuario.Listar1(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarConfirmado(int id)
        {
            metodousuario.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}