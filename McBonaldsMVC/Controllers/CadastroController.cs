using System;
using McBonaldsMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMVC.Controllers
{
    public class CadastroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarCliente(IFormCollection form)
        {
        
        try{
            Cliente cliente = new Cliente(
            form["nome"], 
            form["endereço"], 
            form["senha"], 
            form["email"],
            DateTime.Parse(form["data-nascimento"]),
            form["telefone"]);
            
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