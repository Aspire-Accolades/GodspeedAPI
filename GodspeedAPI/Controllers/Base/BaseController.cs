using Godspeed.Domain.Models.Manage;
using Microsoft.AspNetCore.Mvc;

namespace GodspeedAPI.Controllers.Base
{
  public class BaseController : Controller
  {
    public static Store Store { get; set; }

  }
}
