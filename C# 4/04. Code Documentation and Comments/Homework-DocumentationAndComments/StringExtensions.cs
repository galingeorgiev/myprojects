namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Contains extension methods of string.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Create hash function of string.
        /// </summary>
        /// <param name="input">String for which is looking hash function.</param>
        /// <returns>Hash code of input string.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes.
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data .
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Check if answer is positive or doesn't.
        /// </summary>
        /// <param name="input">Check if string is positive(e.g. true, ok, "1", yes).</param>
        /// <returns>True if input string is positive word and False in other cases.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Convert string to short data type.
        /// </summary>
        /// <param name="input">String that will be converted to short.</param>
        /// <returns>Number as short data type.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Convert string to integer data type.
        /// </summary>
        /// <param name="input">String that will be converted to integer.</param>
        /// <returns>Number as integer data type.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Convert string to long data type.
        /// </summary>
        /// <param name="input">String that will be converted to long.</param>
        /// <returns>Number as long data type.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Convert string to DateTime type.
        /// </summary>
        /// <param name="input">String that will be converted to DateTime.</param>
        /// <returns>New DateTime.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Make first letter of string in upper case.
        /// </summary>
        /// <param name="input">String that will be changed first letter.</param>
        /// <returns>New string with upper case first letter.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Find string between two other strings.
        /// </summary>
        /// <param name="input">String where be searched.</param>
        /// <param name="startString">Substring from where start searching.</param>
        /// <param name="endString">Substring where stop searching.</param>
        /// <param name="startFrom">Optional: from where to start searching. Default is zero.</param>
        /// <returns>New string located between startString and endString.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            // If startFrom is difrent from zero we get new substring.
            input = input.Substring(startFrom);

            // Reset startFrom value to zero.
            startFrom = 0;

            // Check if startString and endString is contains in input string.
            // If one of them does not contains return empty string.
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            // Find start position of new substring.
            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            // Find end position of new substring.
            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Convert string from cyrillic to latin.
        /// </summary>
        /// <param name="input">String that will be converted.</param>
        /// <returns>New string with latin letters.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
            {
                "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
            };
            var latinRepresentationsOfBulgarianLetters = new[]
            {
                "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
            };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Convert string from latin to cyrillic.
        /// </summary>
        /// <param name="input">String that will be converted.</param>
        /// <returns>New string with cyrillic letters.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
            };

            var bulgarianRepresentationOfLatinKeyboard = new[]
            {
                "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                "в", "ь", "ъ", "з"
            };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Remove invalid characters from string and make it valid.
        /// </summary>
        /// <param name="input">String that will be validated.</param>
        /// <returns>New string with valid characters only.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Validated file name.
        /// </summary>
        /// <param name="input">String that will be validated.</param>
        /// <returns>New string in valid for file name format.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Find first characters of string.
        /// </summary>
        /// <param name="input">String where will be searched.</param>
        /// <param name="charsCount">Number of chars from zero which we want to get.</param>
        /// <returns>Substring from zero to charsCount.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Find file extension from file name.
        /// </summary>
        /// <param name="fileName">File name is string.</param>
        /// <returns>File extension as string.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Find content type from file extension.
        /// </summary>
        /// <param name="fileExtension">File extension as string(e.g. jpg, doc).</param>
        /// <returns>File content(e.g. image/jpeg, application/msword).</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
            {
                { "jpg", "image/jpeg" },
                { "jpeg", "image/jpeg" },
                { "png", "image/x-png" },
                {
                        "docx",
                        "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                },
                { "doc", "application/msword" },
                { "pdf", "application/pdf" },
                { "txt", "text/plain" },
                { "rtf", "application/rtf" }
            };

            // If file extension is contain in dictionary as key will return its value.
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            // If file extension is not contained in dictionary will return this result.
            return "application/octet-stream";
        }

        /// <summary>
        /// Make deep copy of string and convert it to byte array.
        /// </summary>
        /// <param name="input">String that will be converted to bytes array.</param>
        /// <returns>New bytes array with content bytes of input string.</returns>
        /// <see cref="System.Buffer.BlockCopy()"/>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}