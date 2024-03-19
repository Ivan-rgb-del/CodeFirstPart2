using CodeFirstPart2.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Validator
{
    public class EngineValidator : AbstractValidator<Engine>
    {
        public EngineValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Year).InclusiveBetween(2015, 2024);
            RuleFor(x => x.MyProperty).Length(0, 15);
            RuleFor(x => x.SerialNumber).InclusiveBetween(0, 1000);
            RuleFor(x => x.Type).Length(0, 15);
        }
    }
}
