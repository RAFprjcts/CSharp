using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            rStack rs = new rStack();
            Console.WriteLine("Count before push: {0}", rs.Count);
            rs.Push(1);
            rs.Push(2);
            Console.WriteLine("Count after push: {0}", rs.Count);

            Console.WriteLine("Peek: {0}", rs.Peek());

            int i = (int)rs.Pop();
            Console.WriteLine("Pop element: {0}", i);
            Console.WriteLine("Count after Pop: {0}", rs.Count);
            rs.Contains(null);
             
        }
    }
}
