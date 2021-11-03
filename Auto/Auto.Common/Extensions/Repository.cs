using Microsoft.Xrm.Sdk;
using System;

namespace Auto.Common.Extensions
{
    public class Repository<TEntity> where TEntity : Entity
    {
        private TEntity _entity;
        private IOrganizationService _service;

        public Repository(IOrganizationService service)
        {
            _service = service;
        }

        //public int GetCount(Guid guid)
        //{
        //    RelationshipQueryCollection 
        //}
    }
}
