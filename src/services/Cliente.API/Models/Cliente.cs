using System;
using Core.ClassLibrary.DomainObjects;

namespace Cliente.API.Models
{
	public class Cliente : Entity, IAggregateRoot
	{
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }
        public bool Excluido { get; private set; }
        //Relacao 1:1 com Endereco
        public Endereco Endereco { get; private set; }

        public Cliente(string nome, string email, string cpf)
        {
            Nome = nome;
            Email = email;
            CPF = cpf;
            Excluido = false;
        }

        //EF Relation
        protected Cliente() { }
    }
}

