using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoleTopMVC.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Index()
        {

        }

        public IActionResult Registrar (IFormCollection form)
        {
            Pedido pedido = new Pedido();

            Evento evento = new Evento();
            evento.Nome = form["evento"];

            Cliente cliente = new Cliente()
            {
                Nome = form["nome"],
                Endereco = form["endereco"],
                Telefone = form["telefone"],
                Email = form["email"]     
            };

            pedido.Evento = evento;

            return View();
        }
    }
}