using Auto.Common.Entitis;
using Auto.Common.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Auto.Plugins.Agreement.Handlers
{
    public class AgreementHandler : EntityHandler<nav_agreement>
    {
        public AgreementHandler(IInfoService info)
            : base(info)
        { }

        public void UpdateContactDateForFirstAgrement()
        {
            _tracing.Trace("Выполнение UpdateContactDate");

            var contact = _service.Retrieve(Contact.EntityLogicalName, _targetEntity.nav_contact.Id,
                new ColumnSet(Contact.Fields.Id, Contact.Fields.nav_date)).ToEntity<Contact>();

            if (contact.nav_date != null && contact.nav_date < _targetEntity.nav_date) return;

            contact.nav_date = _targetEntity.nav_date;

            _tracing.Trace($"Обновление contact.nav_date = {contact.Attributes[Contact.Fields.nav_date]}");
            _service.Update(contact);
        }

        public void UpdateFact()
        {
            _tracing.Trace("Выполнение UpdateFact");

            if (_targetEntity.nav_fact == true || 
                _targetEntity.nav_factsumma == null ||
                _targetEntity.nav_fullcreditamount == null ||
                _targetEntity.nav_factsumma.Value != _targetEntity.nav_fullcreditamount.Value) return;

            _targetEntity.nav_fact = true;
            _service.Update(_targetEntity);
        }
    }
}
