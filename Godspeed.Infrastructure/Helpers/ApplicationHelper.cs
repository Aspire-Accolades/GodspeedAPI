using Godspeed.Domain.Models.Manage;
using Godspeed.Infrastructure.Models.Configurations;
using Godspeed.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godspeed.Infrastructure.Helpers
{
  public class ApplicationHelper
  {
    readonly EntityApplicationRepository entityApplicationRepository;
    readonly EntityApplicationSettingsRepository entityApplicationSettingsRepository;
    readonly IConfiguration configuration;
    public ApplicationHelper(IConfiguration configuration, EntityApplicationRepository entityApplicationRepository, EntityApplicationSettingsRepository entityApplicationSettingsRepository)
    {
      this.configuration = configuration;
      this.entityApplicationRepository = entityApplicationRepository;
      this.entityApplicationSettingsRepository = entityApplicationSettingsRepository;



    }
    public EntityApplication GetApplication()
    {
      string storeName = ConfigurationHelper.Get<GodspeedConfig>(configuration).Store.ToLower();
      EntityApplication entityApplication = entityApplicationRepository.ReadWhere(x => x.Name.ToLower() == storeName).FirstOrDefault();
      if (entityApplication != null)
      {
        entityApplication.Settings = entityApplicationSettingsRepository.ReadWhere(x => x.EntityApplicationID == entityApplication.EntityApplicationID).FirstOrDefault();
        return entityApplication;
      }
      else
        return null;

    }
  }
}

