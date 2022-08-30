using System;
using System.Linq;

namespace Monday.Client.Extensions
{
    internal static class StringExtensions
    {
        internal static string FirstCharacterToUpper(this string value)
        {
            if(String.IsNullOrWhiteSpace(value))
                return String.Empty;

            return $"{Char.ToUpper(value.Trim().First())}{value.Trim().Substring(1)}";
        }
    }
}