using System.Collections.Generic;

namespace NUnitTestLogin
{
    public class BrowserTypes
    {
        public static IEnumerable<string> BrowserToRunWith()
        {
            string[] browsers = { "chrome", "firefox" };
            foreach (string b in browsers)
            {
                yield return b;
            }
        }
    }
}
