using Microsoft.Xrm.Sdk;
using System;

namespace Auto.Common.Extensions
{
    public abstract class EntityHandler<TEntity> where TEntity : Entity
    {
        protected readonly TEntity _targetEntity;
        protected readonly ITracingService _tracing;
        protected readonly IOrganizationService _service;

        public EntityHandler(IInfoHandler info)
        {
            info?.Tracing?.Trace("Конструктор EntityHandler");
            _tracing = info.Tracing ?? throw new ArgumentNullException(nameof(info.Tracing));
            _service = info.Service ?? throw new ArgumentNullException(nameof(info.Service));
            _targetEntity = (info.TargetEntity ?? throw new ArgumentNullException(nameof(info.TargetEntity))).ToEntity<TEntity>();
        }

        protected void Update(Entity entity) => _service.Update(entity);
    }
}
