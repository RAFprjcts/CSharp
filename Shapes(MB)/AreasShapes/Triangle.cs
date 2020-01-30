using System;

namespace AreasShapes
{
    public class Triangle : Shape
    {
        public Triangle(int a, int b, int c) : base(a, b, c) { }
        public override double Square()
        {
            if ( sides[0] + sides[1] > sides[2] &&
                 sides[0] + sides[2] > sides[1] &&
                 sides[1] + sides[2] > sides[0])//треугольник существует
            {
                double prmtr = (sides[0] + sides[1] + sides[2]) / 2.0;

                return Math.Sqrt(prmtr *
                                (prmtr - sides[0]) *
                                (prmtr - sides[1]) *
                                (prmtr - sides[2]));// формула Герона, для нахождения площади трегульника
            }
            throw new ArgumentException("Треугольник не существует.");
        }

        public bool isRightTriangle()
        {
            /*Теорема Пифагора(ТП), c^2 = b^2 + a^2. 
            
            Есть три идеи поиска наидлиннейшей стороны:

            1. Сравнить все значения друг с другом.
             if(sides[1] > sides[2] && sides[1] > sides[3])
                ТП
             if(sides[2]>sides[1] && sides[2]>sides[3])
                ТП
             if(sides[3]>sides[1] && sides[3]>sides[2])
                ТП

            2. Реализовать проход по массиву и записать ИНДЕКС максимального значения во временную переменную. Но придется покрывать условиями, 
            If(index == 1)
                sides[1] ^ 2 = sides[0] ^ 2 + sides[2] ^ 2
            else If(index == 2)
                sides[2] ^ 2 = sides[1] ^ 2 + sides[3] ^ 2
            else If(index == 3)
                sides[3] ^ 2 = sides[1] ^ 2 + sides[2] ^ 2
            от первого не сильно отличается, но второе почище.

            3. Отсортировать наши значения по убыванию, и тогда мы точно будем знать, первое значение гипотенуза, а два остальных катеты.
            */
            int[] resultSort = Sort(sides);
            return resultSort[0] * resultSort[0] == 
                   resultSort[1] * resultSort[1] + 
                   resultSort[2] * resultSort[2] ? true : false;//ну может это тоже не идеальное решение, но оно хотя бы занимает меньше места
        }
        //не стал выносить сортировку в отдельный класс.
        private int[] Sort(int[] workArray)
        {
            int[] temparray = new int[3];
            workArray.CopyTo(temparray, 0);//копирую массив только потому что не стоит изменять рабочий массив, так как он может пригодится в том виде, в каком его задали
            int t = 2;
            int BOUND = t;

            while (t != 0)
            {
                BOUND = t;
                t = 0;
                for (int j = 0; j < BOUND; j++)
                {
                    if (temparray[j] < temparray[j + 1])
                    {
                        int temp = temparray[j + 1];
                        temparray[j + 1] = temparray[j];
                        temparray[j] = temp;
                        t = j;
                    }
                }
            }
            return temparray;
        }
    }
}
