using AspireAPI.Domain.DAL;

namespace GodspeedAPI.Models
{
  public class UserRegistration : Person
  {
    public string Password { get; set; } = string.Empty;
  }
}
