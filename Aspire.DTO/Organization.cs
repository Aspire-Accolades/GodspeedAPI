using AspireAPI.Domain.DAL;

namespace Aspire.DTO
{
  public class Organization
  {
    public Entity Entity { get; set; }
    public List<Application> Applications { get; set; }

    public Organization()
    {
      Entity = new Entity();
      Applications = new List<Application>();
    }

  }
}