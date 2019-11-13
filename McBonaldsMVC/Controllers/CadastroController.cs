using System;
using McBonaldsMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using McBonaldsMVC.Repositories;

namespace McBonaldsMVC.Controllers
{
    public class CadastroController : Controller
    {
        ClienteRepository clienteRepository = new ClienteRepository();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarCliente(IFormCollection form)
        {
        
        ViewData ["Action"] = "Cadastro";
        
            try
            {
                Cliente cliente = new Cliente(
                form["nome"], 
                form["endereço"], 
                form["senha"], 
                form["email"],
                DateTime.Parse(form["data-nascimento"]),
                form["telefone"]);
                clienteRepository.Inserir(cliente);
            
            System.Console.WriteLine(form["nome"]);
            return View("Sucesso");
            }
            catch (Exception e)
            {
                return View("erro");
            }
        }
    }
}