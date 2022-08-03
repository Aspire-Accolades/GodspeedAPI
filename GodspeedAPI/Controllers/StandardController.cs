using AspireAPI.Domain.DAL;
using AspireAPI.Domain.DAL.DatabaseContext;
using AspireAPI.Domain.DAL.UI;
using AspireAPI.DTO;
using AspireAPI.Infrastructure.Helpers;
using AspireAPI.Infrastructure.Interfaces;
using AspireAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GodspeedAPI.Controllers
{

    public class StandardController : ControllerBase
    {
        private readonly ILogger<StandardController> _logger;

        //properties
        public ApplicationSettings _appSettings { get; set; }
        EntityRepository _entityRepository;
        EntityApplicationRepository _entityApplicationRepository;
        EntityApplicationSettingsRepository _settingRepository;
        NavItemsReporsitory _navRepository;
        BackgroundRepository _backgroundRepository;
        BaseHandler handler = new BaseHandler();

        public StandardController(ILogger<StandardController> logger, AspireDBContext _ctx)
        {
            _logger = logger;
            _appSettings = new ApplicationSettings();
            _entityRepository = new EntityRepository(_ctx);
            _entityApplicationRepository = new EntityApplicationRepository(_ctx);
            _settingRepository = new EntityApplicationSettingsRepository(_ctx);
            _navRepository = new NavItemsReporsitory(_ctx);
            _backgroundRepository = new BackgroundRepository(_ctx);
        }

        [HttpGet]
        [Route("aspire/getSettings")]
        public IActionResult GetSettings(string name, bool isTest)// make a plan with what you start the site with
        {
             handler.TryCatch(true, () =>
            {
                _appSettings.entity = _entityRepository.ReadWhere(x => x.Name == name).FirstOrDefault();
                _appSettings.application = _entityApplicationRepository.ReadWhere(x => x.Name == (isTest ? name + "test" : name)).FirstOrDefault();
                _appSettings.setting = _settingRepository.ReadWhere(x => x.EntityApplicationID == _appSettings.application.EntityApplicationID).FirstOrDefault();
                _appSettings.nav = _navRepository.ReadWhere(x => x.EntityApplicationID == _appSettings.application.EntityApplicationID).ToList();
                _appSettings.background = _backgroundRepository.ReadWhere(x => x.EntityApplicationID == _appSettings.application.EntityApplicationID).FirstOrDefault();
            }, "Error");


            return Ok(_appSettings);


        }
    }
}