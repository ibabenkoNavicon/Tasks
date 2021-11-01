using Auto.Common.Entitis;
using Auto.Common.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Auto.Plugins.Communication.Handler
{
    public class CommunicationHandler : EntityHandler<nav_communication>
    {
        public CommunicationHandler(IInfoHandler info)
            : base(info)
        { }

        public void CheckMainCommunication()
        {
            _tracing.Trace("Выполнение CheckMainCommunication");

            if (_targetEntity.nav_contactid == null || _targetEntity.nav_type == null || _targetEntity.nav_main == null ||
                _targetEntity.nav_type == null || _targetEntity.nav_main == false ) return;

            _tracing.Trace("Выполнение запроса");
            QueryExpression query = new QueryExpression(nav_communication.EntityLogicalName)
            {
                ColumnSet = new ColumnSet(nav_communication.Fields.Id,
                    nav_communication.Fields.nav_type,
                    nav_communication.Fields.nav_email,
                    nav_communication.Fields.nav_phone)
            };
            _tracing.Trace($"nav_contactid = {_targetEntity.nav_contactid.Id} - nav_main = {_targetEntity.nav_main}");
            query.Criteria.AddCondition(nav_communication.Fields.nav_contactid, ConditionOperator.Equal, _targetEntity.nav_contactid.Id);
            query.Criteria.FilterOperator = LogicalOperator.And;
            query.Criteria.AddCondition(nav_communication.Fields.nav_main, ConditionOperator.Equal, _targetEntity.nav_main);
            query.Criteria.FilterOperator = LogicalOperator.And;
            query.Criteria.AddCondition(nav_communication.Fields.nav_type, ConditionOperator.Equal, (int)_targetEntity.nav_type);

            var result = _service.RetrieveMultiple(query);

            _tracing.Trace("Проверка количества записей");
            if (result.Entities.Count == 0) return;

            var communication = result[0].ToEntity<nav_communication>();

            if (_targetEntity.nav_type == nav_communication_nav_type.E_mail)
                throw new InvalidPluginExecutionException("У контакта может быть только один основной E-mail.");

            else if (_targetEntity.nav_type == nav_communication_nav_type.Telefon)
                throw new InvalidPluginExecutionException("У контакта может быть только один основной телефон.");
        }
    }
}
