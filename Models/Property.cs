namespace PropertyHubMVC.Models;

public class Property
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string PropertyType { get; set; } = string.Empty;

    public int? Bedrooms { get; set; }

    public decimal? Bathrooms { get; set; }

    public int SquareFootage { get; set; }

    public int? YearBuilt { get; set; }

    public string Status { get; set; } = string.Empty;

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public DateTime DateListed { get; set; }

    public int AgentId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public ICollection<PropertyImage> PropertyImages { get; set; } = new List<PropertyImage>();
}
