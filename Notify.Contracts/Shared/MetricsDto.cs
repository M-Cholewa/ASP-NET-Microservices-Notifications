using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Contracts.Shared
{
    public class MetricsDto
    {
        public Dictionary<string, int> ErrorCount { get; set; }

        public MetricsDto(Dictionary<string, int> errorCount)
        {
            ErrorCount = errorCount ?? throw new ArgumentNullException(nameof(errorCount));
        }
    }
}
