namespace SimpleWebAPI.Application.Person.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using SimpleWebAPI.Application.Common.Interfaces;

    public class DeletePersonCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }

    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IPersonMemoryCache _personMemoryCache;
        private readonly IPersonService _personService;

        public DeletePersonCommandHandler(IPersonMemoryCache personMemoryCache, IPersonService personService)
        {
            _personMemoryCache = personMemoryCache ?? throw new ArgumentNullException(nameof(personMemoryCache));
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
        }

        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            _personMemoryCache.DeletePerson(request.Name);
            return await _personService.DeletePersonAsync(request.Name, cancellationToken);
        }
    }
}
