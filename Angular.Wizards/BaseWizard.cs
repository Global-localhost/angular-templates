using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Wizards
{
    public class BaseWizard : IWizard
    {
        protected bool _createFiles = false;
        protected string _apiServiceImports = "";
        protected string _dialogImports = "";
        protected string _modelImports = "";
        protected string _packageImports = "";
        protected string _serviceImports = "";
        protected string _ctorInjections = "";
        protected Utilities.Settings Settings = new Utilities.Settings();

        public virtual void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public virtual void ProjectFinishedGenerating(Project project)
        {
        }

        public virtual void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        public virtual void RunFinished()
        {
        }

        public virtual void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            throw new NotImplementedException();
        }

        public virtual bool ShouldAddProjectItem(string filePath)
        {
            if (!_createFiles)
                return false;

            if (filePath.EndsWith(".spec.ts") && !Settings.IncludeUnitTests)
                return false;

            return true;
        }

        protected void AddCommonReplacements(Dictionary<string, string> replacementsDictionary)
        {
            // settings
            replacementsDictionary.Add("$selectorPrefix$", $"{Settings.ComponentSelectorPrefix}");
            replacementsDictionary.Add("$stringDelimiter$", $"{Settings.StringDelimiter}");

            // optional files
            replacementsDictionary.Add("$apiImports$", _apiServiceImports);
            replacementsDictionary.Add("$dialogImports$", _dialogImports);
            replacementsDictionary.Add("$modelImports$", _modelImports);
            replacementsDictionary.Add("$packageImports$", _packageImports);
            replacementsDictionary.Add("$serviceImports$", _serviceImports);
        }

        /// <summary>
        /// Populates the Imports and Injections class fields based on the selected items of the options dialog.
        /// </summary>
        /// <param name="optionsDialog"></param>
        protected void CreateOptionalImports(CommonOptionsDialog optionsDialog)
        {
            foreach (Utilities.ClassModel item in optionsDialog.SelectedApiServices)
            {
                IEnumerable<string> parts = Utilities.Naming.SplitName(item.Name);
                _apiServiceImports += $"\r\nimport {{ {item.Name}ApiService }} from {Settings.StringDelimiter}{item.ImportPath}{Settings.StringDelimiter};";

                _ctorInjections += $",\r\n{" ".PadLeft(8)}private {Utilities.Naming.ToCamelCase(parts)}ApiService: {Utilities.Naming.ToPascalCase(parts)}ApiService";
            }

            bool isDialogAdded = false;
            foreach (Utilities.ClassModel item in optionsDialog.SelectedDialogs)
            {
                IEnumerable<string> parts = Utilities.Naming.SplitName(item.Name);
                _dialogImports += $"\r\nimport {{ {item.Name}DialogComponent }} from {Settings.StringDelimiter}{item.ImportPath}{Settings.StringDelimiter};";

                if (!isDialogAdded)
                {
                    _packageImports += $"\r\nimport {{ MatDialogConfig, MatDialog }} from {Settings.StringDelimiter}@angular/material{Settings.StringDelimiter};";

                    // add to the beginning
                    _ctorInjections = $",\r\n{" ".PadLeft(8)}private dialog: MatDialog" + _ctorInjections;

                    isDialogAdded = true;
                }
            }

            if (optionsDialog.SelectedModels.Count > 0)
            {
                // the final list used to generate the actual code
                ICollection<Utilities.ClassModel> models = new List<Utilities.ClassModel>();

                // are there multiple models from the same file?
                if (optionsDialog.SelectedModels.Select(c => c.ImportPath).Distinct().Count() != optionsDialog.SelectedModels.Count)
                {
                    // if the path already exists, just add the new class to the name so it gets generated together
                    foreach (Utilities.ClassModel item in optionsDialog.SelectedModels)
                    {
                        if (models.Count(c => c.ImportPath == item.ImportPath) > 0)
                            models.First(c => c.ImportPath == item.ImportPath).Name += $", {item.Name}";
                        else
                            models.Add(item);
                    }
                }
                else
                {
                    // no overlaps, just copy the collection
                    models = optionsDialog.SelectedModels;
                }

                foreach (Utilities.ClassModel item in models)
                {
                    _modelImports += $"\r\nimport {{ {item.Name} }} from {Settings.StringDelimiter}{item.ImportPath}{Settings.StringDelimiter};";

                    // models are not injected into the constructor
                }
            }

            foreach (Utilities.ClassModel item in optionsDialog.SelectedServices)
            {
                IEnumerable<string> parts = Utilities.Naming.SplitName(item.Name);
                _serviceImports += $"\r\nimport {{ {item.Name}Service }} from {Settings.StringDelimiter}{item.ImportPath}{Settings.StringDelimiter};";

                _ctorInjections += $",\r\n{" ".PadLeft(8)}private {Utilities.Naming.ToCamelCase(parts)}Service: {Utilities.Naming.ToPascalCase(parts)}Service";
            }
        }

        /// <summary>
        /// Shows the <see cref="CommonOptionsDialog"/>. Use the "ShowXxx" properties on the dialog to exclude types of files/classes
        /// that can be referenced by the new file.
        /// </summary>
        /// <param name="optionsDialog"></param>
        /// <param name="replacementsDictionary"></param>
        /// <returns></returns>
        protected bool ShowOptionDialog(CommonOptionsDialog optionsDialog, Dictionary<string, string> replacementsDictionary)
        {
            // if they are creating this item outside the angular app root, allow but don't offer any options
            if (!Utilities.Path.IsInAngularApp(replacementsDictionary))
                return true;

            if (optionsDialog.ShowApiServices)
                optionsDialog.ApiServices = Utilities.File.GetApiServices(replacementsDictionary);
            if (optionsDialog.ShowDialogs)
                optionsDialog.Dialogs = Utilities.File.GetDialogs(replacementsDictionary);
            if (optionsDialog.ShowModels)
                optionsDialog.Models = Utilities.File.GetModels(replacementsDictionary);
            if (optionsDialog.ShowServices)
                optionsDialog.Services = Utilities.File.GetServices(replacementsDictionary);

            // if there is nothing to choose, skip the dialog
            if ((!optionsDialog.ShowApiServices || optionsDialog.ApiServices.Count == 0)
                && (!optionsDialog.ShowServices || optionsDialog.Services.Count == 0)
                && (!optionsDialog.ShowModels || optionsDialog.Models.Count == 0)
                && (!optionsDialog.ShowDialogs || optionsDialog.Dialogs.Count == 0))
                return true;

            optionsDialog.ApiServices.ToList().Sort();
            optionsDialog.Services.ToList().Sort();
            optionsDialog.Models.ToList().Sort();
            optionsDialog.Dialogs.ToList().Sort();

            System.Windows.Forms.DialogResult dialogResult = optionsDialog.ShowDialog();
            if (dialogResult != System.Windows.Forms.DialogResult.OK)
                return false;

            return true;
        }

    }
}
