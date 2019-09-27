using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sort
{
    class CountOfComparisons : Base
    {
        public override void Show(Pair[] workArray)
        {
            Console.Write("Count of comparisons\nKey \t Value\n");
            for (int i = 0; i < workArray.Length; i++)
            {
                Console.Write("{0} \t {1}\n", workArray[i].Key, workArray[i].Value);
            }
            Console.WriteLine();
        }
        //Knut - tom 3, page 78(or 88), algorithm C
        public override void Sort(Pair[] workArray)
        {
            int[] count = new int[workArray.Length];
            for (int i = workArray.Length - 1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (workArray[i].Key < workArray[j].Key)
                    {
                        count[j]++;
                    }
                    else
                    {
                        count[i]++;
                    }
                }
            }
            ReplacePosition(count, workArray);
        }

        private void ReplacePosition(int[] count, Pair[] workArray)
        {
            Pair[] tempArr = new Pair[workArray.Length];
            for (int i = 0; i < count.Length; i++)
            {
                tempArr[count[i]] = new Pair(workArray[i].Key, workArray[i].Value);
            }
            for(int i = 0; i < tempArr.Length; i++)
            {
                workArray[i].Key = tempArr[i].Key;
                workArray[i].Value = tempArr[i].Value;            
            }
        }
    }
}
