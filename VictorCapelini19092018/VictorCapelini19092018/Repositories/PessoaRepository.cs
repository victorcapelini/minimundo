using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VictorCapelini19092018.Contexto;
using VictorCapelini19092018.Models;

namespace VictorCapelini19092018.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ApplicationContext contexto;

        public PessoaRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public Pessoa GetPessoaId(int id)
        {
            return contexto.Set<Pessoa>().Where(t => t.Id == id).SingleOrDefault();
        }

        public IList<Pessoa> GetPessoas()
        {
            return contexto.Set<Pessoa>().ToList();
        }

        public void CriaPessoa(IFormCollection collection)
        {
            contexto.Set<Pessoa>().Add(CollectionToPessoa(collection));
            contexto.SaveChanges();
        }

        private Pessoa CollectionToPessoa(IFormCollection collection)
        {
            DateTime dataNascimento = DateTime.ParseExact(collection["DataDeNascimento"], "yyyy-MM-ddTHH:mm", CultureInfo.CurrentCulture);
            return new Pessoa(collection["Nome"], collection["CPF"], dataNascimento);
        }

        public void DeletaPessoa(int id)
        {
            contexto.Set<Pessoa>().Remove(GetPessoaId(id));
            contexto.SaveChanges();
        }

        public void UpdatePessoa(int id, IFormCollection collection)
        {
            Pessoa PessoaAntes = GetPessoaId(id);
            Pessoa PessoaDepois = CollectionToPessoa(collection);

            PessoaAntes.Altera(PessoaDepois.Nome, PessoaDepois.CPF, PessoaDepois.DataDeNascimento);
            contexto.Set<Pessoa>().Update(PessoaAntes);

            contexto.SaveChanges();
        }
    }
}
