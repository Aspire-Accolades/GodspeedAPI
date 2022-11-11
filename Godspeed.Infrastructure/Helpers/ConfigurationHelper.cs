using Godspeed.Domain.Interfaces;
using Godspeed.Infrastructure.Models.Configurations;
using Godspeed.Infrastructure.Models.Configurations.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data.Entity;
using System.Reflection;

namespace Godspeed.Infrastructure.Helpers
{
  public static class ConfigurationHelper
  {
    public static Configuration Get<Configuration>() where Configuration : class, ISysConfig, new()
    {
      Configuration val = new Configuration();
      reflectOnType(val);
      return val;
    }

    public static Configuration Get<Configuration>(IConfiguration configuration) where Configuration : class, ISysConfig, new()
    {
      Configuration val = new Configuration();
      reflectOnType(val,configuration);
      return val;
    }

    public static Configuration GetAuth<Configuration>(IConfiguration configuration) where Configuration : class, IServerAuthConfig, new()
    {
      Configuration val = new Configuration();
      reflectOnType(val,configuration);
      return val;
    }

    public static string GetProperty(string key, IConfiguration configuration)
    {
      if (configuration != null && !string.IsNullOrEmpty(key))
      {
        return configuration.GetSection(key)?.Value;
      }

      return string.Empty;
    }



    private static void reflectOnType<Configuration>(Configuration target, IConfiguration configuration = null)
    {

      Parallel.ForEach(typeof(Configuration).GetProperties(), delegate (PropertyInfo property)
      {
        CustomAttributeData customAttributeData = property.CustomAttributes.FirstOrDefault((CustomAttributeData x) => x.AttributeType == typeof(ConfigurationValueAttribute));
        string key = property.Name;
        if (customAttributeData != null)
        {
          key = ((ConfigurationValueAttribute)Attribute.GetCustomAttribute(property, customAttributeData.AttributeType)).ConfigKey;
        }

        string configProperty = GetProperty(key, configuration);
        setProperty(property, target, configProperty);
      });
    }

    private static void setProperty(PropertyInfo property, object target, string value)
    {
      Type type = property.PropertyType;
      object value2 = null;
      if (string.IsNullOrEmpty(value))
      {
        return;
      }

      try
      {
        if (Nullable.GetUnderlyingType(type) != null)
        {
          type = Nullable.GetUnderlyingType(type);
        }

        if (type == typeof(string))
        {
          value2 = value;
        }

        if (type.BaseType == typeof(Enum))
        {
          value2 = Enum.Parse(property.PropertyType, value);
        }

        if (type == typeof(int))
        {
          value2 = int.Parse(value);
        }

        if (type == typeof(bool))
        {
          value2 = bool.Parse(value);
        }

        if (type == typeof(Guid))
        {
          value2 = Guid.Parse(value);
        }
      }
      catch (Exception ex)
      {
        throw new Exception("Cannot parse value '" + value + "' for property '" + property.Name + "' on Config type '" + target.GetType().Name + "', Exception: " + ex.Message);
      }

      property.SetValue(target, value2);
    }

  }
}