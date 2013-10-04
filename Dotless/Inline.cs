using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotless
{
    public static class Inline
    {

        public static void Times(this Int32 t, Action<Int32> action)
        {
            if (Null.Is(action)) return;

            for (int i = 0; i < t; i++) action(i);
        }

    }
}
