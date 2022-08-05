using AspireAPI.Domain.DAL;
using AspireAPI.Domain.DAL.UI;

namespace GodspeedAPI.Controllers
{
  public class ApplicationSettings
  {
    public Entity entity { get; set; }
    public EntityApplication application { get; set; }
    public EntityApplicationSettings setting { get; set; }
    public List<NavLinks> nav { get; set; }
    public Background background { get; set; }

    public ApplicationSettings()
    {
      entity = new Entity();
      application = new EntityApplication();
      setting = new EntityApplicationSettings();
      nav = new List<NavLinks>();
      background = new Background();
    }
  }
}