using SME.ServiceAPI.Business.Feature.Pdf.SCConfirm;
using SME.ServiceAPI.Business.Feature.Pdf.SCInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Feature.Pdf
{
    public class PdfModule:IPdfModule
    {
        private ISCConfirm _pdfConfirm;
        private ISCInvoice _pdfInvoice;
        public PdfModule(ISCConfirm pdfConfirm,ISCInvoice pdfInvoice)
        {
            _pdfConfirm = pdfConfirm;
            _pdfInvoice = pdfInvoice;
        }

        public ISCConfirm GetPdfConfirm()
        {
            return _pdfConfirm;
        }

        public ISCInvoice GetPdfInvoice()
        {
            return _pdfInvoice;
        }
    }
}
