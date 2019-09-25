using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities.Validators
{
    public class CustomerValidator:AbstractValidator<CustomerModel>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.LogonName).NotEmpty();
            RuleFor(c => c.Mobile).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Address).NotEmpty();
        }
    }
}
