using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sort
{
    class Cocktail : Base
    {

        public override void Show(Pair[] workArray)
        {
            Console.Write("Cocktail sort\nKey \t Value\n");
            for (int i = 0; i < workArray.Length; i++)
            {
                Console.Write("{0} \t {1}\n", workArray[i].Key, workArray[i].Value);
            }
            Console.WriteLine();
        }
        public override void Sort(Pair[] workArray)
        {
            int j, k = workArray.Length - 1, l = 1, r = workArray.Length - 1;

            Pair temp = new Pair();
            do
            {
                for (j = l;  j <= r; j++)
                {
                    if (workArray[j - 1].Key > workArray[j].Key)
                    {
                        Swap(workArray, j - 1, j);
                        k = j;
                    }
                }
                r = k - 1;

                for (j = r; j >= l; j--)
                {
                    if (workArray[j - 1].Key > workArray[j].Key)
                    {
                        Swap(workArray, j - 1, j);
                        k = j;
                    }
                }
                l = k + 1;
            } while (l < r);
        }
    }
}
