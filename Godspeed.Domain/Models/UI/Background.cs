using System.ComponentModel.DataAnnotations.Schema;

namespace Godspeed.Domain.Models.UI
{
  [Table(nameof(Background), Schema = "UI")]
  public class Background
  {
    public int BackgroundID { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string Style { get; set; } = string.Empty;
    public int EntityApplicationID { get; set; }
  }
}
