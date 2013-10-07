using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotless
{

    public delegate TResult F<TResult>();

    public delegate TResult F<T, TResult>(T a);

    public delegate TResult F<T1, T2, TResult>(T1 a1, T2 a2);

    public delegate TResult F<T1, T2, T3, TResult>(T1 a1, T2 a2, T3 a3);

    public delegate TResult F<T1, T2, T3, T4, TResult>(T1 a1, T2 a2, T3 a3, T4 a4);
    
    public delegate TResult F<T1, T2, T3, T4, T5, TResult>(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5);

    public delegate TResult F<T1, T2, T3, T4, T5, T6, TResult>(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6);

    public delegate TResult F<T1, T2, T3, T4, T5, T6, T7, TResult>(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7);

    public delegate TResult F<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8);

    public delegate TResult F<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9);

    public delegate TResult F<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10);

    public static class Functional {
        
        public static T Head<T>(this IEnumerable<T> c)
        {
            return c.Get(o => o.FirstOrDefault());
        }

        public static IEnumerable<T> Tail<T>(this IEnumerable<T> c)
        {
            return c.Get(o => o.Skip(1));
        }
    
    }
}                                    
