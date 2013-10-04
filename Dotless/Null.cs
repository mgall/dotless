using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotless
{
    public static class Null
    {

        public static readonly object[] Params = new object[] { };

        public static bool Is(object o) 
        {
            return (o == null);
        }

        public static bool NotIs(object o)
        {
            return (o != null);
        }

        public static bool AnyOf(params object[] os)
        {
            foreach (var o in os)
                if (o == null) return true;

            return false;
        }

        public static bool AnyOf<T>(IEnumerable<T> os)
        {
            foreach (var o in os)
                if (o == null) return true;

            return false;
        }

        public static bool AllOf(params object[] os)
        {
            foreach (var o in os)
                if (o == null) return false;

            return true;
        }

        public static bool AllOf<T>(IEnumerable<T> os)
        {
            foreach (var o in os)
                if (o == null) return false;

            return true;
        }
    }
}
