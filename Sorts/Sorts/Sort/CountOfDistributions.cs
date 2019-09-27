using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sort
{
    class CountOfDistributions:Base
    {
        public override void Show(Pair[] workArray)
        {
            Console.Write("Count of distributions\nKey \t Value\n");
            for (int i = 0; i < workArray.Length; i++)
            {
                Console.Write("{0} \t {1}\n", workArray[i].Key, workArray[i].Value);
            }
            Console.WriteLine();
        }

        //Knut, Tom 3, page 80, algorithm D
        public override void Sort(Pair[] workArray)
        {
            int MAX = 0, MIN = 0;//v, u

            MAX = workArray[0].Key;
            MIN = workArray[0].Key;
            for (int i = 1; i < workArray.Length; i++)
            {
                if (MAX < workArray[i].Key)
                    MAX = workArray[i].Key;
                if (MIN > workArray[i].Key)
                    MIN = workArray[i].Key;
            }

            int[] count = new int[MAX - MIN + 1];
            for(int j = 0; j < workArray.Length;  j++)
            {
                count[workArray[j].Key - MIN]++;                
            }
            for (int i = 1; i < count.Length; i++)
            {
                count[i] = count[i] + count[i - 1];
            }
            Pair[] s = new Pair[workArray.Length];
            for(int j = workArray.Length - 1; j >= 0; j--)
            {
                int i = --count[workArray[j].Key - MIN];
                s[i] = new Pair(workArray[j].Key, workArray[j].Value);            
            }
            for(int i = 0; i < s.Length; i++)
            {
                workArray[i].Key = s[i].Key;
                workArray[i].Value = s[i].Value;
            }
        }
    }
}