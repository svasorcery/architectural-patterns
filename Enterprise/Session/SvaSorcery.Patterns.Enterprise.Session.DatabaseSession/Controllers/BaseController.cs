using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;

namespace SvaSorcery.Patterns.Enterprise.Session.DatabaseSession.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult Single<T>(T model, Func<T, bool> criteria = null)
        {
            if (model is null)
            {
                return NotFound();
            }
            var isValid = criteria is null || criteria(model);
            if (isValid)
            {
                return Ok(model);
            }
            return NotFound();
        }

        protected async Task<IActionResult> SingleAsync<TQuery, TResult>(IQueryHandler<TQuery, TResult> handler, TQuery query)
            where TQuery : IQuery<TResult>
            => Single(await handler.HandleAsync(query));

        protected async Task<IActionResult> SendAsync<T>(ICommandHandler<T> handler, T command)
            where T : ICommand
        {
            await handler.HandleAsync(command);
            return Accepted();
        }
    }
}
