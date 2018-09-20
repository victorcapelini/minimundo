using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VictorCapelini19092018.Contexto;
using VictorCapelini19092018.Models;

namespace VictorCapelini19092018.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly ApplicationContext contexto;

        public EmpresaRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public IList<Empresa> GetEmpresas()
        {
            return contexto.Set<Empresa>().ToList();
        }

        public Empresa GetEmpresaId(int id)
        {
            return contexto.Set<Empresa>().Where(t => t.Id == id).SingleOrDefault();
        }

        public void UpdateEmpresa(int id, IFormCollection collection)
        {
            Empresa empresaAntes = contexto.Set<Empresa>().Where(t => t.Id == id).SingleOrDefault();
            Empresa empresaDepois = CollectionToEmpresa(collection);

            empresaAntes.Altera(empresaDepois.Nome, empresaDepois.CNPJ, empresaDepois.RazaoSocial);
            contexto.Set<Empresa>().Update(empresaAntes);

            contexto.SaveChanges();

        }

        public void CriaEmpresa(IFormCollection collection)
        {
            contexto.Set<Empresa>().Add(CollectionToEmpresa(collection));
            contexto.SaveChanges();
        }

        private static Empresa CollectionToEmpresa(IFormCollection collection)
        {
            return new Empresa(collection["Nome"], collection["cnpj"], collection["RazaoSocial"]);
        }

        public void DeletaEmpresa(int id)
        {
            contexto.Set<Empresa>().Remove(GetEmpresaId(id));
            contexto.SaveChanges();
        }
    }
}
