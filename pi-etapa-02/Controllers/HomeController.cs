using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mflanchesmvc.Models;

namespace mflanchesmvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Cadastro()
        {
         return View();
        }
        [HttpPost]
        public IActionResult Cadastro(CadastroDePedidos cadastro)
        {
            ListaDePedidos.Incluir(cadastro);
            return View("Confirmacao");
        }
        public IActionResult Lista(CadastroDePedidos cadastro)
        {
            List<CadastroDePedidos> pedidos = ListaDePedidos.Listar();
            return View(pedidos);
        }
      public IActionResult QuemSomos()
        {
            return View();
        }
        public IActionResult FaleConosco()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
