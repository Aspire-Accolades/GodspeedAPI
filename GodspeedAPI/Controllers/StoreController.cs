using Godspeed.Infrastructure.Helpers;
using GodspeedAPI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace GodspeedAPI.Controllers
{
  public class StoreController : BaseController
  {
    public StoreController(ApplicationHelper applicationHelper) : base(applicationHelper)
    {
    }
  }
}
