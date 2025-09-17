namespace assms.entities.Models;

public class UserRole : BaseModel
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    
    
    
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
    
    [ForeignKey(nameof(RoleId))]
    public Role? Role { get; set; }
}