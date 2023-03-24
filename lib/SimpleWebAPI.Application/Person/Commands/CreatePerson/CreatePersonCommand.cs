namespace SimpleWebAPI.Application.Person.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using SimpleWebAPI.Application.Common.Interfaces;

    public class CreatePersonCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, bool>
    {
        private readonly IPersonMemoryCache _personMemoryCache;
        private readonly IPersonService _personService;

        public CreatePersonCommandHandler(IPersonService personService, IPersonMemoryCache personMemoryCache)
        {
            _personMemoryCache = personMemoryCache ?? throw new ArgumentNullException(nameof(personMemoryCache));
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
        }

        public async Task<bool> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            _personMemoryCache.CreatePerson(request.Name, request.Address);
            return await _personService.CreatePersonAsync(request.Name, request.Address, cancellationToken);
        }
    }
}
