using Microsoft.EntityFrameworkCore;
using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using uTimePlatform.IAM.Domain.Model.Aggregates;


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
        
        // Provider entity configuration
        builder.Entity<Provider>().HasKey(p => p.Id);
        builder.Entity<Provider>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

        // CompanyName value object
        builder.Entity<Provider>().OwnsOne(p => p.Name, name =>
        {
            name.WithOwner().HasForeignKey("Id");
            name.Property(cn => cn.Value).HasColumnName("company_name").IsRequired();
        });


        // IAM Context - User
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Email).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        
        // Client - User FK
        builder.Entity<Client>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Provider - User FK
        builder.Entity<Provider>()
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        
        
        // Naming convention
        builder.UseSnakeCaseNamingConvention();
    }
}
