using Auto.Common.Entitis;
using Auto.Common.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace Auto.Workflows.AgreementActivities
{
    class AgreementSetDateOfPaymentScheduleActivity : BaseActivity
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

            _service.Update(new nav_agreement { Id = agreementRef.Id, nav_paymentplandate = DateTime.Now.AddDays(1).Date });
        }
    }
}
