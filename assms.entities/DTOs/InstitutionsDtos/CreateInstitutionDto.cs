namespace assms.entities.DTOs.InstitutionsDtos;

public class CreateInstitutionDto
{
    public required string Name { get; set; }
    public string? LogoUrl { get; set; }
    public required string Country { get; set; }
    public required string Region { get; set; }
    public required string City { get; set; }
    public required string Address { get; set; } 
}