namespace SimpleWebAPI.Application.Person.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using SimpleWebAPI.Application.Common.Interfaces;

    public class CreatePersonCommand : INotification
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class CreatePersonCommandHandler : INotificationHandler<CreatePersonCommand>
    {
        private readonly IPersonService _personService;

        public CreatePersonCommandHandler(IPersonService personService)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
        }

        public Task Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            return _personService.CreatePersonAsync(request.Name, request.Address, cancellationToken);
        }
    }

    public class CreatePersonCommandCacheHandler : INotificationHandler<CreatePersonCommand>
    {
        private readonly IPersonMemoryCache _personMemoryCache;

        public CreatePersonCommandCacheHandler(IPersonMemoryCache personMemoryCache)
        {
            _personMemoryCache = personMemoryCache ?? throw new ArgumentNullException(nameof(personMemoryCache));
        }

        public Task Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            _personMemoryCache.CreatePerson(request.Name, request.Address);
            return Task.CompletedTask;
        }
    }
}
