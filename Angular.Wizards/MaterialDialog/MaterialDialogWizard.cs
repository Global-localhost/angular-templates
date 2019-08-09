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
            string fullItemName = itemName + "Dialog";
            IEnumerable<string> itemParts = Utilities.Naming.SplitName(itemName);
            IEnumerable<string> fullItemParts = Utilities.Naming.SplitName(fullItemName);

            using (CommonOptionsDialog optionsDialog = new CommonOptionsDialog
            {
                Text = "Angular Material Dialog Component Options",
                ShowDialogs = false
            })
            {
                if (!ShowOptionDialog(optionsDialog, replacementsDictionary))
                    return;

                _createFiles = true;

                CreateOptionalImports(optionsDialog);

                // if they have selected more than one model, could show second custom dialog to select which is input and which is output(?)

                // the input data type
                replacementsDictionary.Add("$dataInputModelType$", optionsDialog.SelectedModels.Count == 1 ? optionsDialog.SelectedModels.First().Name : "any"); //TODO how to pull this in common dialog

                // the output data type, if any
                replacementsDictionary.Add("$dataOutputModelType$", (optionsDialog.SelectedModels.Count == 1 ? optionsDialog.SelectedModels.First().Name : "any")); //TODO how to pull this in common dialog
            }

            // folder name
            replacementsDictionary.Add("$folderName$", $"{string.Join("-", fullItemParts)}");

            // component selector
            replacementsDictionary.Add("$selector$", $"app-{string.Join("-", fullItemParts)}");

            // the name of the class
            replacementsDictionary.Add("$className$", $"{Utilities.Naming.ToPascalCase(fullItemParts)}Component");

            // the name of the files
            replacementsDictionary.Add("$tsFileName$", $"{string.Join("-", itemParts)}.dialog-component.ts");
            replacementsDictionary.Add("$htmlFileName$", $"{string.Join("-", itemParts)}.dialog-component.html");
            replacementsDictionary.Add("$cssFileName$", $"{string.Join("-", itemParts)}.dialog-component.scss");

            AddCommonReplacements(replacementsDictionary);

            // additional constructor items - since we have no default items, remove the initial comma
            replacementsDictionary.Add("$constructorInjects$", _ctorInjections);
        }
    }
}
