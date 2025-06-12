using Microsoft.EntityFrameworkCore;
using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Profiles.Domain.Model.ValueObjects;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace uTimePlatform.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Client entity configuration
        builder.Entity<Client>().HasKey(c => c.Id);
        builder.Entity<Client>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();

        // PersonName value object
        builder.Entity<Client>().OwnsOne(c => c.Name, name =>
        {
            name.WithOwner().HasForeignKey("Id");
            name.Property(p => p.FirstName).HasColumnName("first_name").IsRequired();
            name.Property(p => p.LastName).HasColumnName("last_name").IsRequired();
        });

        // EmailAddress value object
        builder.Entity<Client>().OwnsOne(c => c.Email, email =>
        {
            email.WithOwner().HasForeignKey("Id");
            email.Property(e => e.Address).HasColumnName("email").IsRequired();
        });

        // BirthDate value object
        builder.Entity<Client>().OwnsOne(c => c.BirthDate, birthdate =>
        {
            birthdate.WithOwner().HasForeignKey("Id");
            birthdate.Property(b => b.Value).HasColumnName("birth_date").IsRequired();
        });

        // Naming convention
        builder.UseSnakeCaseNamingConvention();
    }
}
