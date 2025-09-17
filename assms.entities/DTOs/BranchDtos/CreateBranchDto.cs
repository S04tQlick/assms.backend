namespace assms.entities.DTOs.BranchDtos;

public class CreateBranchDto
{
    public Guid InstitutionId { get; set; }
    public required string BranchName { get; set; }
    public required string Address { get; set; }
    public required string City { get; set; } 
}