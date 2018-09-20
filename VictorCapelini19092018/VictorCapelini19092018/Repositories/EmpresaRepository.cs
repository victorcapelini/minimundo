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
            throw new NotImplementedException();
        }

        public void CriaEmpresa(IFormCollection collection)
        {
            string nome, cnpj, razaoSocial;
            collection.TryGetValue("Nome", out nome);

            Empresa empresa = new Empresa( ,"cnpj","rs");
            contexto.Set<Empresa>().Add(empresa);
            contexto.SaveChanges();
        }
    }
}
