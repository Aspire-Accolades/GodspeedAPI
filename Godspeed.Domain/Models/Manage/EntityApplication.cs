using System.ComponentModel.DataAnnotations.Schema;

namespace Godspeed.Domain.Models.Manage
{
  [Table(nameof(EntityApplication), Schema = "Manage")]
  public class EntityApplication
  {
    public int EntityApplicationID { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Domain { get; set; } = String.Empty;
    public int EntityID { get; set; }
    public DateTime DateAdded { get; set; }
    public string UserAdded { get; set; } = String.Empty;
    public DateTime DateModified { get; set; }
    public string UserModified { get; set; } = String.Empty;
    public EntityApplicationSettings Settings { get; set; }
  }
}
