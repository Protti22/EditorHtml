using System;
using System.Text.RegularExpressions;

namespace EditorHtml
{
    public static class Viewer
    {
        public static void Show(string text)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO VISUALIZAÇÃO");
            Console.WriteLine("-----------------");
            Replace(text);
            Console.ReadKey();
            Menu.Show();
        }

        public static void Replace(string text)
        {

            var strong = new Regex(@"<strong>(.*?)<\/strong>", RegexOptions.IgnoreCase);


            var matches = strong.Matches(text);

            int lastIndex = 0;

            foreach (Match match in matches)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(text.Substring(lastIndex, match.Index - lastIndex));

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(match.Groups[1].Value);

                lastIndex = match.Index + match.Length;
            }


            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(text.Substring(lastIndex));
        }
    }
}
