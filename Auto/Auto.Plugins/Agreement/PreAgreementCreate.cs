using Auto.Common.Extensions;
using Auto.Plugins.Agreement.Handlers;
using System;

namespace Auto.Plugins.Agreement
{
    public sealed class PreAgreementCreate : BasePlugin
    {
        protected override Guid? getUserId() => null;

        protected override void HandlerExecute(IInfoHandler info)
        {
            AgreementHandler handler = new AgreementHandler(info);
            handler.UpdateContactDateForFirstAgrement();
        }
    }
}