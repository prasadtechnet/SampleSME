using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities.Validators
{
    public class ServiceCallValidator: AbstractValidator<ServiceCallModel>
    {
        public ServiceCallValidator()
        {
            RuleFor(c => c.BranchId).NotEmpty();
            RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.Products).NotEmpty().Must(x=>x.Count>0);
        }
    }
}
