namespace SimpleWebAPI.Application.Person.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using SimpleWebAPI.Application.Common.Interfaces;

    public class DeletePersonCommand : INotification
    {
        public string Name { get; set; }
    }

    public class DeletePersonCommandHandler : INotificationHandler<DeletePersonCommand>
    {
        private readonly IPersonService _personService;

        public DeletePersonCommandHandler(IPersonService personService)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
        }

        public Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            return _personService.DeletePersonAsync(request.Name, cancellationToken);
        }
    }
    public class DeletePersonCommandCacheHandler : INotificationHandler<DeletePersonCommand>
    {
        private readonly IPersonMemoryCache _personMemoryCache;

        public DeletePersonCommandCacheHandler(IPersonMemoryCache personMemoryCache)
        {
            _personMemoryCache = personMemoryCache ?? throw new ArgumentNullException(nameof(personMemoryCache));
        }

        public Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            _personMemoryCache.DeletePerson(request.Name);
            return Task.CompletedTask;
        }
    }
}
