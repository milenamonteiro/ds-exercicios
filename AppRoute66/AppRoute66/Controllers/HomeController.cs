using AppRoute66.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppRoute66.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnumerable<Noticia> AsNoticias;
        
        public HomeController()
        {
            AsNoticias = new Noticia().TodasAsNoticias().OrderByDescending(x => x.Data);
        }


        public ActionResult Index()
        {
            var ultimasnoticias = AsNoticias.Take(3);
            var Ascategorias = AsNoticias.Select(x => x.Categoria).Distinct().ToList();
            ViewBag.categoria = Ascategorias;
            return View(ultimasnoticias);
            //respectivamente, retorna um numero específico de elementos contíguos do inicio de uma sequência; Retorna elementos diferentes de uma sequência; cria uma nova lista internamente, com o construtor list.
        }
        public ActionResult MostrarNoticia(int noticiaID) {
            return View(AsNoticias.FirstOrDefault(x => x.NoticiaId == noticiaID));
        }
        public ActionResult MostraCategoria(string categoria)
        {
            var categoriaEspecifica = AsNoticias.Where(x => x.Categoria.ToLower() == categoria.ToLower()).ToList();
            ViewBag.Categoria = categoria;
            return View(categoriaEspecifica);
        }
        public ActionResult Noticia()
        { return View(AsNoticias); }
        //  public ActionResult MostrarNoticias(int)


        //    public ActionResult About()
        //  {
        //    ViewBag.Message = "Your application description page.";
        //
        //          return View();
        //    }

        //  public ActionResult Contact()
        // {
        //    ViewBag.Message = "Your contact page.";
        //
        //   return View();
        //}
        public ActionResult Exemplo()
        { return View(); }
    }
}