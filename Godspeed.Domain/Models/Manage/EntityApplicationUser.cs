using System.ComponentModel.DataAnnotations.Schema;

namespace Godspeed.Domain.Models.Manage
{
  [Table(nameof(EntityApplicationUser), Schema = "Manage")]
  public class EntityApplicationUser
  {
    public int EntityApplicationUserID { get; set; }
    public int EntityApplicationID { get; set; }
    public int PersonID { get; set; }
    public int Role { get; set; }
    public string AlternateID { get; set; } = String.Empty;
    public DateTime DateAdded { get; set; }
    public string UserAdded { get; set; } = String.Empty;
    public DateTime DateModified { get; set; }
    public string UserModified { get; set; } = String.Empty;
  }
}
