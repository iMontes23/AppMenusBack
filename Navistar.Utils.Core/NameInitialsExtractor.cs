using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Navistar.Utils.Core
{
    public class NameInitialsExtractor
    {

        public static string GetInitials(string name)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(name))
                {
                    return Constants.DOUBLE_X;
                }

                name = name
                    .Replace("(", Constants.EMPTY_STRING)
                    .Replace(")", Constants.EMPTY_STRING)
                    .Replace("[", Constants.EMPTY_STRING)
                    .Replace("]", Constants.EMPTY_STRING);

                string[] connectors = {
                    "de", "a", "para", "la", "el", "los", "las", "en",
                    "of", "a", "for", "the", "and", "in", "on"
                };

                string[] words = name.Trim().ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Filter out connector words
                words = words.Where(word => !connectors.Contains(word)).ToArray();

                if (words.Length == 0)
                {
                    return Constants.DOUBLE_X;
                }

                string result = words.Length > 1
                    ? words[0][0].ToString() + words[words.Length-1][0]
                    : words[0][0].ToString() + words[0][1];

                return result.ToUpper();
            }
            catch
            {
                return Constants.DOUBLE_X;
            }
        }

    }
}
