using Aspire.Security;
using Aspire.Security.Attributes;
using Aspire.Util;
using AspireAPI.Domain.DAL;
using AspireAPI.Infrastructure.Helpers;
using AspireAPI.Infrastructure.Repositories;
using GodspeedAPI.Controllers.Base;
using GodspeedAPI.Models;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Tools.Producers;
using System.Reflection.Metadata;
using Tools;
using static System.Net.Mime.MediaTypeNames;

namespace GodspeedAPI.Controllers
{
  public class StandardController : BaseController
  {
    IActionResult? result;

    BaseHandler handle;

    public ApplicationSettings _appSettings { get; set; }
    public EntityRepository _entityRepo { get; set; }

    public StandardController(Logger logger, ApplicationSettings appSettings, EntityRepository entityRepository)
    {
      handle = new BaseHandler(logger);
      _appSettings = appSettings;
      _entityRepo = entityRepository;
    }

    [HttpGet]
    [Route("aspire/settings")]
    public IActionResult GetSettings()
    {
      handle._logger.Log("Settings requested for " + _appSettings.application.Name);
      return handle.RequestTryCatch(true, () =>
      {
        result = Ok(_appSettings);
        handle._logger.LogResponse(result);
        return result;

      });
    }

    [HttpGet]
    [Route("aspire/entity")]
    public IActionResult GetEntity()
    {
      handle._logger.Log("Entity requested for " + _appSettings.application.Name);
      return handle.RequestTryCatch(true, () =>
      {
          result = Ok(_appSettings.entity);
          handle._logger.LogResponse(result);
          return result;
        
      });

    }
  }
}