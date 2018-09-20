using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public void CriaEmpresa()
        {

        }
    }
}
