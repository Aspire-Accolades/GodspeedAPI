namespace GodspeedAPI.Models
{
  public class AuthenticationResponse
  {
    public bool IsAuthenticated { get; set; } = false;
    public string? Token { get; set; }
    public string? Message { get; set; }
    public DateTime DateProvided
    {
      get
      {
        return DateTime.UtcNow;
      }
    }
      
  }
}
