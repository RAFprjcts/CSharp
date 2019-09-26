using Sorts.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    class Program
    {
        public static void Sorting(Base _base)
        {
            Console.Write("Input N: ");
            int N = int.Parse(Console.ReadLine());

            Random rand = new Random();
            Pair[] warr = new Pair[N];

            for (int i = 0; i < N; i++)
            {
                //Int32.Parse(Console.ReadLine())
                warr[i] = new Pair(rand.Next(0, 100), ((char)(rand.Next(1040, 1104))).ToString());
            }
            _base.Show(warr);
            _base.Sort(warr);
            _base.Show(warr);
        }
            
        static void Main(string[] args)
        {
           // Sorting(new Bubble());
            Sorting(new Cocktail());
        }
    }
}
