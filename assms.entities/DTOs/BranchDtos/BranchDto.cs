namespace assms.entities.DTOs.BranchDtos;

public class BranchDto
{
    public Guid Id { get; set; }
    public required string BranchName { get; set; }
    public required string Address { get; set; }
    public required string City { get; set; } 
}