using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTestApi.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly DatabaseCalls _databaseCalls;

        public TestController(ILogger<TestController> logger, DatabaseCalls databaseCalls)
        {
            _logger = logger;
            _databaseCalls = databaseCalls;
        }

        [HttpGet("tab1")]
        public async Task<IActionResult> GetDataForTab1(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _databaseCalls.GetData(cancellationToken).ConfigureAwait(false);
            await Task.Delay(3000,cancellationToken);
            return Ok("Result Return with number of rows" + result.Count());
        }

        [HttpGet("tab2")]
        public async Task<IActionResult> GetDataForTab2(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _databaseCalls.GetData(cancellationToken).ConfigureAwait(false);
            return Ok("Result Return with number of rows" + result.Count());
        }
    }
}
