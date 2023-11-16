using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Helper
    {
        public String CombineUrl(params String[] parts)
        {
            StringBuilder sb = new();
            foreach (String part in parts)
            {
                String p = part;
                if (!p.StartsWith('/')) p = '/' + p;
                if (p.EndsWith("/")) p = p[..^1];
                sb.Append(p);
            }
            return sb.ToString();
        }

        public String Ellipsis(String input, int len)
        {
            // return "He...";
            // return (len == 5) ? "He..." : "Hel...";
            // return "Hel"[..(len-3)]+"...";
            return input[..(len - 3)] + "...";
        }
    }
}
