﻿using Auto.Common.Extensions;
using Auto.Plugins.Invoice.Handlers;

namespace Auto.Plugins.Invoice
{
    public sealed class PostInvoiceCreate : BasePlugin
    {
        protected override void HandlerExecute(IInfoService info)
        {
            InvoiceHandler handler = new InvoiceHandler(info);

            handler.CheckAgreementAmountAndSumma();
        }
    }
}