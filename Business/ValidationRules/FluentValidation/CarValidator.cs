using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(5);
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Günlük ücret 0'dan büyük olmalı.");
            RuleFor(c => c.DailyPrice).NotEmpty();
        }
    }
}
