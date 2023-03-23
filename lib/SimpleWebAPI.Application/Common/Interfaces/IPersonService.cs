namespace SimpleWebAPI.Application.Common.Interfaces
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using SimpleWebAPI.Domain.Entities;

    public interface IPersonService
    {
        bool PersonExists(string name);

        Task<bool> CreatePersonAsync(string name, string address, CancellationToken token);
        Task<bool> UpdatePersonAsync(string name, string address, CancellationToken token);
        Task<bool> DeletePersonAsync(string name, CancellationToken token);
        Task<IEnumerable<Person>> SelectAllPersons(CancellationToken token);
    }
}
