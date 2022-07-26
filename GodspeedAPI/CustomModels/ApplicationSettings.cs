using AspireAPI.Domain.DAL;
using AspireAPI.Domain.DAL.UI;

namespace GodspeedAPI.CustomModels
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
      this.entity = new Entity();
      this.application = new EntityApplication();
      this.setting = new EntityApplicationSettings();
      this.nav = new List<NavLinks>();
      this.background = new Background();
    }
  }
}
