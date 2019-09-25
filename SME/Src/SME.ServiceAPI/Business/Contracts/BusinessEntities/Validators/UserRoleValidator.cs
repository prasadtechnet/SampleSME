﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities.Validators
{
    public class UserRoleValidator: AbstractValidator<UserRoleModel>
    {
        public UserRoleValidator()
        {
            RuleFor(c => c.RoleId).NotEmpty();
            RuleFor(c => c.UserId).NotEmpty();         
        }
    }
}
