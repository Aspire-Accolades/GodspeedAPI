using Godspeed.Domain.Models.Manage;
using Godspeed.Domain.Models.UI;
using Godspeed.Infrastructure.Helpers;
using Godspeed.Infrastructure.Repositories;
using GodspeedAPI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace GodspeedAPI.Controllers
{
  public class UIController : BaseController
  {
    readonly BackgroundRepository backgroundRepository;
    readonly NavItemsReporsitory navItemsReporsitory;
    readonly FormRepository formRepository;
    public UIController(ApplicationHelper appHelper, 
                        BackgroundRepository backgroundRepository, 
                        NavItemsReporsitory navItemsReporsitory, 
                        FormRepository formRepository)
      : base(appHelper)
    {

      this.backgroundRepository = backgroundRepository;
      this.navItemsReporsitory = navItemsReporsitory;
      this.formRepository = formRepository;
    }
    
    [HttpGet]
    [Route("ui/background")]
    public IActionResult GetBackground()
    {
      Background background = backgroundRepository.ReadWhere(x => x.EntityApplicationID == Application.EntityApplicationID).FirstOrDefault();
      return Ok(background);
    }

    [HttpGet]
    [Route("ui/nav")]
    public IActionResult GetNavItems()
    {
      IEnumerable<NavLinks> navItems = navItemsReporsitory.ReadWhere(x => x.EntityApplicationID == Application.EntityApplicationID);
      return Ok(navItems);
    }

    [HttpGet]
    [Route("ui/forms")]
    public IActionResult GetFormsStyles()
    {
      IEnumerable<Forms> forms = formRepository.ReadWhere(x => x.EntityApplicationID == Application.EntityApplicationID);
      return Ok(forms);
    }

    [HttpGet]
    [Route("ui/system")]
    public IActionResult GetSystem()
    {
      Background background = backgroundRepository.ReadWhere(x => x.EntityApplicationID == Application.EntityApplicationID).FirstOrDefault();
      IEnumerable<NavLinks> navItems = navItemsReporsitory.ReadWhere(x => x.EntityApplicationID == Application.EntityApplicationID);
      IEnumerable<Forms> forms = formRepository.ReadWhere(x => x.EntityApplicationID == Application.EntityApplicationID);

      return Ok(new
      {
        Application,
        background,
        navItems,
        forms
      });
    }


  }
}
