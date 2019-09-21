using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Feature.Pdf.SCInvoice
{
    public interface ISCInvoice
    {
        byte[] GeneratePdf(SCInvoiceModel objSCInvoiceModel, ref StringBuilder sbLog);
    }
}
