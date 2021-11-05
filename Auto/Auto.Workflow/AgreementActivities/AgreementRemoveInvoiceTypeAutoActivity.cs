using Auto.Common.Entitis;
using Auto.Common.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace Auto.Workflows.AgreementActivities
{
    class AgreementRemoveInvoiceTypeAutoActivity : BaseActivity
    {
        [Input("Agreement")]
        [RequiredArgument]
        [ReferenceTarget("nav_agreement")]
        public InArgument<EntityReference> AgreementReference { get; set; }

        protected override void HandlerExecute(CodeActivityContext context)
        {
            var agreementRef = AgreementReference.Get(context);

            QueryExpression query = new QueryExpression(nav_invoice.EntityLogicalName)
            {
                ColumnSet = new ColumnSet(false)
            };
            query.Criteria.AddCondition(nav_invoice.Fields.nav_dogovorid, ConditionOperator.Equal, agreementRef.Id);
            query.Criteria.FilterOperator = LogicalOperator.And;
            query.Criteria.AddCondition(nav_invoice.Fields.nav_type, ConditionOperator.Equal, (int)nav_invoice_nav_type.Ruchnoe_sozdanie);

            foreach (var invoice in _service.RetrieveMultiple(query).Entities)
            {
                _service.Delete(nav_invoice.EntityLogicalName, invoice.Id);
            }
        }
    }
}
