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

            CommonOptionsDialog optionsDialog = new CommonOptionsDialog
            {
                Text = "Angular API Service Class Options",
                ShowDialogs = false
            };
            if (!ShowOptionDialog(optionsDialog, replacementsDictionary))
                return;

            _createFiles = true;

            // if the model wasn't selected to be included, automatically add it to the imports. It may be incorrect but the sample code requires it.
            if (!optionsDialog.SelectedModels.Contains(modelName))
                optionsDialog.SelectedModels.Add(modelName);

            CreateOptionalImports(optionsDialog);

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

            // optional files
            replacementsDictionary.Add("$apiImports$", _apiServiceImports);
            replacementsDictionary.Add("$modelImports$", _modelImports);
            replacementsDictionary.Add("$packageImports$", _packageImports);
            replacementsDictionary.Add("$serviceImports$", _serviceImports);

            // additional constructor items
            replacementsDictionary.Add("$constructorInjects$", _ctorInjections);
        }

        public override bool ShouldAddProjectItem(string filePath)
        {
            return _createFiles;
        }
    }
}
