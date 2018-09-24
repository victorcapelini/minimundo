using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VictorCapelini19092018.Models;

namespace VictorCapelini19092018.Repositories
{
    public interface IMovimentacaoRepository
    {
        void GeraMovimentacao(DateTime data, string tipoDeMovimentacao, Empresa empresa, Pessoa pessoa);
        IList<Movimentacao> GetMovimentacaoPorPessoa(int id);
        
    }
}
