﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Feature.Email
{
    public interface IEmailService
    {
        Task<bool> SendEmail();
    }
}
