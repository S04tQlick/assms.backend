using assms.entities.Models;

namespace assms.entities.Response.UserResponse;

public class UserRowModel : BaseModel
{
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
    public Guid BranchId { get; set; }


    // Optionally include navigation collections if needed
    public int UserCount { get; set; }
}