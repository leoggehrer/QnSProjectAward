//@QnSCodeCopy
//MdStart
using CommonBase.Extensions;
using Microsoft.Extensions.Configuration;

namespace QnSProjectAward.BlazorApp.Modules.Configuration
{
    public static partial class AppSettings
    {
        private static IConfiguration configuration;

        private static IConfiguration Configuration
        {
            get => configuration ??= CommonBase.Modules.Configuration.Configurator.LoadAppSettings();
            set => configuration = value;
        }

        public static void SetConfiguration(IConfiguration configuration)
        {
            configuration.CheckArgument(nameof(configuration));

            Configuration = configuration;
        }

        public static string Get(string key)
        {
            var result = default(string);

            if (Configuration != null)
            {
                result = Configuration[key];
            }
            return result;
        }
        public static string Get(string key, string defaultValue)
        {
            var result = defaultValue;

            if (Configuration != null)
            {
                result = Configuration.GetValue<string>(key, defaultValue);
            }
            return result;
        }
        public static IConfigurationSection GetSection(string key)
        {
            var result = default(IConfigurationSection);

            if (Configuration != null)
            {
                result = Configuration.GetSection(key);
            }
            return result;
        }
    }
}
//MdEnd