using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Net;

namespace Auto.Common.Extensions
{
    public abstract class BasePlugin : IPlugin
    {
        const string TARGET_PARAMETR = "Target";

        protected abstract void HandlerExecute(IInfoHandler info);

        protected virtual Guid? getUserId() => Guid.Empty;

        public void Execute(IServiceProvider serviceProvider)
        {
            InfoHandler info = new InfoHandler();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            info.Tracing = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            info.Tracing?.Trace("Get TracingService");

            var pluginContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            info.TargetEntity = pluginContext?.InputParameters[TARGET_PARAMETR] as Entity;

            var serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            info.Tracing?.Trace("Get IOrganizationServiceFactor");

            info.Service = serviceFactory?.CreateOrganizationService(getUserId());
            info.Tracing?.Trace("Get OrganizationService");

            try
            {
                if (info.TargetEntity == null)
                {
                    var entityRef = (EntityReference)pluginContext?.InputParameters[TARGET_PARAMETR];
                    info.TargetEntity = info.Service?.Retrieve(entityRef.LogicalName, entityRef.Id,
                        new ColumnSet(true));
                };
                info.Tracing?.Trace($"Get TargetEntity {info.TargetEntity?.LogicalName}");

                HandlerExecute(info);
            }
            catch (Exception ex)
            {
                info.Tracing?.Trace(ex.ToString());
                throw new InvalidPluginExecutionException(ex.Message);
            }
        }
    }
}
