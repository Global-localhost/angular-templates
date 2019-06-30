using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Wizards.Utilities
{
    internal class File
    {
        /// <summary>
        /// Gets the list of file names of api services.
        /// </summary>
        /// <param name="replacementsDictionary"></param>
        /// <returns></returns>
        public static ICollection<string> GetApiServiceFileNames(Dictionary<string, string> replacementsDictionary)
        {
            ICollection<string> fileNames = new List<string>();

            if (Directory.Exists(Path.ApiServicesPath(replacementsDictionary)))
            {
                string[] files = Directory.GetFiles(Path.ApiServicesPath(replacementsDictionary), "*-api.service.ts");
                foreach (string fileName in files)
                {
                    FileInfo file = new FileInfo(fileName);
                    fileNames.Add(Naming.ToPascalCase(Naming.SplitName(file.Name.Remove(file.Name.IndexOf("-api.service.ts")))));
                }
            }

            return fileNames;
        }

        /// <summary>
        /// Gets the list of file names of dialog components.
        /// </summary>
        /// <param name="replacementsDictionary"></param>
        /// <returns></returns>
        public static ICollection<string> GetDialogFileNames(Dictionary<string, string> replacementsDictionary)
        {
            ICollection<string> fileNames = new List<string>();

            if (Directory.Exists(Path.DialogsPath(replacementsDictionary)))
            {
                // dialogs are components and will be in their own directories, so need to iterate each directory to find the ts file
                string[] directories = Directory.GetDirectories(Path.DialogsPath(replacementsDictionary), "*-dialog", SearchOption.TopDirectoryOnly);
                foreach (string directory in directories)
                {
                    string[] files = Directory.GetFiles(directory, "*-dialog.component.ts");
                    foreach (string fileName in files)
                    {
                        FileInfo file = new FileInfo(fileName);
                        fileNames.Add(Naming.ToPascalCase(Naming.SplitName(file.Name.Remove(file.Name.IndexOf("-dialog.component.ts")))));
                    }
                }
            }

            return fileNames;
        }

        /// <summary>
        /// Gets the list of file names of model classes.
        /// </summary>
        /// <param name="replacementsDictionary"></param>
        /// <returns></returns>
        public static ICollection<string> GetModelFileNames(Dictionary<string, string> replacementsDictionary)
        {
            ICollection<string> fileNames = new List<string>();

            if (Directory.Exists(Path.ModelsPath(replacementsDictionary)))
            {
                string[] files = Directory.GetFiles(Path.ModelsPath(replacementsDictionary), "*.ts");
                foreach (string fileName in files)
                {
                    FileInfo file = new FileInfo(fileName);
                    fileNames.Add(Naming.ToPascalCase(Naming.SplitName(file.Name.Remove(file.Name.IndexOf(".ts")))));
                }
            }

            return fileNames;
        }

        /// <summary>
        /// Gets the list of file names of service classes.
        /// </summary>
        /// <param name="replacementsDictionary"></param>
        /// <returns></returns>
        public static ICollection<string> GetServiceFileNames(Dictionary<string, string> replacementsDictionary)
        {
            ICollection<string> fileNames = new List<string>();

            if (Directory.Exists(Path.ServicesPath(replacementsDictionary)))
            {
                string[] files = Directory.GetFiles(Path.ServicesPath(replacementsDictionary), "*.service.ts");
                foreach (string fileName in files)
                {
                    // in case api services are in the same directory as the 'normal' services check and ignore api service files
                    if (fileName.EndsWith("-api.service.ts", StringComparison.InvariantCultureIgnoreCase))
                        continue;

                    FileInfo file = new FileInfo(fileName);
                    fileNames.Add(Naming.ToPascalCase(Naming.SplitName(file.Name.Remove(file.Name.IndexOf(".service.ts")))));
                }
            }

            return fileNames;
        }
    }
}
