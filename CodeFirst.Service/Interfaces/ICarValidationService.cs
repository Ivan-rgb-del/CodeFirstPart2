using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Service.Interfaces
{
    public interface ICarValidationService
    {
        Task<bool> IsModelAvailableAsync(string model, int year);
    }
}
