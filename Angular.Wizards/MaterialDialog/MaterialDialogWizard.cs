using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Angular.Wizards.MaterialDialog
{
    public class MaterialDialogWizard : BaseWizard
    {
        public override void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            string itemName = replacementsDictionary["$rootname$"];
            itemName = Regex.Replace(itemName, @"\W?(dialog)?(component)?(.ts)?$", "", RegexOptions.IgnoreCase);
            if (string.IsNullOrWhiteSpace(itemName))
            {
                itemName = "component1";
            }
            itemName += "Dialog";
            IEnumerable<string> itemParts = Utilities.Naming.SplitName(itemName);

            CommonOptionsDialog optionsDialog = new CommonOptionsDialog
            {
                Text = "Angular Material Dialog Component Options",
                ShowDialogs = false
            };

            if (!ShowOptionDialog(optionsDialog, replacementsDictionary))
                return;

            _createFiles = true;

            CreateOptionalImports(optionsDialog);

            // if they have selected more than one model, could show second custom dialog to select which is input and which is output(?)

            // folder name
            replacementsDictionary.Add("$folderName$", $"{string.Join("-", itemParts)}");

            // component selector
            replacementsDictionary.Add("$selector$", $"app-{string.Join("-", itemParts)}");

            // the name of the class
            replacementsDictionary.Add("$className$", $"{Utilities.Naming.ToPascalCase(itemParts)}Component");

            // the name of the files
            replacementsDictionary.Add("$tsFileName$", $"{string.Join("-", itemParts)}.component.ts");
            replacementsDictionary.Add("$htmlFileName$", $"{string.Join("-", itemParts)}.component.html");
            replacementsDictionary.Add("$cssFileName$", $"{string.Join("-", itemParts)}.component.scss");

            // the input data type
            replacementsDictionary.Add("$dataInputModelType$", optionsDialog.SelectedModels.Count == 1 ? optionsDialog.SelectedModels.First().Name : "any"); //TODO how to pull this in common dialog

            // the output data type, if any
            replacementsDictionary.Add("$dataOutputModelType$", (optionsDialog.SelectedModels.Count == 1 ? optionsDialog.SelectedModels.First().Name : "any")); //TODO how to pull this in common dialog

            // optional files
            replacementsDictionary.Add("$apiImports$", _apiServiceImports);
            replacementsDictionary.Add("$modelImports$", _modelImports);
            replacementsDictionary.Add("$packageImports$", _packageImports);
            replacementsDictionary.Add("$serviceImports$", _serviceImports);

            // additional constructor items - since we have no default items, remove the initial comma
            replacementsDictionary.Add("$constructorInjects$", _ctorInjections);
        }
    }
}
