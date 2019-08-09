using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Wizards.Utilities
{
    public class Settings
    {
        public enum StylesheetFormatType
        {
            Css,
            Less,
            Scss
        }

        public string ComponentSelectorPrefix { get; set; } = "app";

        public string StringDelimiter { get; set; } = "'";

        public StylesheetFormatType StylesheetFormat { get; set; } = StylesheetFormatType.Scss;

        public bool IncludeUnitTests { get; set; } = true;
    }
}
