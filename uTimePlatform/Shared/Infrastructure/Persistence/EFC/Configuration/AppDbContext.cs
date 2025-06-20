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
        
        // --- Reservation ---
        /*builder.Entity<Reservation.Domain.Model.Aggregates.Reservation>().HasKey(r => r.Id);
        builder.Entity<Reservation.Domain.Model.Aggregates.Reservation>().Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Entity<Reservation.Domain.Model.Aggregates.Reservation>().Property(r => r.SalonId).IsRequired();
        builder.Entity<Reservation.Domain.Model.Aggregates.Reservation>().Property(r => r.ClientId).IsRequired();
        builder.Entity<Reservation.Domain.Model.Aggregates.Reservation>().Property(r => r.PaymentId).IsRequired();
        builder.Entity<Reservation.Domain.Model.Aggregates.Reservation>().Property(r => r.TimeSlotId).IsRequired();
        builder.Entity<Reservation.Domain.Model.Aggregates.Reservation>().Property(r => r.WorkerId).IsRequired();
        
        // --- Payments ---
        builder.Entity<Payments>().HasKey(p => p.Id);
        builder.Entity<Payments>().Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Entity<Payments>().Property(p => p.Status).IsRequired();

        // Money como Value Object
        builder.Entity<Payments>().OwnsOne(p => p.Money, money =>
        {
            money.Property(m => m.Amount).HasColumnName("amount").IsRequired();
            money.Property(m => m.Currency).HasColumnName("currency").IsRequired();
        });
        
        // --- TimeSlots ---
        builder.Entity<TimeSlots>().HasKey(t => t.Id);
        builder.Entity<TimeSlots>().Property(t => t.Id).ValueGeneratedOnAdd();
        builder.Entity<TimeSlots>().Property(t => t.startTime).HasColumnName("start_time").IsRequired();
        builder.Entity<TimeSlots>().Property(t => t.endTime).HasColumnName("end_time").IsRequired();
        builder.Entity<TimeSlots>().Property(t => t.status).HasColumnName("status").IsRequired();

        // TimeSlotType como Value Object
        builder.Entity<TimeSlots>().OwnsOne(t => t.Type, type =>
        {
            type.Property(v => v.Type).HasColumnName("type").IsRequired();
        });*/
        
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

        /*builder.Entity<Reservation.Domain.Model.Aggregates.Reservation>()
            .HasOne(r => r.Client)
            .WithMany()
            .HasForeignKey(r => r.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Reservation.Domain.Model.Aggregates.Reservation>()
            .HasOne(r => r.Payment)
            .WithMany()
            .HasForeignKey(r => r.PaymentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Reservation.Domain.Model.Aggregates.Reservation>()
            .HasOne(r => r.TimeSlot)
            .WithMany()
            .HasForeignKey(r => r.TimeSlotId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Reservation.Domain.Model.Aggregates.Reservation>()
            .HasOne(r => r.Worker)
            .WithMany()
            .HasForeignKey(r => r.WorkerId)
            .OnDelete(DeleteBehavior.Cascade);*/
        
        // Naming convention
        builder.UseSnakeCaseNamingConvention();
    }
}
