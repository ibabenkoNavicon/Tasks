using Auto.Common.Extensions;
using Auto.Plugins.Communication.Handler;

namespace Auto.Plugins.Communication
{
    public sealed class PreCommunicationCreate : BasePlugin
    {
        protected override void HandlerExecute(IInfoService info)
        {
            CommunicationHandler handler = new CommunicationHandler(info);

            handler.CheckMainCommunication();
        }
    }
}