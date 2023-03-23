namespace SimpleWebAPI.Infrastructure.Persistance
{
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    using SimpleWebAPI.Application.Common.Interfaces;
    using SimpleWebAPI.Domain.Entities;

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Person> Persons { get; set; }
        IModel IApplicationDbContext.Model => base.Model;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
