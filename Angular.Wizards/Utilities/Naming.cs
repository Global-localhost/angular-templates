using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Angular.Wizards.Utilities
{
    internal class Naming
    {
        /// <summary>
        /// The plural of the string. It is assumed string is some kind of noun.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Pluralize(string s)
        {
            if (s.EndsWith("y"))
                return $"{s.Substring(0, s.Length - 1)}ies";
            else if (s.EndsWith("s") || s.EndsWith("z"))
                return $"{s}es";
            else
                return $"{s}s";
        }

        /// <summary>
        /// Splits a name into its word parts based on space, dash, period or casing.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<string> SplitName(string name)
        {
            return Regex
                .Split(Regex.Replace(name, @"[^\w\-\.]", ""), @"((?:\.|-|[A-Z])+[^\.\-A-Z]*)")
                .Select(part => part.Trim('.', '-').ToLower())
                .Where(part => !string.IsNullOrEmpty(part));
        }

        /// <summary>
        /// Converts the collection of strings to a single, camel-case word.
        /// </summary>
        /// <param name="nameParts"></param>
        /// <returns></returns>
        public static string ToCamelCase(IEnumerable<string> nameParts)
        {
            string pascalCase = ToPascalCase(nameParts);
            return pascalCase.Substring(0, 1).ToLower() + pascalCase.Substring(1);
        }

        /// <summary>
        /// Converts the string to a camel-case word by first splitting the string and reforming its parts.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ToCamelCase(string name)
        {
            return ToCamelCase(SplitName(name));
        }

        /// <summary>
        /// Converts the collection of strings to a single, pascal-case word.
        /// </summary>
        /// <param name="nameParts"></param>
        /// <returns></returns>
        public static string ToPascalCase(IEnumerable<string> nameParts)
        {
            return string.Join("", nameParts.Select(part => part.Substring(0, 1).ToUpper() + part.Substring(1)));
        }

        /// <summary>
        /// Converts the string to a pascal-case word by first splitting the string and reforming its parts.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ToPascalCase(string name)
        {
            return ToPascalCase(SplitName(name));
        }

    }
}
