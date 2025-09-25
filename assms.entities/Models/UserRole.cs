namespace assms.entities.Models;

public class UserRole : BaseModel
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    
    
    
    [ForeignKey(nameof(UserId))]
    public UserModel? User { get; set; }
    
    [ForeignKey(nameof(RoleId))]
    public RoleModel? Role { get; set; }
}