using AspireAPI.Domain.DAL;
using AspireAPI.Domain.DAL.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspire.DTO
{
  public class Application : EntityApplication
  {
    public int Portal { get; set; }
    public List<NavLinks> Links { get; set; }
    public List<Forms> Forms { get; set; }
    public Background Background { get; set; }
    public EntityApplicationSettings Settings { get; set; }

    public Application()
    {
      Links = new List<NavLinks>();
      Forms = new List<Forms>();
      Background = new Background();
      Settings = new EntityApplicationSettings();

    }

  }
}
