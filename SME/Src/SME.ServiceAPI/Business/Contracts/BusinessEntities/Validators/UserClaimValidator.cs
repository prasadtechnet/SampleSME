using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities.Validators
{
    public class UserClaimValidator: AbstractValidator<UserClaimModel>
    {
        public UserClaimValidator()
        {        
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.ClaimType).NotEmpty();
            RuleFor(c => c.ClaimValue).NotEmpty();
        }
    }
}
