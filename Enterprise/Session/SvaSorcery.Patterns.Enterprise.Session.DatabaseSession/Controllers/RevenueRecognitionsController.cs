using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SvaSorcery.Patterns.Enterprise.Domain.TransactionScript;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Models;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Queries;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Commands;
using SvaSorcery.Patterns.Enterprise.Session.DatabaseSession.Session;
using SvaSorcery.Patterns.Enterprise.Session.DatabaseSession.Persistence;

namespace SvaSorcery.Patterns.Enterprise.Session.DatabaseSession.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RevenueRecognitionsController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IMongoRepository<QueryObject> _repository;

        public RevenueRecognitionsController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("contracts/{contractId:long}")]
        public async Task<IActionResult> Contracts(long contractId,
            [FromServices] IQueryHandler<FindContract, RevenueContract> handler)
        {
            if (!(await _repository.ExistsAsync(x => x.ContractId == contractId)))
                return BadRequest();

            var query = await _repository.GetAsync(x => x.ContractId == contractId);

            return await SingleAsync(handler, new FindContract(query.ContractId));
        }

        [HttpGet("recognitions")]
        public async Task<IActionResult> Recognitions(long contractId, DateTime recognizedAt,
            [FromServices] IQueryHandler<FindRecognitions, IEnumerable<Money>> handler)
        {
            if (!(await _repository.ExistsAsync(x => x.ContractId == contractId)))
                return BadRequest();

            var query = await _repository.GetAsync(x => x.ContractId == contractId && x.RecognizedAt == recognizedAt);

            return await SingleAsync(handler, new FindRecognitions(query.ContractId, query.RecognizedAt.Value));
        }

        [HttpPost("recognitions")]
        public async Task<IActionResult> Recognitions([FromBody] CreateRecognition command,
            [FromServices] ICommandHandler<CreateRecognition> handler)
        {
            await _repository.CreateAsync(new QueryObject(command.ContractId, command.RecognizedAt));
            return await SendAsync(handler, command);
        }

        [HttpGet("revenues")]
        public async Task<IActionResult> Revenues(long contractId, DateTime recognizedAt,
            [FromServices] IQueryHandler<GetRecognizedRevenue, Money> handler)
        {
            if (!(await _repository.ExistsAsync(x => x.ContractId == contractId)))
                return BadRequest();

            var query = await _repository.GetAsync(x => x.ContractId == contractId && x.RecognizedAt == recognizedAt);

            return await SingleAsync(handler, new GetRecognizedRevenue(query.ContractId, query.RecognizedAt.Value));
        }

        [HttpPost("revenues")]
        public Task<IActionResult> Revenues([FromBody] CalculateRevenueRecognitions command,
            [FromServices] ICommandHandler<CalculateRevenueRecognitions> handler)
            => SendAsync(handler, command);
    }
}
