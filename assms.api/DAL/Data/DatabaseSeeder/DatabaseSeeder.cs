using assms.api.DAL.DatabaseContext;
using assms.api.Helpers;
using assms.entities;
using assms.entities.Models;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace assms.api.DAL.Data.DatabaseSeeder;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(ApplicationDbContext db)
    {
        // Run migrations first
        await db.Database.MigrateAsync();

        // Example: Seed Roles if not already present
        if (!db.RoleModel.Any())
        {
            db.RoleModel.AddRange(
                new RoleModel { RoleName = nameof(UserRolesEnum.SystemAdmin) },
                new RoleModel { RoleName = nameof(UserRolesEnum.AssetManager) },
                new RoleModel { RoleName = nameof(UserRolesEnum.BranchAdmin) },
                new RoleModel { RoleName = nameof(UserRolesEnum.DepartmentManager) },
                new RoleModel { RoleName = nameof(UserRolesEnum.ProcurementOfficer) },
                new RoleModel { RoleName = nameof(UserRolesEnum.InventoryOfficer) },
                new RoleModel { RoleName = nameof(UserRolesEnum.MaintenanceOfficer) },
                new RoleModel { RoleName = nameof(UserRolesEnum.Employee) },
                new RoleModel { RoleName = nameof(UserRolesEnum.Auditor) },
                new RoleModel { RoleName = nameof(UserRolesEnum.FinanceOfficer) },
                new RoleModel { RoleName = nameof(UserRolesEnum.SecurityOfficer) }
            );
            await db.SaveChangesAsync();
        }

        // Check if any institution exists
        if (!db.Institutions.Any())
        {
            var institution = new InstitutionModel()
            {
                Name = "Default Institution",
                Country = "Ghana",
                Region = "Greater Accra",
                City = "Accra",
                Address = "Head Office Address",
                SubscriptionExpiresAt = FakeDataHelper.FutureIndefiniteDate(),
                LogoUrl = FakeDataHelper.LogoUrl(),
                IsActive = true,
            };
            await db.Institutions.AddAsync(institution);
            await db.SaveChangesAsync();
        }

        // Check if any branch exists
        if (!db.BranchModel.Any())
        {
            var branch = new BranchModel
            {
                Name = "Default Branch",
                InstitutionId = db.Institutions.First().Id,
                Country = "Ghana",
                Region = "Greater Accra",
                City = "Accra",
                Address = "Branch Office Address",
                Latitude = FakeDataHelper.Latitude(),
                Longitude = FakeDataHelper.Longitude(),
                IsActive = true
            };
        
            await db.BranchModel.AddAsync(branch);
            await db.SaveChangesAsync();
        }
        
        // Example: Seed Default Admin User if not present
        if (!db.UserModel.Any(u => u.Email == "admin@default.com"))
        {
            var user = new UserModel
            {
                FirstName = "Root",
                LastName = "Admin",
                DisplayName = "Root Admin",
                Phone = "+233(0)0800-000",
                InstitutionId = db.Institutions.First().Id,
                BranchId = db.BranchModel.First().Id,
                Email = "admin@default.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
            };
        
            db.UserModel.Add(user);
            await db.SaveChangesAsync();
        }
        
        if (!db.UserRoles.Any())
        {
            var adminRole = db.RoleModel.First(r => r.RoleName == nameof(UserRolesEnum.SystemAdmin));
            var userRole = new UserRole()
            {
                Id = Guid.NewGuid(),
                UserId = db.UserModel.First().Id,
                RoleId = adminRole.Id,
                CreatedAt = DateTime.UtcNow,
            };
        
            await db.UserRoles.AddAsync(userRole);
            await db.SaveChangesAsync();
        }
    }
}