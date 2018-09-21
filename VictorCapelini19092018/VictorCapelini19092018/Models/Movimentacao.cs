using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace VictorCapelini19092018.Models
{
    [DataContract]
    public class Movimentacao
    {
        public Movimentacao(DateTime data, string tipoMovimentacao, Empresa empresa, Pessoa pessoa)
        {
            Data = data;
            TipoMovimentacao = tipoMovimentacao;
            Empresa = empresa;
            Pessoa = pessoa;
        }
        [DataMember]
        public int Id { get; protected set; }
        [Required]
        public DateTime Data { get; private set; }
        [Required]
        public string TipoMovimentacao { get; private set; }
        [Required]
        public Empresa Empresa { get; private set; }
        [Required]
        public Pessoa Pessoa { get; private set; }

        public string descreveMovimentação()
        {
            return "No dia " + Data.ToString("dd/MM/yyyy") + " " + Pessoa.Nome + " foi " + TipoMovimentacao + " na empresa " + Empresa.Nome + ".";
        }
    }
}
