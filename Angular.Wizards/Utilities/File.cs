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
        public static ICollection<ClassModel> GetApiServices(Dictionary<string, string> replacementsDictionary)
        {
            ICollection<ClassModel> classes = new List<ClassModel>();

            if (Directory.Exists(Path.ApiServicesPath(replacementsDictionary)))
            {
                string[] files = Directory.GetFiles(Path.ApiServicesPath(replacementsDictionary), "*.api-service.ts", SearchOption.AllDirectories);
                foreach (string fileName in files)
                {
                    FileInfo file = new FileInfo(fileName);
                    classes.Add(new ClassModel
                    {
                        FullFilePath = fileName,
                        ImportPath = Path.ImportPath(fileName),
                        Name = Naming.ToPascalCase(Naming.SplitName(file.Name.Remove(file.Name.IndexOf(".api-service.ts"))))
                    });
                }
            }

            return classes;
        }

        /// <summary>
        /// Gets the list of file names of dialog components.
        /// </summary>
        /// <param name="replacementsDictionary"></param>
        /// <returns></returns>
        public static ICollection<ClassModel> GetDialogs(Dictionary<string, string> replacementsDictionary)
        {
            ICollection<ClassModel> classes = new List<ClassModel>();

            if (Directory.Exists(Path.DialogsPath(replacementsDictionary)))
            {
                string[] files = Directory.GetFiles(Path.DialogsPath(replacementsDictionary), "*.dialog-component.ts", SearchOption.AllDirectories);
                foreach (string fileName in files)
                {
                    FileInfo file = new FileInfo(fileName);
                    classes.Add(new ClassModel
                    {
                        FullFilePath = fileName,
                        ImportPath = Path.ImportPath(fileName),
                        Name = Naming.ToPascalCase(Naming.SplitName(file.Name.Remove(file.Name.IndexOf(".dialog-component.ts"))))
                    });
                }
            }

            return classes;
        }

        /// <summary>
        /// Gets the list of file names of model classes.
        /// </summary>
        /// <param name="replacementsDictionary"></param>
        /// <returns></returns>
        public static ICollection<ClassModel> GetModels(Dictionary<string, string> replacementsDictionary)
        {
            ICollection<ClassModel> classes = new List<ClassModel>();

            if (Directory.Exists(Path.ModelsPath(replacementsDictionary)))
            {
                string[] files = Directory.GetFiles(Path.ModelsPath(replacementsDictionary), "*.ts", SearchOption.AllDirectories);
                foreach (string fileName in files)
                {
                    FileInfo file = new FileInfo(fileName);
                    classes.Add(new ClassModel
                    {
                        FullFilePath = fileName,
                        ImportPath = Path.ImportPath(fileName),
                        Name = Naming.ToPascalCase(Naming.SplitName(file.Name.Remove(file.Name.IndexOf(".ts"))))
                    });
                }
            }

            return classes;
        }

        /// <summary>
        /// Gets the list of file names of service classes.
        /// </summary>
        /// <param name="replacementsDictionary"></param>
        /// <returns></returns>
        public static ICollection<ClassModel> GetServices(Dictionary<string, string> replacementsDictionary)
        {
            ICollection<ClassModel> classes = new List<ClassModel>();

            if (Directory.Exists(Path.ServicesPath(replacementsDictionary)))
            {
                string[] files = Directory.GetFiles(Path.ServicesPath(replacementsDictionary), "*.service.ts", SearchOption.AllDirectories);
                foreach (string fileName in files)
                {
                    // in case api services are in the same directory as the 'normal' services check and ignore api service files
                    //if (fileName.EndsWith(".api.service.ts", StringComparison.InvariantCultureIgnoreCase))
                    //    continue;

                    FileInfo file = new FileInfo(fileName);
                    classes.Add(new ClassModel
                    {
                        FullFilePath = fileName,
                        ImportPath = Path.ImportPath(fileName),
                        Name = Naming.ToPascalCase(Naming.SplitName(file.Name.Remove(file.Name.IndexOf(".service.ts"))))
                    });
                }
            }

            return classes;
        }
    }
}
