using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Blogger.Ui.Helpers
{
    public static class StripHtml
    {

        const string HTML_TAG_PATTERN = "<.*?>";
        public static string StripHTML(string inputString)
        {

            return Regex.Replace
              (inputString, HTML_TAG_PATTERN, string.Empty);
        }
    }
}
