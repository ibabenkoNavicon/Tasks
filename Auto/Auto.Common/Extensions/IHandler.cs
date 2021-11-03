using Microsoft.Xrm.Sdk;

namespace Auto.Common.Extensions
{
    public interface IHandler<in TEntity> where TEntity : Entity
    {
        ITracingService Tracing { set; }
        IOrganizationService Service { set; }
        TEntity TargetEntity { set; }
    }
}
