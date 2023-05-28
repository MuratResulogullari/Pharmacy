using System.Globalization;
using System.Text.RegularExpressions;

namespace Pharmacy.DataAccess.Concrete.Utilities
{
    public static class CaseMap
    {
        public static string ConvertSnakeCaseToPascalCase(string snakeCase)
        {
            TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;
            string[] words = snakeCase.Split('_');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = textInfo.ToTitleCase(words[i]);
            }
            return string.Join("", words);
        }
        public static string ConvertPascalCaseToSnakeCase(string pascalCase)
        {
            string snakeCase = Regex.Replace(pascalCase, "(?<!^)([A-Z])", "_$1").ToLower();
            snakeCase = snakeCase.Replace("ı", "i");
            return snakeCase;
        }
    }
}