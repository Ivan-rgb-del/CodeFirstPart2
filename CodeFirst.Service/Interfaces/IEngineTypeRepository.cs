using CodeFirstPart2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Service.Interfaces
{
    public interface IEngineTypeRepository
    {
        Task<IEnumerable<EngineType>> GetEngineTypes();
        Task<EngineType> GetByIdAsync(int id);
        bool CreateEngineType(EngineType engineType);
        bool UpdateEngineType(EngineType engineType);
        bool DeleteEngineType(EngineType engineType);
        bool Save();
    }
}
