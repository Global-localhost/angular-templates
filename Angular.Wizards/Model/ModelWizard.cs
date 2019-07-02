using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Angular.Wizards.Model
{
    public class ModelWizard : BaseWizard
    {
        public override void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            string itemName = replacementsDictionary["$rootname$"];
            itemName = Regex.Replace(itemName, @"\W?(.ts)?$", "", RegexOptions.IgnoreCase);
            if (string.IsNullOrWhiteSpace(itemName))
            {
                itemName = "model1";
            }
            IEnumerable<string> itemParts = Utilities.Naming.SplitName(itemName);

            // the name of the class
            replacementsDictionary.Add("$className$", $"{Utilities.Naming.ToPascalCase(itemParts)}");

            // the name of the file - models actually match the class name instead of using the angular naming convention
            replacementsDictionary.Add("$fileName$", $"{Utilities.Naming.ToPascalCase(itemParts)}.ts");
            //replacementsDictionary.Add("$fileName$", $"{string.Join("-", itemParts)}.ts");

            // if we can find the Models directory in the web project, allow them to pick a view model to derive the angular model class
            //if (!ShowOptionsDialog(null, replacementsDictionary["$rootnamespace$"], replacementsDictionary["$solutiondirectory$"]))
            //    return;

            _createFiles = true;
        }

        private bool ShowOptionsDialog(object optionsDialog, string rootNamespace, string solutionDirectory)
        {
            try
            {
                if (!rootNamespace.Contains("ClientApp"))
                {
                    // they are creating this item outside the ClientApp, allow but don't offer any options
                    return true;
                }

                string projectRootPath = Path.Combine(solutionDirectory, rootNamespace.Substring(0, rootNamespace.IndexOf("ClientApp") - 1));
                string pathToViewModels = Path.Combine(projectRootPath, "Models");
                if (!Directory.Exists(pathToViewModels))
                {
                    // they are creating the model file in the ClientApp directory, but there is no corresponding Models directory for view models; allow but don't offer any options
                    return true;
                }

                // this is somewhat convoluted, but there should be a "startup.cs" file in the project root, so load that and manually pull the namespace to get the root namespace of the project
                FileInfo fileInfo = new FileInfo(Path.Combine(projectRootPath, "Startup.cs"));
                if (!fileInfo.Exists)
                {
                    // not enough information to offer the options
                    return true;
                }

                string baseNamespace = "";
                using (StreamReader streamReader = fileInfo.OpenText())
                {
                    while (!streamReader.EndOfStream && string.IsNullOrWhiteSpace(baseNamespace))
                    {
                        string line = streamReader.ReadLine();

                        if (line.StartsWith("namespace"))
                        {
                            // remove the leading "namespace "
                            line = line.Substring("namespace ".Length);

                            // if there are any spaces left, cut it at the first space
                            if (line.IndexOf(" ") > -1)
                                line = line.Substring(0, line.IndexOf(" "));

                            baseNamespace = line;
                        }
                    }

                    streamReader.Close();
                }

                if (string.IsNullOrWhiteSpace(baseNamespace))
                    return true;

                // we need to get the project's dll so we can load the assembly (the executing, caller, etc  give this extension's assembly)
                // from project root: bin\Debug\netcoreapp#.#
                // *might* be able to them load the *.deps.json file and look at the targets/.NETCoreApp,Version=#.#/{projectName}?/runtime or compile
                // or maybe just load the *.csproj file in the root and look for default namespace or assembly name (Project/PropertyGroup/AssemblyName - if it doesn't exist it is the name of the project file)

                // we want to find all classes within the view model directory


                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                assembly.GetTypes()
                    .Where(e => e.IsClass)
                    .Where(e => e.Namespace.StartsWith($"{baseNamespace}.Models"))
                    .ToList()
                    .ForEach(modelType =>
                    {
                        System.Diagnostics.Debugger.Log(1, "debug", $"{modelType.FullName}");
                    });
                string[] files = Directory.GetFiles(pathToViewModels, "*.cs");
                foreach (string fileName in files)
                {
                    // looks like we have to manually parse the file, unless we load the current assembly and look at the class (what happens if it hasn't been compiled?)

                }

            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }
    }
}
