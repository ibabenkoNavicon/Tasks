using Auto.Common.Entitis;
using Auto.Common.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.ComponentModel;

namespace Auto.Workflows.AgreementActivities
{
    public sealed class AgreementSetDateOfPaymentScheduleActivity : BaseActivity
    {
        [Input("Agreement")]
        [RequiredArgument]
        [ReferenceTarget("nav_agreement")]
        public InArgument<EntityReference> AgreementReference { get; set; }

        [Output("The agreement has invoice")]
        public OutArgument<bool> IsValid { get; set; }

        protected override void HandlerExecute(CodeActivityContext context)
        {
            var agreementRef = AgreementReference.Get(context);

            DateTime val = DateTime.Now.AddDays(1).Date;

            _tracing?.Trace("Изменение даты nav_agreement");

            var agreement = new Entity(nav_agreement.EntityLogicalName);
            agreement[nav_agreement.Fields.Id] = agreementRef.Id;
            agreement[nav_agreement.Fields.nav_paymentplandate] = DateTime.Now.AddDays(1).Date;

            _service.Update(agreement);
        }
    }
}
