using Auto.Common.Entitis;
using Auto.Common.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace Auto.Plugins.Invoice.Handlers
{
    public class InvoiceHandler : EntityHandler<nav_invoice>
    {
        public InvoiceHandler(IInfoService info)
            : base(info)
        { }

        public void CorrectionIvoiceType()
        {
            _tracing.Trace("Выполнение CorrectionIvoiceType");
            if (_targetEntity.nav_type == null)
                _targetEntity.nav_type = nav_invoice_nav_type.Ruchnoe_sozdanie;
        }

        public void AddAgreementFactSumma()
        {
            _tracing.Trace("Выполнение AddAgreementFactSumma");
            if (_targetEntity.nav_fact.GetValueOrDefault() == false) return;

            RecalcAgreementFactSumma(_targetEntity.nav_dogovorid.Id, _targetEntity.nav_amount);
        }

        public void SubtractAgreementFactSumma()
        {
            _tracing.Trace("Выполнение SubtractAgreementFactSumma");
            if (_targetEntity.nav_fact.GetValueOrDefault() == false) return;

            RecalcAgreementFactSumma(_targetEntity.nav_dogovorid.Id, new Money(-_targetEntity.nav_amount.Value));
        }

        public void UpdateAgreementFactSumma()
        {
            _tracing.Trace("Выполнение UpdateAgreementFactSumma");
            var invoice = _service.Retrieve(nav_invoice.EntityLogicalName, _targetEntity.Id,
                new ColumnSet(nav_invoice.Fields.nav_fact, nav_invoice.Fields.nav_amount)).ToEntity<nav_invoice>();

            if (invoice.nav_fact.GetValueOrDefault() == _targetEntity.nav_fact.GetValueOrDefault()) return;

            if (_targetEntity.nav_fact.GetValueOrDefault() == true)
                RecalcAgreementFactSumma(_targetEntity.nav_dogovorid.Id, new Money(_targetEntity.nav_amount.Value));
            else if (invoice.nav_fact.GetValueOrDefault() == true)
                RecalcAgreementFactSumma(_targetEntity.nav_dogovorid.Id, new Money(-invoice.nav_amount.Value));
        }

        public void CheckAgreementAmountAndSumma()
        {
            _tracing.Trace("Выполнение CheckAgreementAmountAndSumma");
            if (IsAgreementAmountAndSumma() == false)
                throw new InvalidPluginExecutionException("Сумма оплаты превышает сумму договора!!!");

            _targetEntity.nav_paydate = DateTime.Now;
        }

        public bool IsAgreementAmountAndSumma()
        {
            _tracing.Trace("Выполнение IsAgreementAmountAndSumma");
            nav_agreement agreement = _service.Retrieve(nav_agreement.EntityLogicalName, _targetEntity.nav_dogovorid.Id,
                   new ColumnSet(nav_agreement.Fields.Id, nav_agreement.Fields.nav_creditid, nav_agreement.Fields.nav_summa,
                   nav_agreement.Fields.nav_fullcreditamount, nav_agreement.Fields.nav_factsumma)).
                   ToEntity<nav_agreement>();

            if (nav_agreement.Fields.nav_creditid == null)
            {
                if (agreement.nav_factsumma == null || agreement.nav_summa.Value >= agreement.nav_factsumma.Value)
                    return true;
            }
            else if (agreement.nav_factsumma == null || agreement.nav_fullcreditamount == null || 
                    agreement.nav_factsumma.Value >= agreement.nav_fullcreditamount.Value)
                    return true;

            return false;
        }

        protected void RecalcAgreementFactSumma(Guid dogovorId, Money summa)
        {
            _tracing.Trace("Выполнение RecalcAgreementFactSumma");
            nav_agreement agreement = _service.Retrieve(nav_agreement.EntityLogicalName, dogovorId,
                    new ColumnSet(nav_agreement.Fields.Id, nav_agreement.Fields.nav_factsumma)).
                    ToEntity<nav_agreement>();

            if (agreement.nav_factsumma == null)
                agreement.nav_factsumma = summa;
            else
                agreement.nav_factsumma.Value += summa.Value;

            _service.Update(agreement);
        }
    }
}
