using System.Configuration;

namespace Module14Framework.Base
{
	internal class Configuration
	{
		public static string GetEnvVar(string key, string defaultValue)
		{
			return ConfigurationManager.AppSettings[key] ?? defaultValue;
		}

		public static string Browser => GetEnvVar("Browser", "Chrome");

		public static string Timeout => GetEnvVar("Timeout", "20");

		public static string TimeoutMin => GetEnvVar("Timeout", "5");

	}
}
