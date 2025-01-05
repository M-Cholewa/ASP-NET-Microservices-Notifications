#if DEBUG
using Notify.Domain.SeedWork;
using Microsoft.AspNetCore.Mvc;

namespace Notify.API.Controllers;

[Route("api/tests")]
[ApiController]
public class TestController : Controller
{
    [HttpPost("throw-business-rule-validation-exception")]
    public IActionResult ThrowBusinessRuleValidationException()
    {
        throw new BusinessRuleValidationException(new SampleBusinessRule());
    }

    private class SampleBusinessRule : IBusinessRule
    {
        public string Message => $"{nameof(SampleBusinessRule)} is broken.";

        public bool IsBroken()
        {
            return true;
        }
    }
}
#endif