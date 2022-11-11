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
    public static Config Get<Config>() where Config : class, ISysConfig, new()
    {
      Config val = new Config();
      reflectConfigToObject(val);
      return val;
    }

    public static Config Get<Config>(IConfiguration configuration) where Config : class, ISysConfig, new()
    {
      Config val = new Config();
      reflectConfigToObject(val, null, null, configuration);
      return val;
    }

    public static Config GetAuth<Config>(IConfiguration configuration) where Config : class, IServerAuthConfig, new()
    {
      Config val = new Config();
      reflectConfigToObject(val, null, null, configuration);
      return val;
    }

    public static Config GetBrokerConfig<Config>(AppSettingsSection appSettings) where Config : class, ISysConfig, new()
    {
      Config val = new Config();
      reflectConfigToObject(val, null, appSettings);
      return val;
    }

    public static ISysConfig GetBrokerConfig(Type config)
    {
      if (typeof(ISysConfig).IsAssignableFrom(config))
      {
        ISysConfig obj = (ISysConfig)Activator.CreateInstance(config);
        reflectConfigToObject(obj, config);
        return obj;
      }

      throw new Exception("The provided type " + config.Name + " cannot be used for configuration");
    }


    public static string GetConfigProperty(string key, AppSettingsSection appSettings = null, IConfiguration configuration = null)
    {
      if (configuration != null && !string.IsNullOrEmpty(key))
      {
        return configuration.GetSection(key)?.Value;
      }

      if (appSettings != null && appSettings.Settings.AllKeys.Any((string x) => x == key))
      {
        return appSettings.Settings[key].Value;
      }

      if (ConfigurationManager.AppSettings.AllKeys.Any((string x) => x == key))
      {
        return ConfigurationManager.AppSettings[key];
      }

      return string.Empty;
    }

    public static Config CopyConfig<Config>(Config config, bool reflectClasses = false) where Config : class, new()
    {
      Config copy = new Config();
      Parallel.ForEach(typeof(Config).GetProperties(), delegate (PropertyInfo prop)
      {
        object value = prop.GetValue(config);
        if (reflectClasses && value.GetType().IsClass && !value.GetType().IsEnum && !(value.GetType() == typeof(string)))
        {
          makeGenericMethod(value.GetType(), "CopyConfig").Invoke(null, new object[2] { value, reflectClasses });
        }

        prop.SetValue(copy, value);
      });
      return copy;
    }

    private static void reflectConfigToObject<Config>(Config target, Type reflectType = null, AppSettingsSection appSettings = null, IConfiguration configuration = null)
    {
      PropertyInfo[] array = null;
      array = ((!(reflectType == null)) ? reflectType.GetProperties() : typeof(Config).GetProperties());
      Parallel.ForEach(array, delegate (PropertyInfo property)
      {
        CustomAttributeData customAttributeData = property.CustomAttributes.FirstOrDefault((CustomAttributeData x) => x.AttributeType == typeof(ConfigurationValueAttribute));
        string key = property.Name;
        if (customAttributeData != null)
        {
          key = ((ConfigurationValueAttribute)Attribute.GetCustomAttribute(property, customAttributeData.AttributeType)).ConfigKey;
        }

        string configProperty = GetConfigProperty(key, appSettings, configuration);
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

    private static MethodInfo makeGenericMethod(Type genericType, string methodName)
    {
      return typeof(ConfigurationHelper).GetMethod(methodName).MakeGenericMethod(genericType);
    }
  }
}