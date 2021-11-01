using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace Auto.Common.Extensions
{
    public abstract class BasePlugin : IPlugin
    {
        const string TARGET = "Target";

        protected abstract void HandlerExecute(IInfoService info);

        protected virtual Guid? getUserId() => Guid.Empty;

        public void Execute(IServiceProvider serviceProvider)
        {
            HandlerInfo info = new HandlerInfo();

            info.Tracing = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            info.Tracing?.Trace("Get TracingService");

            var pluginContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            info.TargetEntity = pluginContext?.InputParameters[TARGET] as Entity;
            if (info.TargetEntity == null)
            {
                var entityRef = (EntityReference)pluginContext?.InputParameters[TARGET];
                info.TargetEntity = info.Service?.Retrieve(entityRef.LogicalName, entityRef.Id,
                    new ColumnSet(true));
            };
            info.Tracing?.Trace($"Get TargetEntity {info.TargetEntity?.LogicalName}");

            var serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            info.Tracing?.Trace("Get IOrganizationServiceFactor");

            info.Service = serviceFactory?.CreateOrganizationService(getUserId());
            info.Tracing?.Trace("Get OrganizationService");

            try
            {
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
