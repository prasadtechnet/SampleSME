using SME.ServiceAPI.Business.Feature.Email;
using SME.ServiceAPI.Business.Feature.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Feature
{
   public interface IFeatureModule
    {
        IEmailService GetEmailService();
        IPdfModule GetPdfModule();
    }
}
