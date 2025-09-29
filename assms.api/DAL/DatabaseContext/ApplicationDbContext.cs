namespace assms.api.DAL.DatabaseContext;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<InstitutionModel> InstitutionModel { get; set; }
    public DbSet<BranchModel> BranchModel { get; set; }
    public DbSet<UserModel> UserModel { get; set; }
    public DbSet<RoleModel> RoleModel { get; set; }
    public DbSet<UserRoleModel> UserRoleModel { get; set; }
    public DbSet<VendorModel> VendorModel { get; set; }
    public DbSet<AssetTypeModel> AssetTypeModel { get; set; }
    public DbSet<AssetCategoryModel> AssetCategoryModel { get; set; }
    public DbSet<AssetModel> AssetModel { get; set; }
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
        modelBuilder.Entity<UserRoleModel>().HasKey(ur => new { ur.Id, ur.RoleId });

        // Relationships
        modelBuilder.Entity<UserRoleModel>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoleModel)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRoleModel>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        modelBuilder.Entity<AssetCategoryModel>()
            .HasOne(ac => ac.AssetType)
            .WithMany(at => at.Categories)
            .HasForeignKey(ac => ac.AssetTypeId);

        modelBuilder.Entity<AssetModel>()
            .HasOne(a => a.BranchModel)
            .WithMany(at => at.Assets)
            .HasForeignKey(a => a.BranchId);

        modelBuilder.Entity<AssetModel>()
            .HasOne(a => a.AssetTypeModel)
            .WithMany(at => at.Assets)
            .HasForeignKey(a => a.AssetTypeId);

        modelBuilder.Entity<AssetModel>()
            .HasOne(a => a.AssetCategoryModel)
            .WithMany(ac => ac.Assets)
            .HasForeignKey(a => a.AssetCategoryId);

        modelBuilder.Entity<AssetModel>()
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