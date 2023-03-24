namespace SimpleWebAPI.Application.Person.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using SimpleWebAPI.Application.Common.Interfaces;

    public class UpdatePersonCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, bool>
    {
        private readonly IPersonMemoryCache _personMemoryCache;
        private readonly IPersonService _personService;

        public UpdatePersonCommandHandler(IPersonMemoryCache personMemoryCache, IPersonService personService)
        {
            _personMemoryCache = personMemoryCache ?? throw new ArgumentNullException(nameof(personMemoryCache));
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
        }

        public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            _personMemoryCache.UpdatePerson(request.Name, request.Address);
            return await _personService.UpdatePersonAsync(request.Name, request.Address, cancellationToken);
        }
    }
}
