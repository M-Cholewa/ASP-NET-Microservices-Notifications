using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using Notify.Contracts.Shared;
using Notify.Infrastructure.Metrics;
using System.Net;

namespace Notify.Services.Sender.Controllers
{
    [ApiController]
    [Route("services/sender/v1/metrics")]
    public class MetricsController : ControllerBase
    {

        /// <summary>
        ///  Get health status.
        /// </summary>
        /// <returns>String health status</returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult GetHealth()
        {
            return Ok("Helfi");
        }
    }
}
