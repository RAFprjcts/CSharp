using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sort
{
    class Base
    {
        public virtual void Show(Pair[] workArray)
        {
            Console.Write("Key \t Value\n");
            for (int i = 0; i < workArray.Length; i++)
            {
                Console.Write("{0} \t {1}\n", workArray[i].Key, workArray[i].Value);
            }
            Console.WriteLine();
        }
        public virtual void Sort(Pair[] workArray) { }
        public static void Swap(Pair[] workArray, int i, int j) {

            Pair temp = new Pair();
            temp.Key = workArray[i].Key;
            workArray[i].Key = workArray[j].Key;
            workArray[j].Key = temp.Key;

            temp.Value = workArray[i].Value;
            workArray[i].Value = workArray[j].Value;
            workArray[j].Value = temp.Value;
        }
    }
}
