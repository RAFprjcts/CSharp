using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sort
{
    class StraightInsertionSort:Base
    {
        public override void Show(Pair[] workArray)
        {
            Console.Write("Straight Insertion Sort\nKey \t Value\n");
            for (int i = 0; i < workArray.Length; i++)
            {
                Console.Write("{0} \t {1}\n", workArray[i].Key, workArray[i].Value);
            }
            Console.WriteLine();
        }
        //Knut, Tom 3, Page 83, Algorithm S.
        //O(N^2 / 4)
        public override void Sort(Pair[] workArray)
        {
            Pair temp = new Pair();
            for(int j = 1; j < workArray.Length; j++)
            {
                int i = j - 1;
                temp.Key = workArray[j].Key;
                temp.Value = workArray[j].Value;

                while (i >= 0 && temp.Key < workArray[i].Key)
                {
                    workArray[i + 1].Key = workArray[i].Key;
                    workArray[i + 1].Value = workArray[i].Value;
                    i = i - 1;
                }
                workArray[i + 1].Key = temp.Key;
                workArray[i + 1].Value = temp.Value;
            }            
        }
    }
}
