using Auto.Common.Entitis;
using Auto.Common.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.ComponentModel;
using System.Linq;

namespace Auto.Workflows.AgreementActivities
{
    public sealed class AgreementCreatePaymentScheduleActivity : BaseActivity
    {
        [Input("Agreement")]
        [RequiredArgument]
        [ReferenceTarget("nav_agreement")]
        public InArgument<EntityReference> AgreementReference { get; set; }

        protected override void HandlerExecute(CodeActivityContext context)
        {
            var agreementRef = AgreementReference.Get(context);

            var agreement = _service.Retrieve(nav_agreement.EntityLogicalName, agreementRef.Id, new ColumnSet(true))
                .ToEntity<nav_agreement>();

            //var agreement = _context.nav_agreementSet.Single(x => x.Id == agreementRef.Id);

            if (agreement.nav_summa == null) throw new Exception("Сумма договора не указана");

            if (agreement.nav_creditid is null) throw new Exception("Не выбрана кредитная программа");

            var monthCount = agreement.nav_creditperiod.GetValueOrDefault(0) * 12;
            if (monthCount == 0) throw new Exception("Нет срока кредита");

            var invoiceSumma = agreement.nav_summa.Value / monthCount;

            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).Date;
            for (var i = 0; i < monthCount; i++)
            {
                //var invoice = new nav_invoice()
                //{
                //    nav_name = $"Счет №{i + 1} по договору №{agreement.nav_name}",
                //    nav_dogovorid = agreementRef,
                //    nav_date = date.AddMonths(i).Date,
                //    nav_type = nav_invoice_nav_type.Avtomaticheskoe_sozdanie,
                //    nav_fact = false,
                //    nav_amount = new Money(invoiceSumma)
                //};
                //_context.AddObject(invoice);

                _tracing?.Trace("Создание nav_invoice");

                var invoice = new Entity(nav_invoice.EntityLogicalName);
                invoice[nav_invoice.Fields.nav_name] = $"Счет №{i + 1} по договору № {agreement.nav_name}";
                invoice[nav_invoice.Fields.nav_date] = date.AddMonths(i).Date;
                invoice[nav_invoice.Fields.nav_dogovorid] = agreementRef;
                invoice[nav_invoice.Fields.nav_type] = new OptionSetValue((int)nav_invoice_nav_type.Avtomaticheskoe_sozdanie);
                invoice[nav_invoice.Fields.nav_fact] = false;
                invoice[nav_invoice.Fields.nav_amount] = new Money(invoiceSumma);

                _service.Create(invoice);

                //_service.Create(new nav_invoice
                //{
                //    nav_name = $"Счет №{i + 1} по договору №{agreement.nav_name}",
                //    nav_date = date.AddMonths(i).Date,
                //    nav_dogovorid = agreementRef,
                //    nav_fact = false,
                //    nav_type = nav_invoice_nav_type.Avtomaticheskoe_sozdanie,
                //    nav_amount = new Money(invoiceSumma)
                //});
            }
            //_context.SaveChanges();
        }
    }
}
