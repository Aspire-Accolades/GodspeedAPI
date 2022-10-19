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
using Tools;

namespace GodspeedAPI.Controllers
{
  public class StandardController : BaseController
  {
    BaseHandler handle;
    public ApplicationSettings _appSettings { get; set; }
    public EntityRepository _entityRepo { get; set; }
    static IConnection connection;
    Fanout fanout;
    public StandardController(Logger logger, ApplicationSettings appSettings, EntityRepository entityRepository)
    {
      handle = new BaseHandler(logger);

      handle._logger.Log("Creating RabbitMQ connection");
      connection = Connection.Create();

      handle._logger.Log("Connection established to " + connection.Endpoint);

      handle._logger.Log("Binding exchanges");
      fanout = new Fanout(connection);
      fanout.SetExchange("aspire.fanout", true, false);
      handle._logger.Log(fanout.Exchange + " Binded");

      _appSettings = appSettings;
      _entityRepo = entityRepository;
    }

    [HttpGet]
    [Route("aspire/settings")]
    public IActionResult GetSettings()
    {
      handle._logger.Log("app settings request");
      return Ok(_appSettings);
    }

    [HttpGet]
    [Route("aspire/entity")]
    public IActionResult GetEntity()
    {
      handle._logger.Log("entity request");
      return Ok(_entityRepo.Current);

    }
  }
}