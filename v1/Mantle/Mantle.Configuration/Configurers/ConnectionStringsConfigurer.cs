﻿using System.Collections.Generic;
using System.Configuration;

namespace Mantle.Configuration.Configurers
{
    public class ConnectionStringsConfigurer<T> : BaseConfigurer<T>
    {
        public override IEnumerable<ConfigurationSetting> GetConfigurationSettings()
        {
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;

            for (int i = 0; i < connectionStrings.Count; i++)
            {
                var connectionString = connectionStrings[i];
                yield return new ConfigurationSetting(connectionString.Name, connectionString.ConnectionString);
            }
        }
    }
}