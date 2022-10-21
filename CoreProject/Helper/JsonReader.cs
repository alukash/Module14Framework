using System;
using System.IO;
using System.Text.Json;

namespace Module14Framework.Helper
{
	public class JsonReader
	{
		static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
		static string browsersJsonFile = projectDirectory + "\\Resources\\" + "Browsers.json";

		public static string Read(string browserType)
		{
			string jsonString = new StreamReader(browsersJsonFile).ReadToEnd();
			string args = null;

			JsonDocument document = JsonDocument.Parse(jsonString);
			JsonElement root = document.RootElement;
			if (root.TryGetProperty(browserType, out JsonElement browserElement))
			{
				foreach (JsonProperty property in browserElement.EnumerateObject())
				{
					args += property.Value.ToString();
				}
			}
			return args;
		}
	}
}
