using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsGeneratorApp.Areas.Parts.Commands
{
    public class AddPartCommandValidator : AbstractValidator<AddPartCommand>
    {
        public AddPartCommandValidator()
        {
            RuleFor(o => o.CategoryCode).NotNull();
            RuleFor(o => o.Country).NotNull();
            RuleFor(o => o.FactoryCode).NotNull();
        }
    }
}
