using Microsoft.EntityFrameworkCore;
using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using uTimePlatform.IAM.Domain.Model.Aggregates;
using uTimePlatform.Reviews.Domain.Model.Aggregates;


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

        // Review entity configuration
        builder.Entity<Review>().HasKey(r => r.Id);
        builder.Entity<Review>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        
        // PersonName value object
        builder.Entity<Client>().OwnsOne(c => c.Name, name =>
        {
            name.WithOwner().HasForeignKey("Id");
            name.Property(p => p.FirstName).HasColumnName("first_name").IsRequired();
            name.Property(p => p.LastName).HasColumnName("last_name").IsRequired();
        });
        
        // Comment value object
        builder.Entity<Review>().OwnsOne(r => r.Comment, comment =>
        {
            comment.WithOwner().HasForeignKey("Id");
            comment.Property(p => p.Content).HasColumnName("comment").IsRequired();
        });
        
        //Provider Response
        builder.Entity<Review>()
            .Property(r => r.ProviderResponse)
            .HasColumnName("provider_response")
            .HasMaxLength(1000);
        
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
        
        // Review - Client (una review por cliente por salón)
        builder.Entity<Review>()
            .HasOne(r => r.Client)
            .WithMany() // sin navegación inversa desde Client
            .HasForeignKey(r => r.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        // Review - Provider (un salón con muchas reviews)
        builder.Entity<Review>()
            .HasOne(r => r.Salon)
            .WithMany(p => p.Reviews) // navegación desde Provider
            .HasForeignKey(r => r.SalonId)
            .OnDelete(DeleteBehavior.Cascade);

        
        // Naming convention
        builder.UseSnakeCaseNamingConvention();
    }
}
