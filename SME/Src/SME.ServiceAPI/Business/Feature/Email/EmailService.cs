using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Feature.Email
{
    public class EmailService:IEmailService
    {
        private EmailConfig _config;
        public EmailService(EmailConfig config)
        {
            _config = config;
        }

        public async Task<bool> SendEmail()
        {
            throw new NotImplementedException();
        }
    }
}
