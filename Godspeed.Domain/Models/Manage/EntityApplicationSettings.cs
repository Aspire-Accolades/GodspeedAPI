using System.ComponentModel.DataAnnotations.Schema;

namespace Godspeed.Domain.Models.Manage
{
  [Table(nameof(EntityApplicationSettings), Schema = "Manage")]
  public class EntityApplicationSettings
  {
    public int EntityApplicationSettingID { get; set; }
    public int EntityApplicationID { get; set; }
    public string Logo { get; set; } = String.Empty;
    public string ThemeName { get; set; } = String.Empty;
    public DateTime DateAdded { get; set; }
    public string UserAdded { get; set; } = String.Empty;
    public DateTime DateModified { get; set; }
    public string UserModified { get; set; } = String.Empty;
    
  }
}
