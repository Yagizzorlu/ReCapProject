﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.ModelId).NotEmpty();
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            //RuleFor(c=> c.CarName).Must(StartWithA).WithMessage("Ürünler A Harfi ile başlamalı);

            //private bool StartWithA(string arg)             
            //{
            //    return arg.StartsWith("A");                 
            //}

        }
    }
}
