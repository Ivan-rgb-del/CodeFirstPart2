using CodeFirstPart2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Service.Interfaces
{
    public interface IEngineRepository
    {
        Task<IEnumerable<Engine>> GetEngines();
        Task<Engine> GetByIdAsync(int id);
        bool CreateEngine(Engine engine);
        bool UpdateEngine(Engine engine);
        bool DeleteEngine(Engine engine);
        bool Save();
    }
}
