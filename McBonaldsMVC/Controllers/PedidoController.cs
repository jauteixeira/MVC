using System;
using Microsoft.AspNetCore.Mvc;
using McBonaldsMVC.Models;


namespace McBonaldsMVC.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Registrar(IFormCollection form)
        {
            Pedido pedido = new Pedido();
            Shake shake = new Shake();
            shake.Nome = form["shake"];
            shake.Preco = 0.0;
            return View ("Sucesso");
        }
    }
}