using Microsoft.Xrm.Sdk;
using System;

namespace Auto.Common.Extensions
{
    public class Repository<TEntity> where TEntity : Entity
    {
        //private TEntity _entity;
        private IOrganizationService _service;


        public Repository(IOrganizationService service, string entityLogicalName)
        {
            _service = service;
            //_entity = entity;
        }
    }
}
