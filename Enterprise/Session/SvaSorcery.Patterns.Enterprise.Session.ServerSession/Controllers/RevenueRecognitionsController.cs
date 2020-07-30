using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SvaSorcery.Patterns.Enterprise.Domain.TransactionScript;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Models;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Queries;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Commands;
using SvaSorcery.Patterns.Enterprise.Session.ServerSession.Session;

namespace SvaSorcery.Patterns.Enterprise.Session.ServerSession.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RevenueRecognitionsController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected ISession Session => _httpContextAccessor.HttpContext.Session;

        public RevenueRecognitionsController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("contracts/{contractId:long}")]
        public async Task<IActionResult> Contracts([FromServices] IQueryHandler<FindContract, RevenueContract> handler)
        {
            if (!Session.TryGetValue(out QueryObject query))
                return BadRequest();

            return await SingleAsync(handler, new FindContract(query.ContractId));
        }

        [HttpGet("recognitions")]
        public async Task<IActionResult> Recognitions([FromServices] IQueryHandler<FindRecognitions, IEnumerable<Money>> handler)
        {
            if (!Session.TryGetValue(out QueryObject query))
                return BadRequest();

            return await SingleAsync(handler, new FindRecognitions(query.ContractId, query.RecognizedAt.Value));
        }

        [HttpPost("recognitions")]
        public async Task<IActionResult> Recognitions([FromBody] CreateRecognition command,
            [FromServices] ICommandHandler<CreateRecognition> handler)
        {
            Session.Set(new QueryObject(command.ContractId, command.RecognizedAt));
            return await SendAsync(handler, command);
        }

        [HttpGet("revenues")]
        public async Task<IActionResult> Revenues([FromServices] IQueryHandler<GetRecognizedRevenue, Money> handler)
        {
            if (!Session.TryGetValue(out QueryObject query))
                return BadRequest();

            return await SingleAsync(handler, new GetRecognizedRevenue(query.ContractId, query.RecognizedAt.Value));
        }

        [HttpPost("revenues")]
        public Task<IActionResult> Revenues([FromBody] CalculateRevenueRecognitions command,
            [FromServices] ICommandHandler<CalculateRevenueRecognitions> handler)
            => SendAsync(handler, command);
    }
}
