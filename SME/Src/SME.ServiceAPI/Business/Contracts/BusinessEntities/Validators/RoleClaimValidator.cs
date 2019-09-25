using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities.Validators
{
    public class RoleClaimValidator:AbstractValidator<RoleClaimModel>
    {
        public RoleClaimValidator()
        {
            RuleFor(c => c.RoleId).NotEmpty();
            RuleFor(c => c.ClaimType).NotEmpty();
            RuleFor(c => c.ClaimValue).NotEmpty();
        }
    }
}
