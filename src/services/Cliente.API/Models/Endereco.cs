using System;
using Core.ClassLibrary.DomainObjects;

namespace Cliente.API.Models
{
	public class Endereco : Entity
	{
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public Guid ClienteId { get; private set; }
        //Relacao 1:1 com Cliente
        public Cliente Cliente { get; private set; }

        public Endereco(string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
        }

        //EF Relation
        public Endereco() { }
    }
}

