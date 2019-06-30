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
            string apiServiceImports = "";
            string serviceImports = "";
            string modelImports = "";
            string dialogImports = "";
            string npmImports = "";
            string ctorInjections = "";
            bool isDialogAdded = false;
            string itemName = replacementsDictionary["$rootname$"];
            itemName = Regex.Replace(itemName, @"\W?(component)?(.ts)?$", "", RegexOptions.IgnoreCase);
            if (string.IsNullOrWhiteSpace(itemName))
            {
                itemName = "component1";
            }
            IEnumerable<string> itemParts = Utilities.Naming.SplitName(itemName);

            ComponentWizardDialog optionsDialog = new ComponentWizardDialog();
            if (!ShowOptionDialog(optionsDialog, replacementsDictionary))
                return;

            _createFiles = true;

            // try to get the selected options and build out the template replacements
            foreach (string item in optionsDialog.SelectedApiServices)
            {
                IEnumerable<string> parts = Utilities.Naming.SplitName(item);
                apiServiceImports += $"\r\nimport {{ {item}ApiService }} from \"src/app/services/{string.Join("-", parts)}-api.service\";";

                ctorInjections += $",\r\n{" ".PadLeft(8)}private {Utilities.Naming.ToCamelCase(parts)}ApiService: {Utilities.Naming.ToPascalCase(parts)}ApiService";
            }
            foreach (string item in optionsDialog.SelectedServices)
            {
                IEnumerable<string> parts = Utilities.Naming.SplitName(item);
                serviceImports += $"\r\nimport {{ {item}Service }} from \"src/app/services/{string.Join("-", parts)}.service\";";

                ctorInjections += $",\r\n{" ".PadLeft(8)}private {Utilities.Naming.ToCamelCase(parts)}Service: {Utilities.Naming.ToPascalCase(parts)}Service";
            }
            foreach (string item in optionsDialog.SelectedModels)
            {
                IEnumerable<string> parts = Utilities.Naming.SplitName(item);
                modelImports += $"\r\nimport {{ {item} }} from \"src/app/models/{Utilities.Naming.ToPascalCase(parts)}\";";

                // models are not injected into the constructor
            }
            foreach (string item in optionsDialog.SelectedDialogs)
            {
                IEnumerable<string> parts = Utilities.Naming.SplitName(item);
                dialogImports += $"\r\nimport {{ {item}DialogComponent }} from \"src/app/dialogs/{string.Join("-", parts)}-dialog/{string.Join("-", parts)}-dialog.component\";";

                if (!isDialogAdded)
                {
                    npmImports += $"\r\nimport {{ MatDialogConfig, MatDialog }} from \"@angular/material\";";

                    // add to the beginning
                    ctorInjections = $",\r\n{" ".PadLeft(8)}private dialog: MatDialog" + ctorInjections;

                    isDialogAdded = true;
                }
            }

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

            // optional files
            replacementsDictionary.Add("$apiImports$", apiServiceImports);
            replacementsDictionary.Add("$serviceImports$", serviceImports);
            replacementsDictionary.Add("$npmImports$", npmImports);
            replacementsDictionary.Add("$modelImports$", modelImports);
            replacementsDictionary.Add("$dialogImports$", dialogImports);

            // additional constructor items - since we have no default items, remove the initial comma
            replacementsDictionary.Add("$constructorInjects$", (string.IsNullOrWhiteSpace(ctorInjections) ? ctorInjections : ctorInjections.Substring(1)));
        }

        public override bool ShouldAddProjectItem(string filePath)
        {
            return _createFiles;
        }
    }
}
