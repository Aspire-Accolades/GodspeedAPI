using Aspire.Util;
using AspireAPI.Domain.DAL;
using AspireAPI.Infrastructure.Helpers;
using AspireAPI.Infrastructure.Repositories;

namespace GodspeedAPI.Models
{
  public class ApplicationSettings
  {
    BaseHandler handle;

    public Entity Entity { get; set; }
    public int Portal { get; private set; }
    public EntityApplication? application { get; private set; }

    public ApplicationSettings(IConfiguration iConfig, Logger logger, EntityRepository entityRepository, EntityApplicationRepository entityApplicationRepository, EntityApplicationSettingsRepository settingRepository, NavItemsReporsitory navRepository, BackgroundRepository backgroundRepository, FormRepository formRepository)
    {

      handle = new BaseHandler(logger);
      string name = iConfig.GetValue<string>("Settings:Application");
      Portal = iConfig.GetValue<int>("Settings:Portal");
      handle.TryCatch(true, () =>
      {
        logger.Log("Obtaining settings for " + name);
        application = entityApplicationRepository.ReadWhere(x => x.Name == name).FirstOrDefault();
        logger.Log("Using tenant ID: " + application.EntityApplicationID);
        entity = entityRepository.ReadWhere(x => x.EntityID == application.EntityID).FirstOrDefault();
        setting = settingRepository.ReadWhere(x => x.EntityApplicationID == application.EntityApplicationID).FirstOrDefault();
        nav = navRepository.ReadWhere(x => x.EntityApplicationID == application.EntityApplicationID).ToList();
        background = backgroundRepository.ReadWhere(x => x.EntityApplicationID == application.EntityApplicationID).FirstOrDefault();
        forms = formRepository.ReadWhere(x => x.EntityApplicationID == application.EntityApplicationID).ToList();
      }, "Application Settings Error");
    }
  }
}