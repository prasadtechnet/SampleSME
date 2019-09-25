using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Feature.Pdf.SCConfirm
{
    public interface ISCConfirm
    {
        Task<byte[]> GeneratePdf(SCConfirmModel objSCInvoiceModel);
    }
}
