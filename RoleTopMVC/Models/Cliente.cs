using System;

namespace RoleTopMVC.Models
{
    public class Cliente
    {
        public string Nome {get; set;}
        public string Senha {get; set;}
        public string Email {get; set;}
        public DateTime DataNascimento {get; set;}
        public string Telefone {get; set;}

        public Cliente()
        {

        }

        public Cliente(string Nome, string Senha, string Email, DateTime dataNascimento, string Telefone)
        {
            this.Nome = Nome;
            this.Telefone = Telefone;
            this.Senha = Senha;
            this.Email = Email;
            this.DataNascimento = dataNascimento;
        }
    }
}