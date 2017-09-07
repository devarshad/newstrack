using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.Core
{
    public static class StringExtension
    {
        public static bool Validate(this string str)
        {
            if (String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str))
            {
                str = String.Empty;
                return false;
            }
            else
            {
                str = str.Trim();
                return true;
            }
        }
    }
}
