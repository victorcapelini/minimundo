using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VictorCapelini19092018.Models
{
    public class Empresa
    {

        public string Nome { get; private set; }
        public string CNPJ { get; private set; }
        public DateTime DataDeCadastro { get; private set; }
        public string RazaoSocial { get; private set; }

        public Empresa(string nome, string cNPJ, string razaoSocial)
        {
            Nome = nome;
            CNPJ = cNPJ;
            DataDeCadastro = DateTime.Now;
            RazaoSocial = razaoSocial;
        }



    }
}
