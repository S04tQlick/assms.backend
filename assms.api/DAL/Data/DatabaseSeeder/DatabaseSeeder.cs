using assms.api.DAL.DatabaseContext;
using assms.api.Helpers;
using assms.entities;
using assms.entities.Enums;
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
        if (!db.AssetTypeModel.Any())
        {
            await db.AssetTypeModel.AddRangeAsync(
                new AssetTypeModel
                {
                    AssetTypeName = nameof(AssetTypeEnum.DecorativeItems),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssetTypeModel
                {
                    AssetTypeName = nameof(AssetTypeEnum.Fixtures),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssetTypeModel
                {
                    AssetTypeName = nameof(AssetTypeEnum.Furniture),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssetTypeModel
                {
                    AssetTypeName = nameof(AssetTypeEnum.Hvac),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssetTypeModel
                {
                    AssetTypeName = nameof(AssetTypeEnum.ItEquipment),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssetTypeModel
                {
                    AssetTypeName = nameof(AssetTypeEnum.KitchenAppliances),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssetTypeModel
                {
                    AssetTypeName = nameof(AssetTypeEnum.SecuritySystems),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssetTypeModel
                {
                    AssetTypeName = nameof(AssetTypeEnum.Vehicles),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssetTypeModel
                {
                    AssetTypeName = nameof(AssetTypeEnum.TelecommunicationEquipment),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssetTypeModel
                {
                    AssetTypeName = nameof(AssetTypeEnum.Signage),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
            await db.SaveChangesAsync();
        }

        // Example: Seed Roles if not already present
        if (!db.RoleModel.Any())
        {
            await db.RoleModel.AddRangeAsync(
                new RoleModel
                {
                    RoleName = nameof(UserRolesEnum.SystemAdmin), 
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new RoleModel
                {
                    RoleName = nameof(UserRolesEnum.AssetManager), 
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new RoleModel
                {
                    RoleName = nameof(UserRolesEnum.BranchAdmin), 
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new RoleModel
                {
                    RoleName = nameof(UserRolesEnum.DepartmentManager), 
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new RoleModel
                {
                    RoleName = nameof(UserRolesEnum.ProcurementOfficer), 
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new RoleModel
                {
                    RoleName = nameof(UserRolesEnum.InventoryOfficer), 
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new RoleModel
                {
                    RoleName = nameof(UserRolesEnum.MaintenanceOfficer), 
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new RoleModel
                {
                    RoleName = nameof(UserRolesEnum.Employee), 
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow
                },
                new RoleModel
                {
                    RoleName = nameof(UserRolesEnum.Auditor), 
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow
                },
                new RoleModel
                {
                    RoleName = nameof(UserRolesEnum.FinanceOfficer), 
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new RoleModel
                {
                    RoleName = nameof(UserRolesEnum.SecurityOfficer), 
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
            await db.SaveChangesAsync();
        }
        
        
        

        // Check if any institution exists
        if (!db.InstitutionModel.Any())
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
            await db.InstitutionModel.AddAsync(institution);
            await db.SaveChangesAsync();
        }

        // Check if any branch exists
        if (!db.BranchModel.Any())
        {
            var branch = new BranchModel
            {
                Name = "Default Branch",
                InstitutionId = db.InstitutionModel.First().Id,
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
                InstitutionId = db.InstitutionModel.First().Id,
                BranchId = db.BranchModel.First().Id,
                Email = "admin@default.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
            };
        
            db.UserModel.Add(user);
            await db.SaveChangesAsync();
        }
        
        if (!db.UserRoleModel.Any())
        {
            var adminRole = db.RoleModel.First(r => r.RoleName == nameof(UserRolesEnum.SystemAdmin));
            var userRole = new UserRoleModel()
            {
                Id = Guid.NewGuid(),
                UserId = db.UserModel.First().Id,
                RoleId = adminRole.Id,
                CreatedAt = DateTime.UtcNow,
            };
        
            await db.UserRoleModel.AddAsync(userRole);
            await db.SaveChangesAsync();
        }
    }
}