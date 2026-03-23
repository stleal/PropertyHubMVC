using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using PropertyHubMVC.Models;
using PropertyHubMVC.Options;

namespace PropertyHubMVC.Services;

public class PropertyApiClient
{
    private readonly HttpClient httpClient;
    private readonly PropertyApiOptions options;

    public PropertyApiClient(HttpClient httpClient, IOptions<PropertyApiOptions> options)
    {
        this.httpClient = httpClient;
        this.options = options.Value;
    }

    public async Task<IReadOnlyList<Property>> GetPropertiesAsync(CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(options.BaseUrl))
        {
            throw new InvalidOperationException("Property API base URL is not configured.");
        }

        if (string.IsNullOrWhiteSpace(options.PropertiesEndpoint))
        {
            throw new InvalidOperationException("Property API endpoint is not configured.");
        }

        var baseUri = new Uri(options.BaseUrl);
        var requestUri = new Uri(baseUri, options.PropertiesEndpoint.TrimStart('/'));
        var properties = await httpClient.GetFromJsonAsync<List<Property>>(requestUri, cancellationToken);

        return properties ?? [];
    }
}