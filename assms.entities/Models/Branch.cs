namespace assms.entities.Models;

public class Branch : GeoBaseModel
{
    public Guid InstitutionId { get; set; }
    
    [ForeignKey(nameof(InstitutionId))]
    public Institution? Institution { get; set; }

    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string City { get; set; }
    public required string Region { get; set; }
    public required string Country { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<User>? Users { get; set; }
    public ICollection<Asset>? Assets { get; set; }
}