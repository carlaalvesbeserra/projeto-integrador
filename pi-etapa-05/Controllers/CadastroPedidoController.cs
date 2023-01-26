using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projeto_mf.Models;

namespace projeto_mf.Controllers
{
    public class CadastroPedidoController : Controller
    {

        public IActionResult Cadastro()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Cadastro(CadastroPedido novoCadastroPedido)
        {
            CadastroBanco.Inserir(novoCadastroPedido);
            
            ViewBag.Nome = novoCadastroPedido.Nome;
            ViewBag.Telefone = novoCadastroPedido.Telefone;
            ViewBag.DataEntrega = novoCadastroPedido.DataEntrega;
            ViewBag.Pedido = novoCadastroPedido.Pedido;
            ViewBag.Quantidade = novoCadastroPedido.Quantidade;


            return View("Confirmacao");
        }
        
        public IActionResult Lista()
        {
        
            List<CadastroPedido> listaCompleta = CadastroBanco.Listar();
           
            return View(listaCompleta);
        }

        
        public IActionResult Editar(int Id)
        {
            CadastroPedido cadastropedido = CadastroBanco.BuscarPorId(Id);
            return View(cadastropedido);
        }

        [HttpPost]
        public IActionResult Editar(CadastroPedido cadastropedido)
        {
            CadastroBanco.Atualizar(cadastropedido);
            return RedirectToAction("Lista");
        }

        public IActionResult Remover(int Id)
        {
            CadastroBanco.Remover(Id);
            return RedirectToAction("Lista");
        }
    }
}