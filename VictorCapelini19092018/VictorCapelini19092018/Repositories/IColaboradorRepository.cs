using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VictorCapelini19092018.Models;

namespace VictorCapelini19092018.Repositories
{
    public interface IColaboradorRepository
    {
        IList<Colaborador> GetColaboradores();
        Colaborador GetColaboradorId(int id);
    }
}
