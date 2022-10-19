using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBox.Databases
{
  internal class StandardBase
  {
    private string Server { get; set; } = string.Empty;
    private string? DatabaseName { get; set; } = string.Empty;
    public string Application { get; set; } = string.Empty;
    public string Enviroment { get; set; } = string.Empty;
    private string DBUser { get; set; } = string.Empty;
    private string DBPassword { get; set; } = string.Empty;

    public string ConnectionString
    {
      get
      {
        return $@"Data Source={Server};Initial Catalog={DatabaseName};User ID={DBUser};Password={DBPassword}";
      }
    }
  }
}
