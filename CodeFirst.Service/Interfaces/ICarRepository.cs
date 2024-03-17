using CodeFirstPart2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Service.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCars();
        bool CreateCar(Car car);
        bool UpdateCar(Car car);
        bool DeleteCar(int carId);
        bool Save();
    }
}
