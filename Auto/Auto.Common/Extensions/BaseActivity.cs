using Auto.Common.Entitis;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace Auto.Common.Extensions
{
    public abstract class BaseActivity : CodeActivity
    {
        protected ITracingService _tracing;
        protected CrmSvcContext _context;
        protected IOrganizationService _service;
        protected IWorkflowContext _workflowContext;

        protected abstract void HandlerExecute(CodeActivityContext context);

        protected virtual Guid? getUserId() => Guid.Empty;

        protected override void Execute(CodeActivityContext context)
        {
            _tracing = context.GetExtension<ITracingService>();
            _tracing?.Trace("Получен ITracingService");

            _workflowContext = context.GetExtension<IWorkflowContext>();
            _tracing?.Trace("Получен IWorkflowContext");

            _service = context.GetExtension<IOrganizationServiceFactory>().CreateOrganizationService(getUserId());
            _tracing?.Trace("Получен IOrganizationServiceFactory");

            try
            {
                _context = new CrmSvcContext(_service);
                _tracing?.Trace("Создан CrmSvcContext");

                HandlerExecute(context);
            }
            catch (Exception ex)
            {
                throw new InvalidWorkflowException(ex.Message, ex);
            }
        }
    }
}
