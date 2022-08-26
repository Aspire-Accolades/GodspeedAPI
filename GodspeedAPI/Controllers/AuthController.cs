using Aspire.Security;
using AspireAPI.Domain.DAL;
using AspireAPI.Infrastructure.Enums;
using AspireAPI.Infrastructure.Repositories;
using GodspeedAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace GodspeedAPI.Controllers
{
  public class AuthController : Controller
  {
    public ApplicationSettings _appSettings { get; set; }
    PersonRepository _personRepo;
    EntityApplicationUserRepository _userRepository;
    PasswordRepository _passwordRepository;

    bool _isAuthenticated;
    public AuthController(ILogger<AuthController> logger, ApplicationSettings appSettings, PersonRepository personRepository, EntityApplicationUserRepository entityApplicationUserRepository, PasswordRepository passwordRepository)
    {
      _appSettings = appSettings;
      _personRepo = personRepository;
      _userRepository = entityApplicationUserRepository;
      _passwordRepository = passwordRepository;
    }
    [HttpPost]
    [Route("auth/register")]
    public IActionResult Register([FromBody] UserRegistration UserRegistration)
    {
      Person person = new Person();
      person.FirstName = UserRegistration.FirstName;
      person.LastName = UserRegistration.LastName;
      person.Email = UserRegistration.Email;
      person.Mobile = UserRegistration.Mobile;
      person.EntityID = _appSettings.entity.EntityID;
      person.DateAdded = DateTime.UtcNow;
      person.UserAdded = "Godspeed API";
      person.DateModified = DateTime.UtcNow;
      person.UserModified = "Godspeed API";

      person = _personRepo.Create(person);
      EntityApplicationUser user = new EntityApplicationUser
      {
        EntityApplicationID = _appSettings.application.EntityApplicationID,
        PersonID = person.PersonID,
        Role = (int)ApplicationRoleEnum.Administrator,
        AlternateID = Guid.NewGuid().ToString(),
        DateAdded = DateTime.UtcNow,
        UserAdded = "Godspeed API",
        DateModified = DateTime.UtcNow,
        UserModified = "Godspeed API"
      };
      user = _userRepository.Create(user);
      byte[] tokenBytes = Encoding.ASCII.GetBytes(person.Email + user.EntityApplicationUserID + UserRegistration.Password);

      Password auth = new Password
      {
        EntityApplicationUserID = user.EntityApplicationUserID,
        Token = BitConverter.ToString(tokenBytes).Replace("-", "").ToUpper(),
        password = AuthTools.Hash(UserRegistration.Password),
        DateAdded = DateTime.UtcNow,
        UserAdded = "Godspeed API",
        DateModified = DateTime.UtcNow,
        UserModified = "Godspeed API"

      };
      _passwordRepository.Create(auth);

      return Ok(user);
    }

    [HttpGet]
    [Route("auth/login")]
    public IActionResult Login(string email, string password)
    {
      Person person = _personRepo.ReadWhere(x => x.Email == email).FirstOrDefault();
      if (person != null)
      {
        EntityApplicationUser user = _userRepository.ReadWhere(x => x.PersonID == person.PersonID).FirstOrDefault();
        Password userPassword = _passwordRepository.ReadWhere(x => x.EntityApplicationUserID == user.EntityApplicationUserID).FirstOrDefault();
        password = AuthTools.Hash(password);

        if (AuthTools.ConfirmPassword(password, userPassword.password))
        {
          _isAuthenticated = true;
          return Ok(user);
        }
        else
        {
          return BadRequest("Incorrect password");
        }

      }
      else
      {
        return NotFound();
      }
    }



    public IActionResult Index()
    {
      return View();
    }
  }
}
