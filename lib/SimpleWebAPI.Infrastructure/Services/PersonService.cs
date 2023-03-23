namespace SimpleWebAPI.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using SimpleWebAPI.Application.Common.Interfaces;
    using SimpleWebAPI.Domain.Entities;

    public class PersonService : IPersonService
    {
        private readonly IApplicationDbContext _context;

        public PersonService(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public async Task<bool> CreatePersonAsync(string name, string address, CancellationToken token)
        {
            var person = new Person(name, address);
            await _context.Persons.AddAsync(person, token);
            return (await _context.SaveChangesAsync(token)) == 1;
        }

        public async Task<bool> DeletePersonAsync(string name, CancellationToken token)
        {
            _context.Persons.Remove(new Person(name, string.Empty));
            return await _context.SaveChangesAsync(token) == 1;
        }

        public bool PersonExists(string name)
        {
            return  _context.Persons.Any(x => x.Name == name);
        }

        public async Task<IEnumerable<Person>> SelectAllPersons(CancellationToken token)
        {
            var personList = await _context.Persons.ToArrayAsync(token);
            return personList;
        }

        public async Task<bool> UpdatePersonAsync(string name, string address, CancellationToken token)
        {
            var person = new Person(name, address);
            _context.Persons.Attach(person);
            _context.Persons.Entry(person).Property(x => x.Address).IsModified = true;
            _context.Persons.Update(person);
            return await _context.SaveChangesAsync(token) == 1;
        }
    }
}
