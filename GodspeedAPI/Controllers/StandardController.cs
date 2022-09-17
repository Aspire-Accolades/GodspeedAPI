using Aspire.Security;
using Aspire.Security.Attributes;
using Aspire.Util;
using AspireAPI.Infrastructure.Helpers;
using AspireAPI.Infrastructure.Repositories;
using GodspeedAPI.Controllers.Base;
using GodspeedAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GodspeedAPI.Controllers
{
  public class StandardController : BaseController
  {
    public ApplicationSettings _appSettings { get; set; }
    public Logger _logger { get; set; }
    public StandardController(ApplicationSettings appSettings)
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