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
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public Pessoa GetPessoaId(int id)
        {
            return dbSet.Where(t => t.Id == id).SingleOrDefault();
        }

        public IList<Pessoa> GetPessoas()
        {
            return dbSet.ToList();
        }

        public void CriaPessoa(IFormCollection collection)
        {
            dbSet.Add(CollectionToPessoa(collection));
            contexto.SaveChanges();
        }

        private Pessoa CollectionToPessoa(IFormCollection collection)
        {
            DateTime dataNascimento = DateTime.ParseExact(collection["DataDeNascimento"], "yyyy-MM-dd", CultureInfo.CurrentCulture);
            return new Pessoa(collection["Nome"], collection["CPF"], dataNascimento);
        }

        public void DeletaPessoa(int id)
        {
            dbSet.Remove(GetPessoaId(id));
            contexto.SaveChanges();
        }

        public void UpdatePessoa(int id, IFormCollection collection)
        {
            Pessoa PessoaAntes = GetPessoaId(id);
            Pessoa PessoaDepois = CollectionToPessoa(collection);

            PessoaAntes.Altera(PessoaDepois.Nome, PessoaDepois.CPF, PessoaDepois.DataDeNascimento);
            dbSet.Update(PessoaAntes);

            contexto.SaveChanges();
        }
    }
}
