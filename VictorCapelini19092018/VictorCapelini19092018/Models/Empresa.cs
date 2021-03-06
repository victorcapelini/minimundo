﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace VictorCapelini19092018.Models
{

    public class Empresa : BaseModel
    {
        [Required]
        public string Nome { get; private set; }
        [Required]
        public string CNPJ { get; private set; }
        [Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataDeCadastro { get; private set; }
        [Required]
        public string RazaoSocial { get; private set; }

        public Empresa(string nome, string cNPJ, DateTime dataDeCadastro, string razaoSocial)
        {
            Nome = nome;
            CNPJ = cNPJ;
            DataDeCadastro = dataDeCadastro;
            RazaoSocial = razaoSocial;
        }

        public Empresa()
        {
        }

        public Empresa(string nome, string cNPJ, string razaoSocial)
        {
            Nome = nome;
            CNPJ = cNPJ;
            DataDeCadastro = DateTime.Now;
            RazaoSocial = razaoSocial;
        }

        public void Altera(string nome, string cnpj, string razaoSocial)
        {
            Nome = nome;
            CNPJ = cnpj;
            RazaoSocial = razaoSocial;
        }

    }
}
