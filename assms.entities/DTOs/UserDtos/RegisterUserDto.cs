namespace assms.entities.DTOs.UserDtos;

public class RegisterUserDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public Guid InstitutionId { get; set; }
    public Guid BranchId { get; set; }
    public required string DisplayName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Phone { get; set; } 
}