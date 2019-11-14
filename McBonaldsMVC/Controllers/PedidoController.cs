using System;
using Microsoft.AspNetCore.Mvc;
using McBonaldsMVC.Models;
using Microsoft.AspNetCore.Http;
using McBonaldsMVC.Repositories;

namespace McBonaldsMVC.Controllers
{
    public class PedidoController : Controller
    {

        PedidoRepository pedidoRepository = new PedidoRepository();
        HamburguerRepository hamburguerRepository = new HamburguerRepository();

        public IActionResult Index()
        {
            var hamburgueres = hamburguerRepository.ObterTodos();
            return View();
        }
        
        public IActionResult Registrar(IFormCollection form)
        {
            Pedido pedido = new Pedido();
            
            Shake shake = new Shake();
            shake.Nome = form["shake"];
            shake.Preco = 0.0;

            pedido.Shake = shake;

            Hamburguer hamburguer = new Hamburguer (form["hamburguer"], 0.0);

            pedido.Hamburguer = hamburguer;

            Cliente cliente = new Cliente()
            {
                Nome = form["nome"],
                Endereco = form["endereco"],
                Telefone = form["telefone"],
                Email = form["email"]
            };

            pedido.Cliente = cliente;
            
            pedido.DataDoPedido = DateTime.Now;

            pedido.PrecoTotal = 0.0;

            pedidoRepository.Inserir(pedido);

            return View ("Sucesso");
        }
    }
}