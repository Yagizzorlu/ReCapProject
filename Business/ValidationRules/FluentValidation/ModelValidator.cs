using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(m=> m.ModelName).NotEmpty();
            RuleFor(m=> m.ModelId).NotEmpty();
            RuleFor(m=> m.ModelYear).NotEmpty();
        }
    }
}
