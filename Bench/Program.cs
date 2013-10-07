using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dotless;

namespace Bench
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var li = Enumerable.Range(0, 100);
            var x = (new ListLess<int>(li));

            2.Times(i => Console.WriteLine(i));
            Console.ReadKey();

        }
    }
}
