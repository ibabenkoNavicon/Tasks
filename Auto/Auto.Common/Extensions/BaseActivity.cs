using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace Auto.Common.Extensions
{
    public abstract class BaseActivity : CodeActivity
    {
        const string TARGET_PARAMETR = "Target";

        protected ITracingService _tracing;
        protected IOrganizationService _service;
        protected IWorkflowContext _workflowContext;

        protected abstract void HandlerExecute(CodeActivityContext context);

        protected virtual Guid? getUserId() => Guid.Empty;

        protected override void Execute(CodeActivityContext context)
        {
            _tracing = context.GetExtension<ITracingService>();
            _workflowContext = context.GetExtension<IWorkflowContext>();
            _service = context.GetExtension<IOrganizationServiceFactory>().CreateOrganizationService(getUserId());
            var taeget = _workflowContext?.InputParameters[TARGET_PARAMETR];
            _tracing?.Trace($"TARGET_PARAMETR {taeget}");
            try
            {
                HandlerExecute(context);
            }
            catch (Exception ex)
            {
                throw new InvalidWorkflowException(ex.Message, ex);
            }
        }
    }
}
