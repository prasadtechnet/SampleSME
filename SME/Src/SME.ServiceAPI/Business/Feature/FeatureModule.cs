using SME.ServiceAPI.Business.Feature.Email;
using SME.ServiceAPI.Business.Feature.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Feature
{
    public class FeatureModule:IFeatureModule
    {
        private IEmailService _emailService;
        private IPdfModule _pdfModule;
        public FeatureModule(IEmailService emailService,IPdfModule pdfModule)
        {
            _emailService = emailService;
            _pdfModule = pdfModule;
        }

        public IEmailService GetEmailService()
        {
            return _emailService;
        }

        public IPdfModule GetPdfModule()
        {
            return _pdfModule;
        }
    }
}
