using AspireAPI.Domain.DAL;
using AspireAPI.Domain.DAL.UI;
using AspireAPI.Infrastructure.Interfaces;
using AspireAPI.Infrastructure.Repositories;
using GodspeedAPI.CustomModels;
using Microsoft.AspNetCore.Mvc;

namespace GodspeedAPI.Controllers
{
  [ApiController]
  [Route("[controller]", Name = "SessionSettings")]
  public class StandardController : ControllerBase
  {
    WebSettingsRepository _settingsRepo;
    ApplicationSettings _appSettings = new ApplicationSettings();
    private readonly ILogger<StandardController> _logger;

    public StandardController(ILogger<StandardController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    [Route("settings", Name ="sessionInfo")]
    public IActionResult GetSettings(string name ,bool isTest)
    {
      
      try
      {
        _settingsRepo = new WebSettingsRepository(name, isTest);
        _appSettings.entity = _settingsRepo.entity;
        _appSettings.application = _settingsRepo.application;
        _appSettings.setting = _settingsRepo.settings;
        _appSettings.nav = _settingsRepo.links;
        _appSettings.background = _settingsRepo.background;

        return Ok(_appSettings);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.InnerException);
      }

      
    }
  }
}