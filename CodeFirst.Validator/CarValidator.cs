using CodeFirst.Service.Interfaces;
using CodeFirst.Service.Services;
using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Validator
{
    public class CarValidator    {
        private readonly CarValidationService _validationService;

        public CarValidator(ICarValidationService validationService)
        {
            _validationService = (CarValidationService?)validationService;
        }

        public async Task<bool> ValidateCarAsync(CreateCarDto carDto)
        {
            return await _validationService.IsModelAvailableAsync(carDto.Model, carDto.Year);
        }
    }
}
