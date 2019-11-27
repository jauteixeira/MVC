using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Repositories;

namespace RoleTopMVC.Controllers
{
    public class ClienteController : AbstractController
    {
        private ClienteRepository clienteRepository = new ClienteRepository();
        private PedidoRepository pedidoRepository =  new PedidoRepository();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login (IFormCollection form)
        {
            ViewData ["Action"] = "Login";
            
            try
            {
                System.Console.WriteLine("***********************");
                System.Console.WriteLine(form["email"]);
                System.Console.WriteLine(form["senha"]);
                System.Console.WriteLine("***********************");

                var usuario = form["email"];
                var senha = form["senha"];

                var cliente = clienteRepository.ObterPor(usuario);

                if (cliente != null)
                {
                    if(cliente.Senha.Equals(senha))
                    {
                        HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                        HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                        return RedirectToAction("Historico","Cliente");
                    }
                    else
                    {
                        return View("Erro", new RespostaViewModel("Senha Incorreta"));
                    }
                }
                else
                {
                return View("Erro", new RespostaViewModel($"Usuário {usuario} não foi encontrado"));
                }
            }

            catch(Exception e)
            {
                System.Console.WriteLine("===================");
                System.Console.WriteLine(e.StackTrace);
                System.Console.WriteLine("===================");
                return View("Erro");
            } 
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Remove(SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove(SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}