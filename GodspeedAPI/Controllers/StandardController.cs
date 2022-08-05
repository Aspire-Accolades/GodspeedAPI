using AspireAPI.Infrastructure.Helpers;
using AspireAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GodspeedAPI.Controllers
{

  public class StandardController : ControllerBase
  {
    public ApplicationSettings _appSettings { get; set; }
    BaseHandler handler = new BaseHandler();
   
    public StandardController(ILogger<StandardController> logger, IConfiguration iConfig, EntityRepository entityRepository,EntityApplicationRepository entityApplicationRepository,EntityApplicationSettingsRepository settingRepository,NavItemsReporsitory navRepository,BackgroundRepository backgroundRepository)
    {
      _appSettings = new ApplicationSettings();
      string name = iConfig.GetValue<string>("Settings:Application");
      handler.TryCatch(true, () =>
      {
        _appSettings.application = entityApplicationRepository.ReadWhere(x => x.Name == name).FirstOrDefault();
        _appSettings.entity = entityRepository.ReadWhere(x => x.EntityID == _appSettings.application.EntityID).FirstOrDefault();
        _appSettings.setting = settingRepository.ReadWhere(x => x.EntityApplicationID == _appSettings.application.EntityApplicationID).FirstOrDefault();
        _appSettings.nav = navRepository.ReadWhere(x => x.EntityApplicationID == _appSettings.application.EntityApplicationID).ToList();
        _appSettings.background = backgroundRepository.ReadWhere(x => x.EntityApplicationID == _appSettings.application.EntityApplicationID).FirstOrDefault();
      }, "Application Settings Error");

    }

    [HttpGet]
    [Route("aspire/settings")]
    public IActionResult GetSettings()
    {
      return Ok(_appSettings);
    }
  }
}