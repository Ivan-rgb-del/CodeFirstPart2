using CodeFirst.Service.Interfaces;
using CodeFirstPart2;
using CodeFirstPart2.Model;
using Microsoft.EntityFrameworkCore;
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
            _context.AddAsync(engine);
            return Save();
        }

        public bool DeleteEngine(Engine engine)
        {
            _context.Remove(engine);
            return Save();
        }

        public async Task<Engine> GetByIdAsync(int id)
        {
            return await _context.Engines.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Engine>> GetEngines()
        {
            return await _context.Engines.ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateEngine(Engine engine)
        {
            _context.Update(engine);
            return Save();
        }
    }
}
