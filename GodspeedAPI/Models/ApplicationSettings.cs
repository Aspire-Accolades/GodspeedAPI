using AspireAPI.Domain.DAL;
using AspireAPI.Domain.DAL.UI;
using AspireAPI.Infrastructure.Helpers;
using AspireAPI.Infrastructure.Repositories;

namespace GodspeedAPI.Models
{
  public class ApplicationSettings
  {
    BaseHandler handler = new BaseHandler();
    public Entity entity { get; set; }
    public EntityApplication application { get; set; }
    public EntityApplicationSettings setting { get; set; }
    public List<NavLinks> nav { get; set; }
    public Background background { get; set; }

    public ApplicationSettings(IConfiguration iConfig, EntityRepository entityRepository, EntityApplicationRepository entityApplicationRepository, EntityApplicationSettingsRepository settingRepository, NavItemsReporsitory navRepository, BackgroundRepository backgroundRepository)
    {
      string name = iConfig.GetValue<string>("Settings:Application");
      handler.TryCatch(true, () =>
      {
        application = entityApplicationRepository.ReadWhere(x => x.Name == name).FirstOrDefault();
        entity = entityRepository.ReadWhere(x => x.EntityID == application.EntityID).FirstOrDefault();
        setting = settingRepository.ReadWhere(x => x.EntityApplicationID == application.EntityApplicationID).FirstOrDefault();
        nav = navRepository.ReadWhere(x => x.EntityApplicationID == application.EntityApplicationID).ToList();
        background = backgroundRepository.ReadWhere(x => x.EntityApplicationID == application.EntityApplicationID).FirstOrDefault();
      }, "Application Settings Error");
    }
  }
}