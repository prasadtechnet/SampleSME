﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities.Validators
{
    public class ClaimValidator: AbstractValidator<ClaimModel>
    {
        public ClaimValidator()
        {
            RuleFor(c => c.Category).NotEmpty();
            RuleFor(c => c.ClaimValue).NotEmpty();
        }
    }
}
