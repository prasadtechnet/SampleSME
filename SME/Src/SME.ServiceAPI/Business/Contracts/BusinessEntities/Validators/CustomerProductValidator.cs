using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities.Validators
{
    public class CustomerProductValidator: AbstractValidator<CustomerProductModel>
    {
        public CustomerProductValidator()
        {
            RuleFor(c => c.ProductId).NotEmpty();
            RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c.PurchaseDate).NotEmpty();
            RuleFor(c => c.SerialNo).NotEmpty();
            RuleFor(c => c.Price).NotEmpty();
        }
    }
}
