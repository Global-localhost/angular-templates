using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Wizards.Utilities
{
    internal class Path
    {
        /// <summary>
        /// Calculates the directory path of api service files.
        /// </summary>
        /// <param name="replacementsDictionary"></param>
        /// <returns></returns>
        public static string ApiServicesPath(Dictionary<string, string> replacementsDictionary)
        {
            return System.IO.Path.Combine(AppRootPath(replacementsDictionary), "services");
        }

        /// <summary>
        /// Returns the path to the angular app root, typically in 'src\app'.
        /// </summary>
        /// <param name="replacementsDictionary"></param>
        /// <returns></returns>
        public static string AppRootPath(Dictionary<string, string> replacementsDictionary)
        {
            if (IsInClientApp(replacementsDictionary))
                return System.IO.Path.Combine(replacementsDictionary["$solutiondirectory$"], replacementsDictionary["$rootnamespace$"].Substring(0, replacementsDictionary["$rootnamespace$"].IndexOf("ClientApp") - 1), "ClientApp", "src", "app");
            else // put in the project root
                return System.IO.Path.Combine(replacementsDictionary["$solutiondirectory$"], replacementsDictionary["$rootnamespace$"].Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).First(), "src", "app");
        }

        /// <summary>
        /// Calculates the directory path of dialog files.
        /// </summary>
        /// <param name="replacementsDictionary"></param>
        /// <returns></returns>
        public static string DialogsPath(Dictionary<string, string> replacementsDictionary)
        {
            return System.IO.Path.Combine(AppRootPath(replacementsDictionary), "dialogs");
        }

        /// <summary>
        /// Gets the path used to import a class from a file. This is the file's path starting at the "src" directory, typically below the "ClientApp" directory or the project root.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ImportPath(string filePath)
        {
            string searchString = @"src\app\";
            int idx = filePath.IndexOf(searchString);

            if (idx == -1)
                return "";

            string partial = filePath.Substring(idx);

            // we need to exclude the ".ts"
            if (partial.EndsWith(".ts"))
                partial = partial.Substring(0, partial.Length - 3);
            return partial.Replace(@"\", "/");
        }

        /// <summary>
        /// Determines if the selected location is in (under) the "src/app" directory for Angular.
        /// </summary>
        /// <param name="replacementsDictionary"></param>
        /// <returns></returns>
        public static bool IsInAngularApp(Dictionary<string, string> replacementsDictionary)
        {
            return replacementsDictionary["$rootnamespace$"].Contains(".src.app");
        }

        /// <summary>
        /// Determines if the selected location is in (under) the "ClientApp" directory.
        /// </summary>
        /// <param name="replacementsDictionary"></param>
        /// <returns></returns>
        public static bool IsInClientApp(Dictionary<string, string> replacementsDictionary)
        {
            return replacementsDictionary["$rootnamespace$"].Contains("ClientApp");
        }

        /// <summary>
        /// Calculates the directory path of model files.
        /// </summary>
        /// <param name="replacementsDictionary"></param>
        /// <returns></returns>
        public static string ModelsPath(Dictionary<string, string> replacementsDictionary)
        {
            return System.IO.Path.Combine(AppRootPath(replacementsDictionary), "models");
        }

        /// <summary>
        /// Calculates the directory path of service files.
        /// </summary>
        /// <param name="replacementsDictionary"></param>
        /// <returns></returns>
        public static string ServicesPath(Dictionary<string, string> replacementsDictionary)
        {
            return System.IO.Path.Combine(AppRootPath(replacementsDictionary), "services");
        }
    }
}
