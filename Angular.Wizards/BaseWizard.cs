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
            return _createFiles;
        }

        /// <summary>
        /// Populates the Imports and Injections class fields based on the selected items of the options dialog.
        /// </summary>
        /// <param name="optionsDialog"></param>
        protected void CreateOptionalImports(CommonOptionsDialog optionsDialog)
        {
            foreach (string item in optionsDialog.SelectedApiServices)
            {
                IEnumerable<string> parts = Utilities.Naming.SplitName(item);
                _apiServiceImports += $"\r\nimport {{ {item}ApiService }} from \"src/app/services/{string.Join("-", parts)}-api.service\";";

                _ctorInjections += $",\r\n{" ".PadLeft(8)}private {Utilities.Naming.ToCamelCase(parts)}ApiService: {Utilities.Naming.ToPascalCase(parts)}ApiService";
            }

            bool isDialogAdded = false;
            foreach (string item in optionsDialog.SelectedDialogs)
            {
                IEnumerable<string> parts = Utilities.Naming.SplitName(item);
                _dialogImports += $"\r\nimport {{ {item}DialogComponent }} from \"src/app/dialogs/{string.Join("-", parts)}-dialog/{string.Join("-", parts)}-dialog.component\";";

                if (!isDialogAdded)
                {
                    _packageImports += $"\r\nimport {{ MatDialogConfig, MatDialog }} from \"@angular/material\";";

                    // add to the beginning
                    _ctorInjections = $",\r\n{" ".PadLeft(8)}private dialog: MatDialog" + _ctorInjections;

                    isDialogAdded = true;
                }
            }

            foreach (string item in optionsDialog.SelectedModels)
            {
                IEnumerable<string> parts = Utilities.Naming.SplitName(item);
                _modelImports += $"\r\nimport {{ {item} }} from \"src/app/models/{Utilities.Naming.ToPascalCase(parts)}\";";

                // models are not injected into the constructor
            }

            foreach (string item in optionsDialog.SelectedServices)
            {
                IEnumerable<string> parts = Utilities.Naming.SplitName(item);
                _serviceImports += $"\r\nimport {{ {item}Service }} from \"src/app/services/{string.Join("-", parts)}.service\";";

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
            // if they are creating this item outside the ClientApp, allow but don't offer any options
            if (!Utilities.Path.IsInClientApp(replacementsDictionary))
                return true;

            if (optionsDialog.ShowApiServices)
                optionsDialog.ApiServices = Utilities.File.GetApiServiceFileNames(replacementsDictionary);
            if (optionsDialog.ShowDialogs)
                optionsDialog.Dialogs = Utilities.File.GetDialogFileNames(replacementsDictionary);
            if (optionsDialog.ShowModels)
                optionsDialog.Models = Utilities.File.GetModelFileNames(replacementsDictionary);
            if (optionsDialog.ShowServices)
                optionsDialog.Services = Utilities.File.GetServiceFileNames(replacementsDictionary);

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
