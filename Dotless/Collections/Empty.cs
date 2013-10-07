using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotless
{
    public static class Empty
    {

        public static bool Is<T>(IEnumerable<T> c)
        {
            return Null.Is(c) || Null.Is(c.FirstOrDefault());
        }

    }
}
