using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Common.Extensions
{
    public class InfoHandler : IInfoHandler
    {
        public ITracingService Tracing { get; set; }
        public IOrganizationService Service { get; set; }
        public Entity TargetEntity { get; set; }
    }
}
