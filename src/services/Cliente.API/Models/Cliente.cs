using System;
using Core.ClassLibrary.DomainObjects;

namespace Cliente.API.Models
{
	public class Cliente : Entity, IAggregateRoot
	{
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Cpf CPF { get; private set; }
        public bool Excluido { get; private set; }
        //Relacao 1:1 com Endereco
        public Endereco Endereco { get; private set; }

        //EF Relation
        protected Cliente() { }

        public Cliente(Guid id, string nome, string email, string cpf)
        {
            Id = id;
            Nome = nome;
            Email = new Email(email);
            CPF = new Cpf(cpf);
            Excluido = false;
        }

        public void TrocarEmail(string email)
        {
            Email = new Email(email);
        }

        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
    }
}

