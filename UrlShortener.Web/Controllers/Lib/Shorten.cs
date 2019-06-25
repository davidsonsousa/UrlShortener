using System;

namespace UrlShortener.Web.Controllers.Lib
{
    public static class Shorten
    {
        public static string GenerateCode(int max)
        {
            const string validChars = "-0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            char[] genChars = new char[max];
            var random = new Random();

            for (int i = 0; i < genChars.Length; i++)
            {
                genChars[i] = validChars[random.Next(validChars.Length)];
            }

            /** Discarded options **/

            // Looping through the characters from ASCII table would cause problems
            // There are special characters between numbers and letters -> http://www.asciitable.com

            // Increment the code by each generation would make 2 trips to DB per generation
            // 1. Check last generated code on the DB (example: AAAAAA)
            // 2. Generates next one (AAAAAB) and save in the DB
            // Precise, but would cause some concurrency issues

            // Generate a Guid and transform it into string would have a lot of characters

            return new string(genChars);
        }
    }
}
