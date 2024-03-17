using CodeFirstPart2.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Service.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCars();
        Task<Car> GetByIdAsync(int id);
        bool CreateCar(Car car);
        bool UpdateCar(Car car);
        bool DeleteCar(Car car);
        bool Save();
    }
}
