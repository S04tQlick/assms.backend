using assms.entities.Models;
using Microsoft.EntityFrameworkCore;

namespace assms.api.DAL.DatabaseContext;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Institution> Institutions { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<AssetType> AssetTypes { get; set; }
    public DbSet<AssetCategory> AssetCategories { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<AssetImage> AssetImages { get; set; }
    public DbSet<MaintenanceDue> MaintenanceDue { get; set; }
    public DbSet<MaintenanceReport> MaintenanceReports { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
        
    public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
    public DbSet<InstitutionSubscription> InstitutionSubscriptions { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PaymentWebhookLog> PaymentWebhookLogs { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Composite PK for UserRole
        modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.Id, ur.RoleId });

        // Relationships
        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        modelBuilder.Entity<AssetCategory>()
            .HasOne(ac => ac.AssetType)
            .WithMany(at => at.Categories)
            .HasForeignKey(ac => ac.AssetTypeId);

        modelBuilder.Entity<Asset>()
            .HasOne(a => a.AssetType)
            .WithMany(at => at.Assets)
            .HasForeignKey(a => a.AssetTypeId);

        modelBuilder.Entity<Asset>()
            .HasOne(a => a.AssetCategory)
            .WithMany(ac => ac.Assets)
            .HasForeignKey(a => a.AssetCategoryId);

        modelBuilder.Entity<Asset>()
            .HasOne(a => a.Vendor)
            .WithMany(v => v.Assets)
            .HasForeignKey(a => a.VendorId);

        modelBuilder.Entity<AssetImage>()
            .HasOne(ai => ai.Asset)
            .WithMany(a => a.Images)
            .HasForeignKey(ai => ai.AssetId);

        modelBuilder.Entity<MaintenanceDue>()
            .HasOne(md => md.Asset)
            .WithMany(a => a.MaintenanceDueItems)
            .HasForeignKey(md => md.AssetId);

        modelBuilder.Entity<MaintenanceReport>()
            .HasOne(mr => mr.Asset)
            .WithMany(a => a.MaintenanceReports)
            .HasForeignKey(mr => mr.AssetId);
    }
}
