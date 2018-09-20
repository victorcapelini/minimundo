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
        [DataMember]
        public int Id { get; protected set; }
        [Required]
        public Pessoa Pessoa { get; private set; }
        [Required]
        public Empresa Empresa { get; private set; }
        [Required]
        public double Salario { get; private set; }
        [Required]
        public byte Status { get; private set; }
        [Required]
        public DateTime DataDeContratacao { get; private set; }
        [Required]
        public DateTime DataDeDemissao { get; private set; }
        [Required]
        public string Cargo { get; private set; }


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

    }
}
