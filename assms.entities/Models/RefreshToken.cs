namespace assms.entities.Models;

public class RefreshToken: BaseModel
{
    //public Guid Token { get; set; }
    public Guid UserId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    public DateTime ExpiresAt { get; set; }
    public bool Revoked { get; set; } = false;
}