using Auto.Common.Extensions;
using Auto.Plugins.Agreement.Handlers;

namespace Auto.Plugins.Agreement
{
    public sealed class PostAgreementUpdate : BasePlugin
    {
        protected override void HandlerExecute(IInfoHandler info)
        {
            AgreementHandler handler = new AgreementHandler(info);
            
            handler.UpdateFact();
        }
    }
}