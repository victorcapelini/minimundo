using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using VictorCapelini19092018.Contexto;
using VictorCapelini19092018.Models;

namespace VictorCapelini19092018.Repositories
{
    public class ColaboradorRepository : BaseRepository<Colaborador>, IColaboradorRepository
    {
        private readonly EmpresaRepository empresaRepository;
        private readonly PessoaRepository pessoaRepository;
        private readonly MovimentacaoRepository movimentacaoRepository;

        public ColaboradorRepository(ApplicationContext contexto) : base(contexto)
        {
            empresaRepository = new EmpresaRepository(contexto);
            pessoaRepository = new PessoaRepository(contexto);
            movimentacaoRepository = new MovimentacaoRepository(contexto);
        }

        public Colaborador GetColaboradorId(int id)
        {
            return dbSet.Include("Pessoa").Include("Empresa").Where(t => t.Id == id).SingleOrDefault();
        }

        public IList<Colaborador> GetColaboradores()
        {
            return dbSet.Include("Pessoa").Include("Empresa").ToList();
        }

        public void CriaColaborador(IFormCollection collection)
        {
            string movimentacao = "Vinculado(a)";
            Colaborador colaborador = CollectionToColaborador(collection, movimentacao);
            GeraMovimentacao(DateTime.Now,colaborador, movimentacao);
            dbSet.Add(colaborador);
            contexto.SaveChanges();
        }

        private void GeraMovimentacao(DateTime data,Colaborador colaborador, string movimentacao)
        {
            movimentacaoRepository.GeraMovimentacao(data, movimentacao, colaborador.Empresa, colaborador.Pessoa);
        }

        private Colaborador CollectionToColaborador(IFormCollection collection, string status)
        {
            return new Colaborador(pessoaRepository.GetPessoaId(Convert.ToInt32(collection["Pessoa"])), empresaRepository.GetEmpresaId(Convert.ToInt32(collection["Empresa"])), Convert.ToDouble(collection["Salario"]), status, collection["Cargo"]);
        }

        public void UpdateColaborador(int id, IFormCollection collection)
        {
            Colaborador ColaboradorAntes = GetColaboradorId(id);
            Colaborador ColaboradorDepois = CollectionToColaborador(collection, collection["Status"]);

            ColaboradorAntes.Altera(ColaboradorDepois.Cargo, ColaboradorDepois.DataDeContratacao, ColaboradorDepois.DataDeDemissao, ColaboradorDepois.Salario, ColaboradorDepois.Status);
            dbSet.Update(ColaboradorAntes);

            contexto.SaveChanges();
        }

        public void DeletaColaborador(int id)
        {
            dbSet.Remove(GetColaboradorId(id));
            contexto.SaveChanges();
        }

        public void Contrata(int id, IFormCollection collection)
        {
            string movimentacao = "Contratado(a)";
            DateTime dataContratacao = DateTime.ParseExact(collection["DataDeContratacao"], "yyyy-MM-dd", CultureInfo.CurrentCulture);
            Colaborador colaborador = GetColaboradorId(id);
            colaborador.Contratar(dataContratacao);

            GeraMovimentacao(dataContratacao,colaborador, movimentacao);

            dbSet.Update(colaborador);
            contexto.SaveChanges();

        }

        public void Demite(int id, IFormCollection collection)
        {
            string movimentacao = "Demitido(a)";
            DateTime dataDeDemissao = DateTime.ParseExact(collection["DataDeDemissao"], "yyyy-MM-dd", CultureInfo.CurrentCulture);
            Colaborador colaborador = GetColaboradorId(id);
            colaborador.Demitir(dataDeDemissao);

            GeraMovimentacao(dataDeDemissao,colaborador, movimentacao);

            dbSet.Update(colaborador);
            contexto.SaveChanges();
        }
    }
}
