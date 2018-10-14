using System;
using System.Linq;

namespace StringConcatenation
{
    /// <summary>
    /// Contains method Concatenation which connects the two string that contain only characters of
    /// the Latin alphabet, excluding repeating characters
    /// </summary>
    public class StringConcatenation
    {
        /// <summary>
        /// Concatenation of the two string
        /// </summary>
        /// <param name="first_string">First string</param>
        /// <param name="second_string">Second string</param>
        /// <returns>Concatenation of the two string</returns>
        /// <exception cref="ArgumentException">
        /// Raises if string contains not characters of the Latin alphabet
        /// </exception>
        public static string Concatenation(string first_string, string second_string)
        {
            if (first_string == null | second_string == null)
            {
                throw new ArgumentNullException("Invalid, String is null");
            }
            else if (ChechedString(first_string, second_string))
            {
                string result_string = first_string;
                var temp = second_string.ToArray().Where(value => !first_string.Contains(value)).Select(value => value);

                foreach (var i in temp)
                {
                    result_string += i;
                }
                   
                return result_string;
            }
            else
            {
                throw new ArgumentException("String not only letter");
            }
        }

        /// <summary>
        /// Check valid string`s
        /// </summary>
        /// <param name="first_string">First string</param>
        /// <param name="second_string">Second string</param>
        /// <returns>True, if check string contains only letter, else False</returns>
        private static bool ChechedString(string first_string, string second_string)
        {
           return first_string.All(c => char.IsLetter(c)) & second_string.All(c => char.IsLetter(c));
        }
    }
}
