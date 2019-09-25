using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities.Validators
{
    public class ServiceCallProductValidator: AbstractValidator<ServiceCallProductModel>
    {
        public ServiceCallProductValidator()
        {
            RuleFor(c => c.ProductId).NotEmpty();
            RuleFor(c => c.UnitPrice).NotEmpty();
            RuleFor(c => c.UOM).NotEmpty();
            RuleFor(c => c.Quantity).NotEmpty();
        }
    }
}
