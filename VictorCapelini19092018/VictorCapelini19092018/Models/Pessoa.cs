using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace VictorCapelini19092018.Models
{
    [DataContract]
    public class Pessoa
    {

        [DataMember]
        public int Id { get; protected set; }
        [Required]
        public string Nome { get; private set; }
        [Required]
        public string CPF { get; private set; }
        [Required]
        public DateTime DataDeCadastro { get; private set; }
        [Required]
        public DateTime DataDeNascimento { get; private set; }

        public Pessoa(string nome, string cPF, DateTime dataDeNascimento)
        {
            Nome = nome;
            CPF = cPF;
            DataDeCadastro = DateTime.Now;
            DataDeNascimento = dataDeNascimento;
        }
        public void Cadastrar()
        {

        }

        public void Editar()
        {

        }

        public void Deletar()
        {

        }

        public void Visualizar()
        {

        }

        public void BuscaCPF()
        {

        }
    }
}
