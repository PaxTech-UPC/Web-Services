using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace uTimePlatform.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {

        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Client>().HasKey(f => f.Id);
        builder.Entity<Client>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Client>().Property(f => f.FirstName).IsRequired();
        builder.Entity<Client>().Property(f => f.LastName).IsRequired();
        builder.Entity<Client>().Property(f => f.Email).IsRequired();

        builder.UseSnakeCaseNamingConvention();
    }
}