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

            CommonOptionsDialog optionsDialog = new CommonOptionsDialog
            {
                Text = "Angular Service Class Options",
                ShowDialogs = false
            };
            if (!ShowOptionDialog(optionsDialog, replacementsDictionary))
                return;

            _createFiles = true;

            CreateOptionalImports(optionsDialog);

            // the name of the class
            replacementsDictionary.Add("$className$", $"{Utilities.Naming.ToPascalCase(itemParts)}Service");

            // the name of the file
            replacementsDictionary.Add("$fileName$", $"{string.Join("-", itemParts)}.service.ts");

            // the name of the file to use when importing
            replacementsDictionary.Add("$importFileName$", $"{string.Join("-", itemParts)}.service");

            // the name of the unit test file
            replacementsDictionary.Add("$specFileName$", $"{string.Join("-", itemParts)}.service.spec.ts");

            // optional files
            replacementsDictionary.Add("$apiImports$", _apiServiceImports);
            replacementsDictionary.Add("$dialogImports$", _dialogImports);
            replacementsDictionary.Add("$modelImports$", _modelImports);
            replacementsDictionary.Add("$packageImports$", _packageImports);
            replacementsDictionary.Add("$serviceImports$", _serviceImports);

            // additional constructor items - since we have no default items, remove the initial comma
            replacementsDictionary.Add("$constructorInjects$", (string.IsNullOrWhiteSpace(_ctorInjections) ? _ctorInjections : _ctorInjections.Substring(1)));
        }
    }
}
