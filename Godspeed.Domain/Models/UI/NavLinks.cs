using System.ComponentModel.DataAnnotations.Schema;

namespace Godspeed.Domain.Models.UI
{
  [Table(nameof(NavLinks), Schema = "UI")]
  public class NavLinks
  {
    public int NavMenuID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public int EntityApplicationID { get; set; }
  }
}
