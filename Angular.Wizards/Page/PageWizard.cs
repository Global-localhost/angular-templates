using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Angular.Wizards.Page
{
    public class PageWizard : BaseWizard
    {
        public override void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            string itemName = replacementsDictionary["$rootname$"];
            itemName = Regex.Replace(itemName, @"\W?(page)?(component)?(.ts)?$", "", RegexOptions.IgnoreCase);
            if (string.IsNullOrWhiteSpace(itemName))
            {
                itemName = "component1";
            }
            string fullItemName = itemName + "Page";
            IEnumerable<string> itemParts = Utilities.Naming.SplitName(itemName);
            IEnumerable<string> fullItemParts = Utilities.Naming.SplitName(fullItemName);

            CommonOptionsDialog optionsDialog = new CommonOptionsDialog
            {
                Text = "Angular Page Component Options"
            };

            if (!ShowOptionDialog(optionsDialog, replacementsDictionary))
                return;

            _createFiles = true;

            CreateOptionalImports(optionsDialog);

            // folder name
            replacementsDictionary.Add("$folderName$", $"{string.Join("-", fullItemParts)}");

            // component selector
            replacementsDictionary.Add("$selector$", $"app-{string.Join("-", fullItemParts)}");

            // the name of the class
            replacementsDictionary.Add("$className$", $"{Utilities.Naming.ToPascalCase(fullItemParts)}Component");

            // the name of the files
            replacementsDictionary.Add("$tsFileName$", $"{string.Join("-", itemParts)}.page-component.ts");
            replacementsDictionary.Add("$htmlFileName$", $"{string.Join("-", itemParts)}.page-component.html");
            replacementsDictionary.Add("$cssFileName$", $"{string.Join("-", itemParts)}.page-component.scss");

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
