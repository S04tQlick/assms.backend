namespace assms.entities.Models;

public class Role : BaseModel
{
    public required string RoleName { get; set; }

    public ICollection<UserRole>? UserRoles { get; set; }
}