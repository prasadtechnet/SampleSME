using SME.ServiceAPI.Business.Feature.Pdf.SCConfirm;
using SME.ServiceAPI.Business.Feature.Pdf.SCInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Feature.Pdf
{
    public interface IPdfModule
    {
         ISCConfirm GetPdfConfirm();
         ISCInvoice GetPdfInvoice();
    }
}
