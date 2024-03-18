using CodeFirst.Service.Interfaces;
using CodeFirstPart2;
using CodeFirstPart2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Service.Repository
{
    public class EngineRepository : IEngineRepository
    {
        private readonly ApplicationDbContext _context;

        public EngineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateEngine(Engine engine)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEngine(Engine engine)
        {
            throw new NotImplementedException();
        }

        public Task<Engine> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Engine>> GetEngines()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEngine(Engine engine)
        {
            throw new NotImplementedException();
        }
    }
}
