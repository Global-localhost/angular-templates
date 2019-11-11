using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Wizards.Utilities
{
    public class Settings
    {
        private static ICollection<Settings> _settings = new HashSet<Settings>();

        public enum StylesheetFormatType
        {
            Css,
            Less,
            Scss
        }

        public string SolutionName { get; set; } = "";

        public string ComponentSelectorPrefix { get; set; } = "app";

        public string StringDelimiter { get; set; } = "'";

        [JsonConverter(typeof(StringEnumConverter))]
        public StylesheetFormatType StylesheetFormat { get; set; } = StylesheetFormatType.Scss;

        public bool IncludeUnitTests { get; set; } = true;

        public SettingsModels.ApiService ApiServiceSettings { get; set; } = new SettingsModels.ApiService();

        [JsonIgnore]
        public string FilePath
        {
            get
            {
                return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Holographic Blockchain", "angular-file-templates-settings.json");
            }
        }

        /// <summary>
        /// Loads the global settings file.
        /// </summary>
        /// <returns></returns>
        public static Settings LoadGlobal()
        {
            Settings settings = new Settings();

            if (System.IO.File.Exists(settings.FilePath))
            {
                string s = System.IO.File.ReadAllText(settings.FilePath);
                _settings = JsonConvert.DeserializeObject<ICollection<Settings>>(s);
                if (_settings.Any(e => e.SolutionName == ""))
                    settings = _settings.First(e => e.SolutionName == "");
            }

            return settings;
        }

        /// <summary>
        /// Loads the solution-specific if one exists, else the global settings.
        /// </summary>
        /// <returns></returns>
        public static Settings LoadSolution()
        {
            // if solution settings does not exist, just chain to LoadGlobal
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the current settings as the global settings.
        /// </summary>
        public void SaveAsGlobal()
        {
            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(FilePath)))
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(FilePath));

            if (!_settings.Any(e => e.SolutionName == ""))
                _settings.Add(new Settings()
                {
                    ApiServiceSettings = new SettingsModels.ApiService()
                    {
                        IncludeSampleCode = this.IncludeUnitTests
                    },
                    ComponentSelectorPrefix = this.ComponentSelectorPrefix,
                    IncludeUnitTests = this.IncludeUnitTests,
                    SolutionName = "",
                    StringDelimiter = StringDelimiter,
                    StylesheetFormat = StylesheetFormat
                });

            Settings settings = _settings.First(e => e.SolutionName == "");
            settings.ApiServiceSettings.IncludeSampleCode = ApiServiceSettings.IncludeSampleCode;
            settings.ComponentSelectorPrefix = ComponentSelectorPrefix;
            settings.IncludeUnitTests = IncludeUnitTests;
            settings.SolutionName = "";
            settings.StringDelimiter = StringDelimiter;
            settings.StylesheetFormat = StylesheetFormat;

            System.IO.File.WriteAllText(FilePath, JsonConvert.SerializeObject(_settings));
        }

        /// <summary>
        /// Saves the current settings as the solution's settings.
        /// </summary>
        public void SaveAsSolution()
        {
            throw new NotImplementedException();
        }
    }
}
