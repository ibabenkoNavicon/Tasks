using Auto.Common.Extensions;
using Auto.Plugins.Invoice.Handlers;

namespace Auto.Plugins.Invoice
{
    public sealed class PreInvoiceCreate : BasePlugin
    {
        protected override void HandlerExecute(IInfoHandler info)
        {
            InvoiceHandler handler = new InvoiceHandler(info);

            handler.CorrectionIvoiceType();
            handler.AddAgreementFactSumma();
        }
    }
}
