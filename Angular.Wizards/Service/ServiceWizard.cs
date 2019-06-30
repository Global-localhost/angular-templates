using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Angular.Wizards.Service
{
    public class ServiceWizard : BaseWizard
    {
        public override void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            string itemName = replacementsDictionary["$rootname$"];
            itemName = Regex.Replace(itemName, @"\W?(service)?(.ts)?$", "", RegexOptions.IgnoreCase);
            if (string.IsNullOrWhiteSpace(itemName))
            {
                itemName = "service1";
            }
            IEnumerable<string> itemParts = Utilities.Naming.SplitName(itemName);

            // the name of the class
            replacementsDictionary.Add("$className$", $"{Utilities.Naming.ToPascalCase(itemParts)}Service");

            // the name of the file
            replacementsDictionary.Add("$fileName$", $"{string.Join("-", itemParts)}.service.ts");
        }

        public override bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
