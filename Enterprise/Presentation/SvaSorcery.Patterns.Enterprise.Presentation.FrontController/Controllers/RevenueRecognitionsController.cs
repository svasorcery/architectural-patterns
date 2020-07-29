using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SvaSorcery.Patterns.Enterprise.Domain.TransactionScript;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Models;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Queries;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Commands;

namespace SvaSorcery.Patterns.Enterprise.Presentation.FrontController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RevenueRecognitionsController : BaseController
    {
        [HttpGet("contracts/{contractId:long}")]
        public Task<IActionResult> Contracts(long contractId,
            [FromServices] IQueryHandler<FindContract, RevenueContract> handler)
            => SingleAsync(handler, new FindContract(contractId));

        [HttpGet("recognitions")]
        public Task<IActionResult> Recognitions(long contractId, DateTime recognizedAt,
            [FromServices] IQueryHandler<FindRecognitions, IEnumerable<Money>> handler)
            => SingleAsync(handler, new FindRecognitions(contractId, recognizedAt));

        [HttpPost("recognitions")]
        public Task<IActionResult> Recognitions([FromBody] CreateRecognition command,
            [FromServices] ICommandHandler<CreateRecognition> handler)
            => SendAsync(handler, command);

        [HttpGet("revenues")]
        public Task<IActionResult> Revenues(long contractId, DateTime recognizedAt,
            [FromServices] IQueryHandler<GetRecognizedRevenue, Money> handler)
            => SingleAsync(handler, new GetRecognizedRevenue(contractId, recognizedAt));

        [HttpPost("revenues")]
        public Task<IActionResult> Revenues([FromBody] CalculateRevenueRecognitions command,
            [FromServices] ICommandHandler<CalculateRevenueRecognitions> handler)
            => SendAsync(handler, command);
    }
}
