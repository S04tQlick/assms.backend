namespace assms.entities.Models;

public class User : BaseModel
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public Guid InstitutionId { get; set; }
    
    [ForeignKey(nameof(InstitutionId))]
    public InstitutionModel? Institution { get; set; }
    
    public Guid BranchId { get; set; }
    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }

    public required string Email { get; set; }
    public string? NormalizedEmail { get; set; }
    public required string DisplayName { get; set; }
    public required string PasswordHash { get; set; }
    public required string Phone { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public bool IsPhoneConfirmed { get; set; }
    public Guid RoleId { get; set; }
    [ForeignKey(nameof(RoleId))]
    public Role? Role { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? LastLogin { get; set; }

    public ICollection<UserRole>? UserRoles { get; set; }
}