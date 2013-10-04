using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotless
{
    public static class Safe
    {
        public static T Get<T>(this T t, T defValue = null)  where T: class
        {
            return (t == null) ? defValue : t;
        }

        public static R Get<T, R>(this T t, F<T, R> fetch, R defValue = default(R)) where T : class
        {
            return (t != null && fetch != null) ? fetch(t) : defValue;
        }

        public static R Get<T, R>(this T t, F<T, R> fetchRes, F<R> fetchDefault) where T : class
        {
            return (t != null && fetchRes != null) ? fetchRes(t) :
                   (fetchDefault != null) ? fetchDefault() :
                   default(R);
        }

        public static void Do<T>(this T t, Action<T> straight, Action alternative = null) where T : class
        { 
            if (t != null && straight != null) straight(t);
            else if (alternative!=null) alternative();
        }

    }
}
