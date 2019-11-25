using System;

namespace RoleTopMVC.Models
{
    public class Eventos
    {
        public Cliente Cliente {get;set;}
        
        public Festa Festa {get;set;}

        public DateTime DataDoEvento {get;set;}

        public double PrecoTotal {get;set;}

        public Eventos()
        {
            this.Cliente = new Cliente();
            this.Festa = new Festa();
        }
    }
}