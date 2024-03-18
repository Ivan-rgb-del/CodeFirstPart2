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
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateCar(Car car)
        {
            _context.AddAsync(car);
            return Save();
        }

        public bool DeleteCar(Car car)
        {
            _context.Remove(car);
            return Save();
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        public bool UpdateCar(Car car)
        {
            _context.Update(car);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
