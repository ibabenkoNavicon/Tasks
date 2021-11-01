﻿using Auto.Common.Extensions;
using Auto.Plugins.Agreement.Handlers;
using System;

namespace Auto.Plugins.Agreement
{
    public sealed class PreAgreementCreate : BasePlugin
    {
        protected override void HandlerExecute(IInfoService info)
        {
            AgreementHandler handler = new AgreementHandler(info);
            handler.UpdateContactDateForFirstAgrement();
        }
    }
}