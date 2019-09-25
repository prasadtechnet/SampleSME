using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities.Validators
{
    public class ServiceCallFeedbackValidator: AbstractValidator<ServiceCallFeedbackModel>
    {
        public ServiceCallFeedbackValidator()
        {
            RuleFor(c => c.ServiceCallId).NotEmpty();
            RuleFor(c => c.Rating).NotEmpty();
            RuleFor(c => c.Remarks).NotEmpty();         
        }
    }
}
