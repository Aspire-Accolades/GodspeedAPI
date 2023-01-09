using System.ComponentModel.DataAnnotations.Schema;

namespace Godspeed.Domain.Models.Manage
{
  [Table(nameof(Store), Schema = "Manage")]
  public class Store
  {
    public int StoreID { get; set; }
    public Guid AlternateID { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Domain { get; set; } = String.Empty;
    public DateTime DateAdded { get; set; }
    public string UserAdded { get; set; } = String.Empty;
    public DateTime DateModified { get; set; }
    public string UserModified { get; set; } = String.Empty;
  }
}
