using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Angular.Wizards.ApiService
{
    public class ApiServiceWizard : BaseWizard
    {
        public override void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            string itemName = replacementsDictionary["$rootname$"];
            itemName = Regex.Replace(itemName, @"\W?(api)?(service)?(.ts)?$", "", RegexOptions.IgnoreCase);
            if (string.IsNullOrWhiteSpace(itemName))
            {
                itemName = "service1";
            }
            IEnumerable<string> itemParts = Utilities.Naming.SplitName(itemName);
            string modelName = Utilities.Naming.ToPascalCase(itemParts);

            // the name of the data model
            replacementsDictionary.Add("$modelName$", modelName);

            // the plural name of the data model
            replacementsDictionary.Add("$modelNamePlural$", Utilities.Naming.Pluralize(modelName));

            // the name of the data model formatted as a parameter
            replacementsDictionary.Add("$modelNameAsParameter$", $"{modelName.Substring(0, 1).ToLower()}{modelName.Substring(1)}");

            // the name of the class
            replacementsDictionary.Add("$className$", $"{modelName}ApiService");

            // the name of the file
            replacementsDictionary.Add("$fileName$", $"{string.Join("-", itemParts)}-api.service.ts");

            // TODO prompt to select models (and services?)
        }

        public override bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
