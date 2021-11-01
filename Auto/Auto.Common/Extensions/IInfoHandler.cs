using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Common.Extensions
{
    public interface IInfoHandler
    {
        ITracingService Tracing { get; }
        IOrganizationService Service { get; }
        Entity TargetEntity { get; }
    }
}
