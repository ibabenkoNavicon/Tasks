using Microsoft.Xrm.Sdk;
using System;

namespace Auto.Common.Extensions
{
    public abstract class EntityHandler<TEntity> where TEntity : Entity
    {
        protected readonly TEntity _targetEntity;
        protected readonly ITracingService _tracing;
        protected readonly IOrganizationService _service;

        public EntityHandler(IInfoService info)
        {
            _service = info.Service ?? throw new ArgumentNullException(nameof(info.Service));
            _tracing = info.Tracing ?? throw new ArgumentNullException(nameof(info.Tracing));
            _targetEntity = (info.TargetEntity ?? throw new ArgumentNullException(nameof(info.TargetEntity))).ToEntity<TEntity>();
        }

        protected void Update(Entity entity) => _service.Update(entity);

        //Repository<T> GetRepository<T>(T entity) where T : Entity => new Repository<T>(OrganizationService, entity.LogicalName);

        //public T Retrieve(Guid id, ColumnSet columns) where T : Entity
        //{
        //    EntityLogicalName = entityLogicalName ?? throw new ArgumentNullException();
        //    return (T)OrganizationService.Retrieve(EntityLogicalName, id, columns);
        //}

        //public EntityCollection GetMultiple(QueryExpression query)
        //{
        //    query.EntityName = EntityLogicalName;
        //    return Service.RetrieveMultiple(query);
        //}

        //public void Update(T entity)
        //{
        //    Service.Update(entity);
        //}

        //public void Delete(Guid id)
        //{
        //    Service.Delete(EntityLogicalName, id);
        //}

        //public Guid Insert(T entity)
        //{
        //    return Service.Create(entity);
        //}
    }
}
