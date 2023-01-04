using Godspeed.Domain.Models.Manage;
using Godspeed.Domain.Models.UI;
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
    readonly StoreRepository storeRepository;
    public UIController(
                        BackgroundRepository backgroundRepository, 
                        NavItemsReporsitory navItemsReporsitory, 
                        FormRepository formRepository,
                        StoreRepository storeRepository)
    {

      this.backgroundRepository = backgroundRepository;
      this.navItemsReporsitory = navItemsReporsitory;
      this.formRepository = formRepository;
      this.storeRepository = storeRepository;
    }

    [HttpGet]
    [Route("ui/store")]
    public IActionResult GetStore()
    {
      Store store = storeRepository.ReadAll().FirstOrDefault();
      return Ok(store);
    }


    //[HttpGet]
    //[Route("ui/background")]
    //public IActionResult GetBackground()
    //{
    //  Background background = backgroundRepository.ReadWhere(x => x.EntityApplicationID == Store.EntityApplicationID).FirstOrDefault();
    //  return Ok(background);
    //}

    //[HttpGet]
    //[Route("ui/nav")]
    //public IActionResult GetNavItems()
    //{
    //  IEnumerable<NavLinks> navItems = navItemsReporsitory.ReadWhere(x => x.EntityApplicationID == Store.EntityApplicationID);
    //  return Ok(navItems);
    //}

    //[HttpGet]
    //[Route("ui/forms")]
    //public IActionResult GetFormsStyles()
    //{
    //  IEnumerable<Forms> forms = formRepository.ReadWhere(x => x.EntityApplicationID == Store.EntityApplicationID);
    //  return Ok(forms);
    //}

    //[HttpGet]
    //[Route("ui/system")]
    //public IActionResult GetSystem()
    //{
    //  Background background = backgroundRepository.ReadWhere(x => x.EntityApplicationID == Store.EntityApplicationID).FirstOrDefault();
    //  IEnumerable<NavLinks> navItems = navItemsReporsitory.ReadWhere(x => x.EntityApplicationID == Store.EntityApplicationID);
    //  IEnumerable<Forms> forms = formRepository.ReadWhere(x => x.EntityApplicationID == Store.EntityApplicationID);

    //  return Ok(new
    //  {
    //    Store,
    //    background,
    //    navItems,
    //    forms
    //  });
    //}


  }
}
