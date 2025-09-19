namespace assms.entities.Models;

public abstract class GeoBaseModel : BaseModel
{
    [Column("Latitude")] public double Latitude { get; set; } = 0;

    [Column("Longitude")] public double Longitude { get; set; } = 0;
}