namespace PropertyHubMVC.Options;

public class PropertyApiOptions
{
    public const string SectionName = "PropertyApi";

    public string BaseUrl { get; set; } = string.Empty;

    public string PropertiesEndpoint { get; set; } = "api/Property/GetAllProperties";
}