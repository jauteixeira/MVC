using System;

namespace RoleTopMVC.Models
{
    public class Pedido
    {
        public Cliente Cliente {get;set;}
        public Eventos Evento {get;set;}
        public DateTime DataDoPedido {get;set;}
        public double PrecoTotal {get;set;}

        public Pedido()
        {
            this.Cliente = new Cliente();
            this.Evento = new Eventos();
            this.DataDoPedido = new DataDoPedido();
        }
    }
}