namespace SimpleWebAPI.Application.Common.Interfaces
{
    using SimpleWebAPI.Domain.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using System.Threading.Tasks;
    using System.Threading;

    public interface IApplicationDbContext
    {
        DbSet<Person> Persons { get; set; }
        IModel Model { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
