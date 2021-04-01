using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(c => c.CardNumber).NotEmpty();
            RuleFor(c => c.CardNumber).MinimumLength(11);
            RuleFor(c => c.Ccv).NotEmpty();
            RuleFor(c => c.Ccv).GreaterThanOrEqualTo(3);
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.ExpirationDate).NotEmpty();
        }
    }
}
