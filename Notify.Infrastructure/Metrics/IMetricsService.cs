using Notify.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Infrastructure.Metrics
{
    public interface IMetricsService
    {
        void IncrementErrorCount(string errorType);
        MetricsDto GetErrorMetrics();
    }
}
