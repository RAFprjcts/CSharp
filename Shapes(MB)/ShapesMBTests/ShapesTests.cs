using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreasShapes;

namespace ShapesMBTests
{
    [TestClass]
    public class ShapesTests
    {
        #region Circle
        [TestMethod]
        public void CircleTest()
        {
            Circle c1 = new Circle(2);
            double expected = 12.57;
            double result = c1.Square();
            Assert.AreEqual(expected, result, 0.01);
        }
        #endregion

        #region Triangles
        [TestMethod]
        public void TriangleEquilateralTest() //равносторонний
        {
            Triangle tr = new Triangle(2, 2, 2);
            double sq = tr.Square();
            bool right = tr.isRightTriangle();
            Assert.AreEqual(false, right);
            Assert.AreEqual(1.732051, sq, 0.01);
        }

        [TestMethod]
        public void TriangleIsoscelesTest() //Равнобедренный не прямоугольный
        {
            Triangle tr = new Triangle(4, 4, 7);
            double sq = tr.Square();
            bool right = tr.isRightTriangle();
            Assert.AreEqual(false, right);
            Assert.AreEqual(6.777721, sq, 0.01);
        }

        [TestMethod]
        public void TriangleScaleneTest() //раЗносторонний - прямоугольный
        {
            Triangle tr = new Triangle(6, 8, 10);
            double sq = tr.Square();
            bool right = tr.isRightTriangle();
            Assert.AreEqual(true, right);
            Assert.AreEqual(24, sq, 0.01);
        }
        #endregion

        #region Rectangle
        [TestMethod]
        public void RectangleTest()
        {
            Rectangle rect = new Rectangle(10, 20);
            double exp = 200;
            Assert.AreEqual(exp, rect.Square(), 0.01);
        }
        #endregion

        #region Shape
        [TestMethod]        
        public void ShapeTest()//rectangle
        {
            int[] values = { 2, 3 };
            Shape sh = new Shape(values);
            double exp = 6;
            Assert.AreEqual(exp, sh.Square(), 0.01);
        }
        [TestMethod]
        public void ShapeTest2()//triangle
        {
            int[] values = { 4, 4, 7};
            Shape sh = new Shape(values);
            double exp = 6.777721;
            Assert.AreEqual(exp, sh.Square(), 0.01);
        }
        [TestMethod]
        public void ShapeTest3()//circle
        {
            int[] values = { 2 };
            Shape sh = new Shape(values);
            double expected = 12.57;
            double result = sh.Square();
            Assert.AreEqual(expected, result, 0.01);
        }
        #endregion
    }
}
