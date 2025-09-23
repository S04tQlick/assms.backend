namespace assms.entities.Response.UserResponse;

public class UserResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public bool IsEmailConfirmed { get; set; }
    public bool IsPhoneConfirmed { get; set; }
    public bool IsActive { get; set; }
    public DateTime? LastLogin { get; set; }

    public Guid InstitutionId { get; set; }
    public string? InstitutionName { get; set; }
    public Guid BranchId { get; set; }
    public string? BranchName { get; set; }

    public Guid RoleId { get; set; }
    public string? RoleName { get; set; }
}