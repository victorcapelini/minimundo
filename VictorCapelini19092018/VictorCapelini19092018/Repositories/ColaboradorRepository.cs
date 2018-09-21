using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VictorCapelini19092018.Contexto;
using VictorCapelini19092018.Models;

namespace VictorCapelini19092018.Repositories
{
    public class ColaboradorRepository:IColaboradorRepository
    {
        private readonly ApplicationContext contexto;

        public ColaboradorRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public Colaborador GetColaboradorId(int id)
        {
            return contexto.Colaborador.Include("Pessoa").Include("Empresa").Where(t => t.Id == id).SingleOrDefault();
        }

        public IList<Colaborador> GetColaboradores()
        {            
            return contexto.Colaborador.Include("Pessoa").Include("Empresa").ToList();
        }

        public void CriaColaborador(IFormCollection collection)
        {
            contexto.Set<Colaborador>().Add(CollectionToColaborador(collection));
            contexto.SaveChanges();
        }

        private Colaborador CollectionToColaborador(IFormCollection collection)
        {
            Pessoa pessoa = new Pessoa();
            Empresa empresa = new Empresa();
            return new Colaborador(pessoa , empresa,Convert.ToDouble(collection["Salario"]),"",collection["Cargo"]);
        }
    }
}
