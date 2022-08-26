using Aspire.Security;
using Aspire.Security.Attributes;
using AspireAPI.Infrastructure.Helpers;
using AspireAPI.Infrastructure.Repositories;
using GodspeedAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GodspeedAPI.Controllers
{
  public class StandardController : ControllerBase
  {
    public ApplicationSettings _appSettings { get; set; }
    public StandardController(ILogger<StandardController> logger, ApplicationSettings appSettings)
    {
      _appSettings = appSettings;
    }

    [HttpGet]
    [Route("aspire/settings")]
    public IActionResult GetSettings()
    {
      return Ok(_appSettings);
    }
  }
}