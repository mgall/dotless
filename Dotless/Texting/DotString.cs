using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Dotless.Texting
{
    public static class DotFormat
    {

        public static string ff(this string mask, params object[] args) {
            return string.Format(mask, args);
        }

        public static string fCase(this string mask, params object[] args)
        {
            return string.Format(CaseFormatter.singleton, mask, args);
        }

        public static string ToCapitalCase(this string value)
        {
            return Regex.Replace(value, @"\b[a-z]", m => m.Value.ToUpper());
        }

        public static string ToSentenceCase(this string value)
        {
            return Regex.Replace(value, @"([A-Z]{1,2}|[0-9]+)", " $1");
        }

        public static string ToDryCase(this string value)
        {
            return value.ToLower().Trim();
        }

    }
}
