﻿using System;
using System.Linq;

namespace AreasShapes
{
    public class Shape
    {
        //изначально думал сделать класс Shape абстрактным, чтобы нельзя было создавать экземпляры данного типа, 
        //но в тз было доп условие: "Вычисление площади фигуры без знания типа фигуры". 
        //поэтому решил сделать класс не абстрактным, теперь, если не знаешь какая фигура, но есть стороны, то создаешь экземпляр класса Shape, и при вызове Square, 
        //функция определит тип фигуры и создат экзмепляр, после вычислит площадь, если это возможно.

        //Добавление классов расширяющих класс Shape, могут вызывать базовый конструктор Shape-а, и должны переопределять метод Square.
        

        protected int[] sides;//к примеру в будущем нужно будет расчитать площадь n-угольника. 
        //Тогда, чтобы не изменять входные параметры функции при появлении каждого n+1-угольников, можно использовать
        //массив. 
        //Есть и минус данного решения, т.к. в дочерних классах можно запутаться использую sides[0]-...-sides[n], где какая сторона не разберешь,
        //но за то не нужно будет в каждом класс n+1-угольника, объявлять n+1 сторону. Все-таки каждая фигура отдельная сущность и имеет свои правила поиска площади.
        public Shape(params int[] s)
        {
            if (isCorrectSidesLengths(s))
                sides = s;
            else
                throw new ArgumentException("Числовые характеристики фигур должны быть > 0.");
        }

        public virtual double Square()//этот метод будет вызываться только при создании экземпляра Shape s = new Shape({...}); s.square();
        {
            Shape sh;

            if (sides.Length == 1)
                sh = new Circle(sides[0]);
            else if (sides.Length == 2)
                sh = new Rectangle(sides[0], sides[1]);
            else if (sides.Length == 3)
                sh = new Triangle(sides[0], sides[1], sides[2]);
            else
            {
                throw new ApplicationException($"Для фигуры с {sides.Length} сторонами не определено правило поиска площади.");
            }
            return sh.Square();//здесь вызывается переопределенный методы, в зависимости от класса.
        }
        private bool isCorrectSidesLengths(int[] sd)
        {
            return !sd.Any(_ => _ <= 0);//true если хотя бы одна сторона <= 0. Унарным оператором инвертируем ответ.     
        }
    }
}