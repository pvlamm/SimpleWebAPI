namespace SimpleWebAPI.WebEndpoint.Controllers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using SimpleWebAPI.Application.Person.Commands;
    using SimpleWebAPI.Application.Person.Queries;
    using SimpleWebAPI.WebEndpoint.Filters;

    [Route("api/[controller]")]
    [ApiController]
    [ApiExceptionFilter]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            var result = await _mediator.Send(new SelectAllPersonsQuery(), token);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Post(CreatePersonCommand command, CancellationToken token)
        {
            await _mediator.Send(command, token);
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(UpdatePersonCommand command, CancellationToken token)
        {
            await _mediator.Send(command, token);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(DeletePersonCommand command, CancellationToken token)
        {
            await _mediator.Send(command, token);
            return NoContent();
        }
    }
}
