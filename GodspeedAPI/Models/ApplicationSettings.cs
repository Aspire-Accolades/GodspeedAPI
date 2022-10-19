using Aspire.Util;
using AspireAPI.Domain.DAL;
using AspireAPI.Domain.DAL.UI;
using AspireAPI.Infrastructure.Helpers;
using AspireAPI.Infrastructure.Repositories;

namespace GodspeedAPI.Models
{
  public class ApplicationSettings
  {
    BaseHandler handle;
    public Entity entity { get; set; }
    public EntityApplication application { get; set; }
    public EntityApplicationSettings setting { get; set; }
    public List<NavLinks> nav { get; set; }
    public Background background { get; set; }
    public List<Forms> forms { get; set; }

    public ApplicationSettings(IConfiguration iConfig, Logger logger, EntityRepository entityRepository, EntityApplicationRepository entityApplicationRepository, EntityApplicationSettingsRepository settingRepository, NavItemsReporsitory navRepository, BackgroundRepository backgroundRepository, FormRepository formRepository)
    {
      handle = new BaseHandler(logger);
      string name = iConfig.GetValue<string>("Settings:Application");
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