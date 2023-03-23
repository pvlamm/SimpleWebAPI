namespace SimpleWebAPI.Application.Person.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using SimpleWebAPI.Application.Common.Dtos;
    using SimpleWebAPI.Application.Common.Interfaces;

    public class SelectAllPersonsQuery : IRequest<IEnumerable<PersonDto>>
    {
    }

    public class SelectAllPersonsQueryHandler : IRequestHandler<SelectAllPersonsQuery, IEnumerable<PersonDto>>
    {
        private readonly IPersonService _personService;
        private readonly IPersonMemoryCache _personMemoryCache;

        public SelectAllPersonsQueryHandler(IPersonService personService, IPersonMemoryCache personMemoryCache)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
            _personMemoryCache = personMemoryCache ?? throw new ArgumentNullException(nameof(personMemoryCache));
        }

        public async Task<IEnumerable<PersonDto>> Handle(SelectAllPersonsQuery request, CancellationToken cancellationToken)
        {
            var persons = _personMemoryCache.SelectAllPersons()?.Select(x => new PersonDto { Name = x.Key, Address = x.Value });

            if(persons?.Count() == 0)
            {
                persons = (await _personService.SelectAllPersons(cancellationToken))?.Select(x => new PersonDto(x)) ?? Array.Empty<PersonDto>();
                _personMemoryCache.SetAllPersons(persons.ToDictionary(x => x.Name, x => x.Address));
            }

            return persons ?? Array.Empty<PersonDto>();
        }
    }
}
