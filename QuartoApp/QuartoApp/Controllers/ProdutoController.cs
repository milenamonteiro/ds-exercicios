using QuartoApp.Models;
using System.Web.Mvc;

namespace QuartoApp.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Index()
        {
            Produto produto = new Produto()
            {
                ID = 1,
                Nome = "Vencido",
                Valor = (decimal) 200.66, //200.66m
                Quantidade = 0
            };

            ViewBag.ID = produto.ID;
            ViewBag.Nome = produto.Nome;
            ViewBag.Valor = produto.Valor;
            ViewBag.Quantidade = produto.Quantidade;

            return View();
        }
    }
}