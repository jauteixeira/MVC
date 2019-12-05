using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Models;

namespace RoleTopMVC.Controllers
{
    public class CadastroController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarCliente(IFormCollection form)
        {
            ViewData["Action"] = "Cadastro";

            try
            {
                Cliente cliente = new Cliente(
                    form["nome"],
                    form["email"],
                    form["telefone"],
                    form["senha"],
                    DateTime.Parse(form ["data-nascimento"]));
                
                return View("Sucesso");
            }

                catch(Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro");
            }
        }
    }
}