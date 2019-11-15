using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smaug.Extensions
{
    public static class Extensions
    {
        public static void Print<T>(this LinkedList<T> queue)
        {
            foreach (var item in queue)
            {
                Console.Write("{0} --> ", item);
            }
        }
    }
}
