using System;
using RoleTopMVC.Enums;
namespace RoleTopMVC.Models
{
    public class Cliente
    {
        public string Nome {get;set;}
        public string Email {get;set;}
        public string Telefone {get;set;}
        public string Senha {get;set;}
        public DateTime DataNascimento {get;set;}
        public uint TipoUsuario {get;set;}

        public Cliente()
        {

        }

        public Cliente(string Nome, string Email, string Telefone, string Senha, DateTime dataNascimento)
        {
            this.Nome = Nome;
            this.Email = Email;
            this.Telefone = Telefone;
            this.Senha = Senha;
            this.DataNascimento = dataNascimento;
            this.TipoUsuario = (uint) TipoUsuario.CLIENTE;
        }
    }
}