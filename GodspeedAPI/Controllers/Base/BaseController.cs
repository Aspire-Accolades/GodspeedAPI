using System.Configuration;
using Godspeed.Domain.Models.Manage;
using Godspeed.Infrastructure.Helpers;
using Godspeed.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GodspeedAPI.Controllers.Base
{
  public class BaseController : Controller
  {
    public EntityApplication Application;
    public BaseController(ApplicationHelper applicationHelper)
    {
      Application = applicationHelper.GetApplication();

    }


  }
}
