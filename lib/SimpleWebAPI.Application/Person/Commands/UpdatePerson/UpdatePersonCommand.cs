namespace SimpleWebAPI.Application.Person.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using SimpleWebAPI.Application.Common.Interfaces;

    public class UpdatePersonCommand : INotification
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class UpdatePersonCommandHandler : INotificationHandler<UpdatePersonCommand>
    {
        private readonly IPersonService _personService;

        public UpdatePersonCommandHandler(IPersonService personService)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
        }

        public Task Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            return _personService.UpdatePersonAsync(request.Name, request.Address, cancellationToken);
        }
    }

    public class UpdatePersonCommandCacheHandler : INotificationHandler<UpdatePersonCommand>
    {
        private readonly IPersonMemoryCache _personMemoryCache;

        public UpdatePersonCommandCacheHandler(IPersonMemoryCache personMemoryCache)
        {
            _personMemoryCache = personMemoryCache ?? throw new ArgumentNullException(nameof(personMemoryCache));
        }

        public Task Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            _personMemoryCache.UpdatePerson(request.Name, request.Address);
            return Task.CompletedTask;
        }
    }
}
