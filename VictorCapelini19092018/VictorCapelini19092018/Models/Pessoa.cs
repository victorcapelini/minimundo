﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using VictorCapelini19092018.Validadores;

namespace VictorCapelini19092018.Models
{

    public class Pessoa : BaseModel
    {
        [Required]
        public string Nome { get; private set; }
        [Display(Name = "CPF")]
        [Cpf(ErrorMessage = "O valor '{0}' é inválido para CPF")]
        public string CPF { get; private set; }
        [Required, DataType(DataType.Date)]
        public DateTime DataDeCadastro { get; private set; }
        [Required, DataType(DataType.Date)]
        public DateTime DataDeNascimento { get; private set; }

        public Pessoa(string nome, string cPF, DateTime dataDeNascimento)
        {
            Nome = nome;
            CPF = cPF;
            DataDeCadastro = DateTime.Now;
            DataDeNascimento = dataDeNascimento;
        }

        public Pessoa()
        {

        }

        public void Altera(string nome, string cpf, DateTime dataDeNascimento)
        {
            Nome = nome;
            CPF = cpf;
            DataDeNascimento = dataDeNascimento;
        }

    }
}
