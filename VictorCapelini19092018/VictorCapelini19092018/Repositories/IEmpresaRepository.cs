using System.Collections.Generic;
using VictorCapelini19092018.Models;

namespace VictorCapelini19092018.Repositories
{
    public interface IEmpresaRepository
    {
        IList<Empresa> GetEmpresas();
        Empresa GetEmpresaId(int id);
    }
}