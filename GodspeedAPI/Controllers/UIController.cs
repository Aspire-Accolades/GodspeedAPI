using AspireAPI.Domain.DAL;
using AspireAPI.Domain.DAL.UI;
using AspireAPI.Infrastructure.Helpers;
using AspireAPI.Infrastructure.Repositories;
using GodspeedAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata;

namespace GodspeedAPI.Controllers
{
  public class UIController : Controller
  {
    BaseHandler _handler;
    BackgroundRepository _backgroundRepository;
    NavItemsReporsitory _navItemsReporsitory;
    FormRepository _formRepository;
    EntityApplication _application = new EntityApplication();
    IActionResult result;


    public UIController(BaseHandler handler, ApplicationSettings applicationSettings, BackgroundRepository backgroundRepo, NavItemsReporsitory navItemsRepo, FormRepository formRepo)
    {

      _handler = handler;
      _backgroundRepository = backgroundRepo;
      _navItemsReporsitory = navItemsRepo;
      _formRepository = formRepo;
      _application = applicationSettings.application;
    }

    [HttpGet]
    [Route("ui/background")]
    public IActionResult GetBackground()
    {
      _handler._logger.Log("Background requested for " + _application.Name);
     return _handler.RequestTryCatch(true, () =>
      {
        Background background = _backgroundRepository.ReadWhere(x => x.EntityApplicationID == _application.EntityApplicationID).FirstOrDefault();

        if(background == null)
        {
          result = BadRequest();
          return result;
        }
        else
        {
       
          result = Ok(background);
          _handler._logger.LogResponse(result);
          return result;
        }
      });

    }
  }
}
