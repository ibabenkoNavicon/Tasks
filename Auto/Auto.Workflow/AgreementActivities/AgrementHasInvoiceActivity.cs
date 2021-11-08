using Auto.Common.Entitis;
using Auto.Common.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;
using System.ComponentModel;

namespace Auto.Workflows.AgreementActivities
{
    public sealed class AgrementHasInvoiceActivity : BaseActivity
    {
        [Input("Agreement")]
        [RequiredArgument]
        [ReferenceTarget("nav_agreement")]
        public InArgument<EntityReference> AgreementReference { get; set; } 
        
        [Output("The agreement has invoice")]
        public OutArgument<bool> IsValid { get; set; }

        protected override void HandlerExecute(CodeActivityContext context)
        {
            _tracing.Trace("Execute AgrementHasInvoice");

            var agreementRef = AgreementReference.Get(context);

            _tracing.Trace($"agreementRef {agreementRef}");

            QueryExpression query = new QueryExpression(nav_invoice.EntityLogicalName)
            {
                ColumnSet = new ColumnSet(false)
            };
            query.Criteria.AddCondition(nav_invoice.Fields.nav_dogovorid, ConditionOperator.Equal, agreementRef.Id);

            IsValid.Set(context, _service.RetrieveMultiple(query).Entities.Count > 0);
        }
    }
}
