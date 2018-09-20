using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using VictorCapelini19092018.Models;

namespace VictorCapelini19092018.Repositories
{
    public interface IEmpresaRepository
    {
        IList<Empresa> GetEmpresas();
        Empresa GetEmpresaId(int id);
        void UpdateEmpresa(int id, IFormCollection collection);
        void CriaEmpresa(IFormCollection collection);
        void DeletaEmpresa(int id);
    }
}