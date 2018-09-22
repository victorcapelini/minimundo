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
    public class ColaboradorRepository:BaseRepository<Colaborador>,IColaboradorRepository
    {
        private readonly EmpresaRepository empresaRepository;
        public ColaboradorRepository(ApplicationContext contexto) : base(contexto)
        {
            this.empresaRepository = new EmpresaRepository(contexto);
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
            dbSet.Add(CollectionToColaborador(collection));
            contexto.SaveChanges();
        }

        private Colaborador CollectionToColaborador(IFormCollection collection)
        {
            return new Colaborador(new Pessoa(), empresaRepository.GetEmpresaId(Convert.ToInt32(collection["Empresa"])) ,Convert.ToDouble(collection["Salario"]),"",collection["Cargo"]);
        }

        public void UpdateColaborador(int id, IFormCollection collection)
        {
            throw new NotImplementedException();
        }

        public void DeletaColaborador(int id)
        {
            throw new NotImplementedException();
        }
    }
}
