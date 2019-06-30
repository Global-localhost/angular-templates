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
            return System.IO.Path.Combine(replacementsDictionary["$solutiondirectory$"], replacementsDictionary["$rootnamespace$"].Substring(0, replacementsDictionary["$rootnamespace$"].IndexOf("ClientApp") - 1), "ClientApp", "src", "app", "services");
        }

        /// <summary>
        /// Calculates the directory path of dialog files.
        /// </summary>
        /// <param name="replacementsDictionary"></param>
        /// <returns></returns>
        public static string DialogsPath(Dictionary<string, string> replacementsDictionary)
        {
            return System.IO.Path.Combine(replacementsDictionary["$solutiondirectory$"], replacementsDictionary["$rootnamespace$"].Substring(0, replacementsDictionary["$rootnamespace$"].IndexOf("ClientApp") - 1), "ClientApp", "src", "app", "dialogs");
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
            return System.IO.Path.Combine(replacementsDictionary["$solutiondirectory$"], replacementsDictionary["$rootnamespace$"].Substring(0, replacementsDictionary["$rootnamespace$"].IndexOf("ClientApp") - 1), "ClientApp", "src", "app", "models");
        }

        /// <summary>
        /// Calculates the directory path of service files.
        /// </summary>
        /// <param name="replacementsDictionary"></param>
        /// <returns></returns>
        public static string ServicesPath(Dictionary<string, string> replacementsDictionary)
        {
            return System.IO.Path.Combine(replacementsDictionary["$solutiondirectory$"], replacementsDictionary["$rootnamespace$"].Substring(0, replacementsDictionary["$rootnamespace$"].IndexOf("ClientApp") - 1), "ClientApp", "src", "app", "services");
        }
    }
}
