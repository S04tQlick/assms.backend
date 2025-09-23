namespace assms.entities.Request;

public class UserRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public Guid InstitutionId { get; set; }
    public Guid BranchId { get; set; }
    public required string Email { get; set; }
    public required string DisplayName { get; set; }
    public required string Password { get; set; } // plain text (will be hashed in service)
    public required string Phone { get; set; }
    public Guid RoleId { get; set; } 
}