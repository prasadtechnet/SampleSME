using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities.Validators
{
    public class ServiceCallHistoryValidator: AbstractValidator<ServiceCallHistoryModel>
    {
        public ServiceCallHistoryValidator()
        {
            RuleFor(c => c.ServiceCallId).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();           
        }
    }
}
