using System.Collections.Generic;
using McBonaldsMVC.Models;

namespace McBonaldsMVC.ViewModels
{
    public class PedidoViewModels
    {
        public List<Hamburguer> Hamburgueres {get;set;}
        public List<Shake> Shakes {get;set;}
        public string NomeUsuario {get;set;}
        public Cliente Cliente {get;set;}
        public PedidoViewModels()
        {
            this.Hamburgueres = new List<Hamburguer>();
            this.Shakes = new List<Shake>();
            this.NomeUsuario = "Jovem";
            this.Cliente = new Cliente();
        }
    }
}