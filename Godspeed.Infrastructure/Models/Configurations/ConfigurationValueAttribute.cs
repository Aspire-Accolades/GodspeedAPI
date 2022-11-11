namespace Godspeed.Infrastructure.Models.Configurations
{
  [AttributeUsage(AttributeTargets.Property, Inherited = true)]
  public class ConfigurationValueAttribute : Attribute
  {
    public string ConfigKey { get; set; }

    public bool IsObject { get; set; }
  }
}
