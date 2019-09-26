using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sort
{
    class Bubble : Base
    {
        public override void Show(Pair[] workArray)
        {            
            Console.Write("Bubble sort\nKey \t Value\n");
            for (int i = 0; i < workArray.Length; i++)
            {
                Console.Write("{0} \t {1}\n", workArray[i].Key, workArray[i].Value);
            }
            Console.WriteLine();
        }
        public override void Sort(Pair[] workArray)
        {
            int tempBound = workArray.Length - 1;
            int BOUND = tempBound;

            Pair temp = new Pair();

            while (tempBound != 0)
            {
                BOUND = tempBound;
                tempBound = 0;
                for (int j = 0; j < BOUND; j++)
                {
                    if (workArray[j].Key > workArray[j + 1].Key)
                    {
                        Swap(workArray, j, j + 1);
                        tempBound = j;
                    }
                }
            }            
        }
    }
}
