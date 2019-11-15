using System;
using System.Collections.Generic;

namespace Smaug.Extensions
{
    public static class Extensions
    {
        public static void Print<T>(this LinkedList<T> link)
        {
            foreach (var item in link)
            {
                if(item.Equals(link.Last.Value))
                    Console.Write("{0}", item);
                else Console.Write("{0} --> ", item);
            }
        }
    }
}
