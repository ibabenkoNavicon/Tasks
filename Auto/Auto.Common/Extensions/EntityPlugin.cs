using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace Auto.Common.Extensions
{
    public abstract class EntityPlugin<THandler, TEntity> : IPlugin 
        where THandler : IHandler<TEntity>, new()
        where TEntity : Entity
    {
        const string TARGET = "Target";

        protected abstract void ServiceExecute(THandler service);

        protected virtual Guid? getUserId() => Guid.Empty;

        public void Execute(IServiceProvider serviceProvider)
        {
            var traceService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            traceService?.Trace("Get TracingService");

            var serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            traceService?.Trace("Get IOrganizationServiceFactor");

            var organizationService = serviceFactory?.CreateOrganizationService(getUserId());
            traceService?.Trace("Get OrganizationService");

            var pluginContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            var targetEntity = pluginContext?.InputParameters[TARGET] as Entity;
            if (targetEntity == null)
            {
                var entityRef = (EntityReference)pluginContext?.InputParameters[TARGET];
                targetEntity = organizationService?.
                    Retrieve(entityRef.LogicalName, entityRef.Id, new ColumnSet(true));
            };
            traceService?.Trace($"Get TargetEntity {targetEntity?.LogicalName}");

            try
            {
                var entityService = new THandler()
                {
                    Tracing = traceService ?? throw new ArgumentNullException(nameof(traceService)),
                    Service = organizationService ?? throw new ArgumentNullException(nameof(traceService)),
                    TargetEntity = (targetEntity ?? throw new ArgumentNullException(nameof(traceService))).ToEntity<TEntity>()
                };
                ServiceExecute(entityService);
            }
            catch (Exception ex)
            {
               traceService?.Trace(ex.ToString());
               throw new InvalidPluginExecutionException(ex.Message);
            }
        }
    }
}
