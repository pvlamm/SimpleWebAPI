namespace SimpleWebAPI.Infrastructure.Persistance.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using SimpleWebAPI.Domain.Entities;

    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .ToTable("Person");

            builder
                .HasKey(x => x.Name);

            builder
                .Property(x => x.Name)
                .HasMaxLength(75)
                .IsRequired();

            builder
                .Property(x => x.Address)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
