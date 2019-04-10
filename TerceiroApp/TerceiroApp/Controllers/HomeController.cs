using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TerceiroApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Até agora tudo bem!!!!!!!";
        }
        public string Teste()
        {
            return "opa, só passando aqui para um teste rápido ('v')";
        }
    }
}