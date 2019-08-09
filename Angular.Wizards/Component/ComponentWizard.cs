using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Angular.Wizards.Component
{
    public class ComponentWizard : BaseWizard
    {
        public override void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            string itemName = replacementsDictionary["$rootname$"];
            itemName = Regex.Replace(itemName, @"\W?(component)?(.ts)?$", "", RegexOptions.IgnoreCase);
            if (string.IsNullOrWhiteSpace(itemName))
            {
                itemName = "component1";
            }
            IEnumerable<string> itemParts = Utilities.Naming.SplitName(itemName);

            CommonOptionsDialog optionsDialog = new CommonOptionsDialog
            {
                Text = "Angular Component Options"
            };

            if (!ShowOptionDialog(optionsDialog, replacementsDictionary))
                return;

            _createFiles = true;

            CreateOptionalImports(optionsDialog);

            // folder name
            replacementsDictionary.Add("$folderName$", $"{string.Join("-", itemParts)}");

            // component selector
            replacementsDictionary.Add("$selector$", $"{Settings.ComponentSelectorPrefix }-{string.Join("-", itemParts)}");

            // the name of the class
            replacementsDictionary.Add("$className$", $"{Utilities.Naming.ToPascalCase(itemParts)}Component");

            // the name of the files
            replacementsDictionary.Add("$tsFileName$", $"{string.Join("-", itemParts)}.component.ts");
            replacementsDictionary.Add("$htmlFileName$", $"{string.Join("-", itemParts)}.component.html");
            replacementsDictionary.Add("$cssFileName$", $"{string.Join("-", itemParts)}.component.{Settings.StylesheetFormat.ToString().ToLower()}");

            AddCommonReplacements(replacementsDictionary);

            // additional constructor items - since we have no default items, remove the initial comma
            replacementsDictionary.Add("$constructorInjects$", (string.IsNullOrWhiteSpace(_ctorInjections) ? _ctorInjections : _ctorInjections.Substring(1)));
        }
    }
}
