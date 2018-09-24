using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace VictorCapelini19092018.Models
{
    public class Colaborador : BaseModel
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

        [Required]
        public Pessoa Pessoa { get; set; }
        [Required]
        public Empresa Empresa { get; private set; }
        [Required]
        public double Salario { get; private set; }
        [Required]
        public string Status { get; private set; }
        [Required, DataType(DataType.Date)]
        public DateTime DataDeContratacao { get; private set; }
        [Required, DataType(DataType.Date)]
        public DateTime DataDeDemissao { get; private set; }
        [Required]
        public string Cargo { get; private set; }
        [Required]
        public IList<Movimentacao> Movimentacoes { get; private set; }

        public void VinculaPessoa(Pessoa pessoa)
        {
            this.Pessoa = pessoa;
        }

        internal void Altera(string cargo, DateTime dataDeContratacao, DateTime dataDeDemissao, double salario, string status)
        {
            Cargo = cargo;
            DataDeContratacao = dataDeContratacao;
            DataDeDemissao = dataDeDemissao;
            Salario = salario;
            Status = status;
        }

        public void Contratar(DateTime data)
        {
            DataDeContratacao = data;
            Status = "Contratado";
        }

        internal void Demitir(DateTime dataDeDemissao)
        {
            DataDeDemissao = dataDeDemissao;
            Status = "Demitido";
        }
    }
}
