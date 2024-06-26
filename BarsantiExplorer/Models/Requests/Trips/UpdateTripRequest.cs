using System.ComponentModel.DataAnnotations;

namespace BarsantiExplorer.Models.Requests.Trips;

public class UpdateTripRequest
{
    public IFormFile? Image { get; set; }

    [MaxLength(50)] public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    [Range(1, int.MaxValue)] public int? TypeId { get; set; }
}