using Auto.Common.Entitis;
using Auto.Common.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Linq;

namespace Auto.Workflows.AgreementActivities
{
    class AgreementCreatePaymentScheduleActivity : BaseActivity
    {
        [Input("Agreement")]
        [RequiredArgument]
        [ReferenceTarget("nav_agreement")]
        public InArgument<EntityReference> AgreementReference { get; set; }

        protected override void HandlerExecute(CodeActivityContext context)
        {
            var agreementRef = AgreementReference.Get(context);

            var agreementEntity = _service.Retrieve(nav_agreement.EntityLogicalName, agreementRef.Id, new ColumnSet(true))
                .ToEntity<nav_agreement>();

            if (agreementEntity.nav_summa == null) throw new Exception("Сумма договора не указана");

            var monthCount = agreementEntity.nav_creditperiod.GetValueOrDefault(0) * 12;
            if (monthCount == 0) throw new Exception("Нет срока кредита");

            var invoiceSumma = agreementEntity.nav_summa.Value / monthCount;

            for (var i = 0; i < monthCount; i++)
            {
                _service.Create(new nav_invoice
                {
                    nav_name = $"Счет №{i + 1} по договору №{agreementEntity.nav_name}",
                    nav_dogovorid = agreementRef,
                    nav_date = DateTime.Now,
                    nav_type = nav_invoice_nav_type.Avtomaticheskoe_sozdanie,
                    nav_fact = false,
                    nav_amount = new Money(invoiceSumma)
                });
            }
        }
    }
}
