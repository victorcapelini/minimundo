using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VictorCapelini19092018.Models;

namespace VictorCapelini19092018.Repositories
{
    public interface IPessoaRepository
    {
        IList<Pessoa> GetPessoas();
        Pessoa GetPessoaId(int id);
        void UpdatePessoa(int id, IFormCollection collection);
        void CriaPessoa(IFormCollection collection);
        void DeletaPessoa(int id);
    }
}
