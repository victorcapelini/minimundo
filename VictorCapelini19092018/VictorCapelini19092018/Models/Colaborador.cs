using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace VictorCapelini19092018.Models
{
    [DataContract]
    public class Colaborador
    {
        public Colaborador(Pessoa pessoa, Empresa empresa, double salario, string status, DateTime dataDeContratacao, DateTime dataDeDemissao, string cargo)
        {
            Pessoa = pessoa;
            Empresa = empresa;
            Salario = salario;
            Status = status;
            DataDeContratacao = dataDeContratacao;
            DataDeDemissao = dataDeDemissao;
            Cargo = cargo;
        }

        public Colaborador(Pessoa pessoa, Empresa empresa, double salario, string status, string cargo)
        {
            Pessoa = pessoa;
            Empresa = empresa;
            Salario = salario;
            Status = status;
            Cargo = cargo;
        }

        public Colaborador()
        {

        }

        [DataMember]
        public int Id { get; protected set; }
        [Required]
        public Pessoa Pessoa { get; set; }
        [Required]
        public Empresa Empresa { get; private set; }
        [Required]
        public double Salario { get; private set; }
        [Required]
        public string Status { get; private set; }
        [Required]
        public DateTime DataDeContratacao { get; private set; }
        [Required]
        public DateTime DataDeDemissao { get; private set; }
        [Required]
        public string Cargo { get; private set; }
        [Required]
        public IList<Movimentacao> Movimentacoes { get; private set; }

        public void VinculaPessoa(Pessoa pessoa)
        {
            this.Pessoa = pessoa;
        }

    }
}
