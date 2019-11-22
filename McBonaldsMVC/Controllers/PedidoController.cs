using System;
using Microsoft.AspNetCore.Mvc;
using McBonaldsMVC.Models;
using Microsoft.AspNetCore.Http;
using McBonaldsMVC.Repositories;
using System.Collections.Generic;
using McBonaldsMVC.ViewModels;

namespace McBonaldsMVC.Controllers
{
    public class PedidoController : AbstractController
    {

        PedidoRepository pedidoRepository = new PedidoRepository();
        HamburguerRepository hamburguerRepository = new HamburguerRepository();
        ShakeRepository shakeRepository = new ShakeRepository();
        ClienteRepository clienteRepository = new ClienteRepository();

        public IActionResult Index()
        {
            var hamburgueres = hamburguerRepository.ObterTodos();
            var shakes = shakeRepository.ObterTodos();
            PedidoViewModels pedido = new PedidoViewModels();
            pedido.Hamburgueres = hamburgueres;
            pedido.Shakes = shakes;

            var usuarioLogado = ObterUsuarioSession();
            var nomeUsuarioLogado = ObterUsuarioNomeSession();
            if (!string.IsNullOrEmpty(nomeUsuarioLogado))
            {
                pedido.NomeUsuario = nomeUsuarioLogado;
            }

            var clienteLogado = clienteRepository.ObterPor(usuarioLogado);
            if(clienteLogado !=null)
            {
                pedido.Cliente = clienteLogado;
            }

            return View(pedido);
        }
        
        public IActionResult Registrar(IFormCollection form)
        {
            Pedido pedido = new Pedido();

            Hamburguer hamburguer = new Hamburguer (form["hamburguer"], hamburguerRepository.ObterPrecoDe(form["hamburguer"]));

            Shake shake = new Shake (form["shake"], shakeRepository.ObterPrecoDe(form["shake"]));

            pedido.Shake = shake;

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

            pedido.PrecoTotal = hamburguer.Preco + shake.Preco;

            pedidoRepository.Inserir(pedido);

            return View ("Sucesso");
        }
    }
}