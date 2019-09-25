using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities.Validators
{
    public class UserValidator: AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(c => c.UserName).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Phone).NotEmpty();            
        }
    }
}
