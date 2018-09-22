using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VictorCapelini19092018.Contexto;
using VictorCapelini19092018.Models;

namespace VictorCapelini19092018.Repositories
{
    public class EmpresaRepository : BaseRepository<Empresa>,IEmpresaRepository
    {
        public EmpresaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Empresa> GetEmpresas()
        {
            return dbSet.ToList();
        }

        public Empresa GetEmpresaId(int id)
        {
            return dbSet.Where(t => t.Id == id).SingleOrDefault();
        }


        public void CriaEmpresa(IFormCollection collection)
        {
            dbSet.Add(CollectionToEmpresa(collection));
            contexto.SaveChanges();
        }

        private static Empresa CollectionToEmpresa(IFormCollection collection)
        {
            return new Empresa(collection["Nome"], collection["cnpj"], collection["RazaoSocial"]);
        }

        public void DeletaEmpresa(int id)
        {
            dbSet.Remove(GetEmpresaId(id));
            contexto.SaveChanges();
        }

        public void UpdateEmpresa(int id, IFormCollection collection)
        {
            Empresa empresaAntes = dbSet.Where(t => t.Id == id).SingleOrDefault();
            Empresa empresaDepois = CollectionToEmpresa(collection);

            empresaAntes.Altera(empresaDepois.Nome, empresaDepois.CNPJ, empresaDepois.RazaoSocial);
            dbSet.Update(empresaAntes);

            contexto.SaveChanges();

        }
    }
}
