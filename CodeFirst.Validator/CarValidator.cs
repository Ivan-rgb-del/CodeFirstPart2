using CodeFirst.Service.Interfaces;
using CodeFirst.Service.Services;
using CodeFirstPart2.Model;
using Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Validator
{
    public class CarValidator : AbstractValidator<Car>
    {
        private readonly CarValidationService _validationService;

        public CarValidator(ICarValidationService validationService)
        {
            _validationService = (CarValidationService?)validationService;
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Brand).Length(0, 20);
            RuleFor(x => x.Model).Length(0, 20);
            RuleFor(x => x.Color).Length(0, 20);
            RuleFor(x => x.Year).InclusiveBetween(2015, 2024);
            RuleFor(x => x.Chassis).InclusiveBetween(0, 100000);
            RuleFor(x => x.Number).InclusiveBetween(0, 100000);
        }

        public async Task<bool> ValidateCarAsync(CreateCarDto carDto)
        {
            return await _validationService.IsModelAvailableAsync(carDto.Model, carDto.Year);
        }
    }
}
