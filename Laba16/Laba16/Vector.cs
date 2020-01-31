using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba16
{
    [Serializable]
    public class Vector
    {
        public double coordinateX { get; set; }
        public double coordinateY { get; set; }

        public Vector()
        {
            coordinateX = 0;
            coordinateY = 0;
        }

        public Vector(double sourceOfX, double sourceOfY)
        {
            coordinateX = sourceOfX;
            coordinateY = sourceOfY;           
        }

        public static Vector operator +(Vector Object1, Vector Object2)
        {
            Vector ResultSolution = new Vector();
            ResultSolution.coordinateX = Object1.coordinateX + Object2.coordinateX;
            ResultSolution.coordinateY = Object1.coordinateY + Object2.coordinateY;            
            return ResultSolution;
        }
        public static Vector operator *(double lambda, Vector Object1)
        {
            Vector ResultSolution = new Vector();
            ResultSolution.coordinateX = lambda * Object1.coordinateX;
            ResultSolution.coordinateY = lambda * Object1.coordinateY;
            return ResultSolution;
        }
    }
}

