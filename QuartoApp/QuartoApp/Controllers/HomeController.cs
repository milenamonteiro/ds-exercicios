using QuartoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuartoApp.Controllers
{
    public class HomeController : Controller
    {
        Pessoa pessoa = new Pessoa()
        {
            PessoaID = 1,
            Nome = "Astrogildo",
            Tipo = "Administrador"
        };

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            Fornecedor fornecedor = new Fornecedor()
            {
                FornecId = 1,
                Nome = "Associação 171",
                Endereco = "Rua Falsa, 157",
                Tel = 24241234
            };

            ViewBag.ID = fornecedor.FornecId;
            ViewBag.Nome = fornecedor.Nome;
            ViewBag.Endereco = fornecedor.Endereco;
            ViewBag.Tel = fornecedor.Tel;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Contato()
        {
            ViewData["PessoaId"] = pessoa.PessoaID;
            ViewData["Nome"] = pessoa.Nome;
            ViewData["Tipo"] = pessoa.Tipo;

            return View();
        }
    }
}