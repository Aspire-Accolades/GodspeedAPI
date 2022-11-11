using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godspeed.Domain.Models.Directory
{
  [Table(nameof(Address), Schema = "Directory")]
  public class Address
  {
    public int AddressID { get; set; }
    public string StreetName { get; set; } = string.Empty;
    public string StreetNumber { get; set; } = string.Empty;
    public string Surburb { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Province { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public int AreaCode { get; set; }
    public string Estate { get; set; } = string.Empty;
    public int UnitNumber { get; set; }
    public DateTime DateAdded { get; set; }
    public string UserAdded { get; set; } = String.Empty;
    public DateTime DateModified { get; set; }
    public string UserModified { get; set; } = String.Empty;
  }
}
