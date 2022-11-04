namespace GodspeedAPI.Models
{
  public class AuthenticationResponse
  {
    public int Portal { get; set; }
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
