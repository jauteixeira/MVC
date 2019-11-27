using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Models;

namespace RoleTopMVC.Controllers
{
    public class CadastroController : Controller
    {
        ClienteRepository clienteRepository =  new ClienteRepository();

        public IActionResult Index ()
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
                    form["cpf"],
                    form["email"],
                    form["senha"],
                    DateTime.Parse(form["data-nascimento"]),
                    form["telefone"]);
                    clienteRepository.Inserir(cliente);

                System.Console.WriteLine(form["nome"]);
                return View("Sucesso");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("erro");
            }
        }
    }
}