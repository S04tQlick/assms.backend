namespace assms.entities.Models;

[Table("Roles")]
public class RoleModel : BaseModel
{
    public required string RoleName { get; set; }

    public ICollection<UserRole>? UserRoles { get; set; }
}