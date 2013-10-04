using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Dotless.Texting
{
    public class CaseFormatter: IFormatProvider, ICustomFormatter
    {
        public static CaseFormatter singleton = new CaseFormatter();

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider provider)
        {
            if (arg == null) return String.Empty;

            // Display information about method call. 
            string formatString = format ?? "<null>";
            var sarg = arg.ToString();

            var fcase = formatString[0];
            sarg = (fcase == 'L') ? sarg.ToLower() :
                   (fcase == 'U') ? sarg.ToUpper() :
                   (fcase == 'C') ? sarg.ToCapitalCase() :
                   (fcase == 'S') ? sarg.ToSentenceCase()
                   : sarg;
            

            //// Use default for all other formatting. 
            //if (arg is IFormattable)
            //    return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            //else
            //    return arg.ToString();
            return sarg;
        }
    }
}
