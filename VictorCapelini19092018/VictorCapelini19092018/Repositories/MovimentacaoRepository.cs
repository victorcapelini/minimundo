using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using VictorCapelini19092018.Contexto;
using VictorCapelini19092018.Models;

namespace VictorCapelini19092018.Repositories
{
    public class MovimentacaoRepository : BaseRepository<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public void GeraMovimentacao(DateTime data, string tipoDeMovimentacao, Empresa empresa, Pessoa pessoa)
        {
            Movimentacao novaMovimentacao = new Movimentacao(data, tipoDeMovimentacao, empresa, pessoa);
            dbSet.Add(novaMovimentacao);
            contexto.SaveChanges();
        }

        public IList<Movimentacao> GetMovimentacaoPorPessoa(int id)
        {
            return dbSet.Include("Pessoa").Include("Empresa").Where(t => t.Pessoa.Id == id).ToList();
        }
    }
}
