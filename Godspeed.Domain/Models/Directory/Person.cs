using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godspeed.Domain.Models.Directory
{
  [Table(nameof(Person), Schema = "Directory")]
  public class Person
  {
    public int PersonID { get; set; }
    public int EntityID { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public DateTime DateAdded { get; set; }
    public string UserAdded { get; set; } = String.Empty;
    public DateTime DateModified { get; set; }
    public string UserModified { get; set; } = String.Empty;
  }
}