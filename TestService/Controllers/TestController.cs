using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Queries.GetEcho;
using TestApplication.Queries.GetRegisteredVaccineCount;
using ViennaNET.Mediator;

namespace TestService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("echo")]
        public async Task<string> Echo(string message)
        {
            return await _mediator.SendMessageAsync<GetEchoQuery, string>(
                new GetEchoQuery() {Echo = message});
        }

        [AllowAnonymous]
        [HttpGet("vaccine_count")]
        public async Task<int> VaccineCount()
        {
            return await _mediator.SendMessageAsync<GetRegisteredVaccineCountQuery, int>(
                new GetRegisteredVaccineCountQuery());
        }
    }
}
