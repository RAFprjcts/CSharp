using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sort
{
    class Shell : Base
    {
        public override void Show(Pair[] workArray)
        {
            Console.Write("Shell Sort\nKey \t Value\n");
            for (int i = 0; i < workArray.Length; i++)
            {
                Console.Write("{0} \t {1}\n", workArray[i].Key, workArray[i].Value);
            }
            Console.WriteLine();
        }

        public override void Sort(Pair[] workArray)
        {
            Pair temp = new Pair();
            int h;//, ht =7;

            //проблема алгоритма в учебника Кнута том 3, в том, что нужно подбирать правильный шаг для сортировки массивов в соответствии с их размерностями..
            //for (int t = 3; t > 0; t--)//D1-   Выполнить шаг D2 при s = t, t - 1, ..., 1, после чего завершить работу алгоритма.
            //{
            //h = ht;// D2
            /*Установить h <- hs и выполнить шаги D3, ... D6 при h<j <= N. 
             (Для сортировки элементов, отстоящих друг от друга на h позиций, 
             воспользуемся простыми вставками и в результате получим Ki <= Ki + h при 1 <= i <= N - h.Шаги D3, ..., D6, 
             по существу, такие же, как соответственно S2, ..., S5 в алгоритме S.)*/

            //можнго заменить D1 и D2 на данный кусок кода. Если нам не известен шаг изначально.
            for (h = 1; (h * 2 + 1) < workArray.Length; h = h * 2 + 1) ;//ищем первый шаг
            for (; h > 0; h = (h - 1) / 2)
            {
                for (int j = h; j < workArray.Length; j++)
                {
                    int i = j - h; // D3 - Установить i <- j - h, K <- Kj, R <- Rj .
                    temp.Key = workArray[j].Key;
                    temp.Value = workArray[j].Value;

                    while (i >= 0 && temp.Key < workArray[i].Key)  // D4 - Если K >= Ki, то перейти к шагу D6.
                    {
                        workArray[i + h].Key = workArray[i].Key;// D5- Установить Ri+h <- Ri, затем i < i-h. Если i > 0, то возвратиться к шагу D4
                        workArray[i + h].Value = workArray[i].Value;
                        i = i - h;
                    }
                    workArray[i + h].Key = temp.Key; //Установить Ri+h <- R.
                    workArray[i + h].Value = temp.Value;
                }
                // ht = ht - 2;
            }//}
        }
    }
}