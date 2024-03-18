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
    public class EngineTypeRepository : IEngineTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public EngineTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateEngineType(EngineType engineType)
        {
            _context.AddAsync(engineType);
            return Save();
        }

        public bool DeleteEngineType(EngineType engineType)
        {
            _context.Remove(engineType);
            return Save();
        }

        public async Task<EngineType> GetByIdAsync(int id)
        {
            return await _context.EngineTypes.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<EngineType>> GetEngineTypes()
        {
            return await _context.EngineTypes.ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateEngineType(EngineType engineType)
        {
            _context.Update(engineType);
            return Save();
        }
    }
}
