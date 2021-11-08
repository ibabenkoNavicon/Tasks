using Auto.Common.Entitis;
using Auto.Common.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Auto.Plugins.Agreement.Handlers
{
    public class AgreementHandler : EntityHandler<nav_agreement>
    {
        public AgreementHandler(IInfoHandler info)
            : base(info)
        { }

        public void UpdateContactDateForFirstAgrement()
        {
            _tracing.Trace("Выполнение UpdateContactDate");

            _tracing.Trace($"_service: {_service}");
            _tracing.Trace($"_targetEntity: {_targetEntity}");
            _tracing.Trace($"_targetEntity.nav_contact: {_targetEntity.nav_contact}");
            _tracing.Trace($"_targetEntity.nav_contact.Id: {_targetEntity.nav_contact.Id}");

            var contact = _service.Retrieve(Contact.EntityLogicalName, _targetEntity.nav_contact.Id,
                new ColumnSet(Contact.Fields.nav_date)).ToEntity<Contact>();

            if (contact == null || contact.nav_date != null && contact.nav_date <= _targetEntity.nav_date) return;

            //contact.Id = _targetEntity.nav_contact.Id;
            //contact.ContactId = _targetEntity.nav_contact.Id;
            //contact.nav_date = _targetEntity.nav_date.Value.Date;

            Entity contact2 = new Entity(Contact.EntityLogicalName);

            _tracing.Trace($"set : {Contact.Fields.Id}");
            contact2[Contact.Fields.Id] = _targetEntity.nav_contact.Id;

            _tracing.Trace($"set : {Contact.Fields.nav_date}");
            contact2[Contact.Fields.nav_date] = _targetEntity.nav_date.Value.Date;

            _tracing.Trace($"set : {Contact.Fields.ContactId}");
            contact2[Contact.Fields.ContactId] = _targetEntity.nav_contact.Id;

            _tracing.Trace($"Обновление contact.nav_date = {contact.Attributes[Contact.Fields.nav_date]}");
            _service.Update(contact2);
        }

        public void UpdateFact()
        {
            _tracing.Trace("Выполнение UpdateFact");

            if (_targetEntity.nav_fact == true || 
                _targetEntity.nav_factsumma == null ||
                _targetEntity.nav_fullcreditamount == null ||
                _targetEntity.nav_factsumma.Value != _targetEntity.nav_fullcreditamount.Value) return;

            _tracing.Trace($"set : {nav_agreement.Fields.nav_fact}");
            _targetEntity.nav_fact = true;
            _service.Update(_targetEntity);
        }
    }
}
