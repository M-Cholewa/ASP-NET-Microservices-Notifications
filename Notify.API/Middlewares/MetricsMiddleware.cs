using Notify.Infrastructure.Metrics;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Notify.API.Middlewares
{
    public class MetricsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMetricsService _metricsService;

        public MetricsMiddleware(RequestDelegate next, IMetricsService metricsService)
        {
            _next = next;
            _metricsService = metricsService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _metricsService.IncrementErrorCount(ex.GetType().Name);
                throw; // pass further
            }
        }
    }
}
