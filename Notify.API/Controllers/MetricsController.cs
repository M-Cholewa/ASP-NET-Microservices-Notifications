using Ardalis.GuardClauses;
using Notify.Contracts.Shared;
using Notify.Infrastructure.Metrics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Notify.API.Controllers
{
    [ApiController]
    [Route("api/v1/metrics")]
    public class MetricsController(IMetricsService metricsService) : ControllerBase
    {
        private readonly IMetricsService _metricsService = Guard.Against.Null(metricsService, nameof(metricsService));


        /// <summary>
        ///  Get metrics for errors.
        /// </summary>
        /// <returns>Metrics for errors.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(MetricsDto), (int)HttpStatusCode.OK)]
        public IActionResult GetMetrics()
        {
            var metrics = _metricsService.GetErrorMetrics();
            return Ok(metrics);
        }
    }
}
