using Notify.Contracts.Shared;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Infrastructure.Metrics
{
    public class MetricsService : IMetricsService
    {
        private readonly ConcurrentDictionary<string, int> _errorCounts = new();

        public void IncrementErrorCount(string errorType)
        {
            _errorCounts.AddOrUpdate(errorType, 1, (_, currentCount) => currentCount + 1);
        }

        public MetricsDto GetErrorMetrics()
        {
            return new MetricsDto(_errorCounts.ToDictionary());
        }
    }
}
