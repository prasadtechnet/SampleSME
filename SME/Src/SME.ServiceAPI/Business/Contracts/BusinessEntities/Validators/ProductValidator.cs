using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities.Validators
{
    public class ProductValidator:AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(c => c.Name).NotEmpty();           
            RuleFor(c => c.Price).NotEmpty().GreaterThan(0);
        }
    }
}
