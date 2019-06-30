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

        protected bool ShowOptionDialog(BaseOptionsDialog optionsDialog, Dictionary<string, string> replacementsDictionary)
        {
            // if they are creating this item outside the ClientApp, allow but don't offer any options
            if (!Utilities.Path.IsInClientApp(replacementsDictionary))
                return true;

            optionsDialog.ApiServices = Utilities.File.GetApiServiceFileNames(replacementsDictionary);
            optionsDialog.Dialogs = Utilities.File.GetDialogFileNames(replacementsDictionary);
            optionsDialog.Models = Utilities.File.GetModelFileNames(replacementsDictionary);
            optionsDialog.Services = Utilities.File.GetServiceFileNames(replacementsDictionary);

            // if there is nothing to choose, skip the dialog
            if (optionsDialog.ApiServices.Count == 0 && optionsDialog.Services.Count == 0 && optionsDialog.Models.Count == 0 && optionsDialog.Dialogs.Count == 0)
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
