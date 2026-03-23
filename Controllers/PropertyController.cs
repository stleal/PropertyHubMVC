using Microsoft.AspNetCore.Mvc;
using PropertyHubMVC.Services;

namespace PropertyHubMVC.Controllers;

public class PropertyController : Controller
{
    private readonly PropertyApiClient propertyApiClient;
    private readonly ILogger<PropertyController> logger;

    public PropertyController(PropertyApiClient propertyApiClient, ILogger<PropertyController> logger)
    {
        this.propertyApiClient = propertyApiClient;
        this.logger = logger;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        try
        {
            var properties = await propertyApiClient.GetPropertiesAsync(cancellationToken);
            return View(properties);
        }
        catch (HttpRequestException exception)
        {
            logger.LogError(exception, "Failed to load property listings from the API.");
            ViewData["ErrorMessage"] = exception.Message;

            return View(Array.Empty<PropertyHubMVC.Models.Property>());
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Failed to load property listings from the API.");
            ViewData["ErrorMessage"] = "Property listings could not be loaded from the API. Check the PropertyApi settings and verify the API is running.";

            return View(Array.Empty<PropertyHubMVC.Models.Property>());
        }
    }
}