using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.IO;

namespace Laba16
{
    public partial class Form1 : Form
    {
        public Form1()
        {                                    
            InitializeComponent();
            textBox1.KeyPress += Digite;
            textBox2.KeyPress += Digite;
            textBox3.KeyPress += Digite;
            textBox4.KeyPress += Digite;
            textBox5.KeyPress += Digite;
            textBox6.KeyPress += Digite;
            textBox6.KeyPress += Digite;
        }
        List<Ball> Balls = new List<Ball>();
        Random rand = new Random();
        Point MPosition = new Point();
        bool IsClicked = false;
        int MIndex = 0;
        Vector tmp1 = new Vector();
        Vector tmp2 = new Vector();
        string FileWriter = null;
        public StreamWriter LogWriter;//текстовый документ
        
        void Digite(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != '\b' && e.KeyChar != ',' && e.KeyChar != '-')
                e.Handled = true;
        }

        void WriteIntoLabel()
        {
            textBox1.Text = Convert.ToString(MIndex);
            textBox2.Text = Convert.ToString(Balls[MIndex].Weight);
            textBox3.Text = Convert.ToString(Balls[MIndex].Radius);
            textBox4.Text = Convert.ToString(Balls[MIndex].X);
            textBox5.Text = Convert.ToString(Balls[MIndex].Y);
            textBox6.Text = Convert.ToString(Balls[MIndex].VectorSpeed.coordinateX);
            textBox7.Text = Convert.ToString(Balls[MIndex].VectorSpeed.coordinateY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Balls.Count != 0)
            {
                timer1.Start();
                timer1.Interval = 5;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                button3.Enabled = true;
                button1.Enabled = false;
            }
            //что бы не выскакивало исключение на пустую строку
            if (textBox1.Text != "") MIndex = Convert.ToInt32(textBox1.Text);
            if (textBox2.Text != "") Balls[MIndex].Weight = Convert.ToDouble(textBox2.Text);
            if (textBox3.Text != "") Balls[MIndex].Radius = Convert.ToDouble(textBox3.Text);
            if (textBox4.Text != "") Balls[MIndex].X = Convert.ToDouble(textBox4.Text);
            if (textBox5.Text != "") Balls[MIndex].Y = Convert.ToDouble(textBox5.Text);
            if (textBox6.Text != "") Balls[MIndex].VectorSpeed.coordinateX = Convert.ToDouble(textBox6.Text);
            if (textBox7.Text != "") Balls[MIndex].VectorSpeed.coordinateY = Convert.ToDouble(textBox7.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();//во время движения шара редактировать запрещено, редактироват можно только во время Остановки
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            button1.Enabled = true;
            button3.Enabled = false;
        }

        /* Создание нового шарика */
        private void button4_Click(object sender, EventArgs e)
        {
           int value = rand.Next(30, 50);//масса и радиус
           Balls.Add(new Ball(rand.Next(30, 450), rand.Next(30, 450), value, value, new Vector(rand.Next(-4, 4), rand.Next(-4, 4)), Color.Black));            
           Invalidate();
        }      

        /* Отрисовка по новым координатам и свойствам (цвет скорость и т.д.)*/
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);           
            foreach (var item in Balls)
            {
                e.Graphics.FillEllipse(new SolidBrush(item.Color), (float)item.X, (float)item.Y, (float)item.Radius, (float)item.Radius);
            }            
            e.Graphics.DrawRectangle(new Pen(Color.Black, 5), new Rectangle(new Point(10, 30), new Size(500,500)));
        }

        /* Обработка столкновения шарика с шариком и со стенками, запись истории стлкновения шариков */
        private void timer1_Tick(object sender, EventArgs e)
        {
            WriteIntoLabel();
            foreach (var item in Balls)
            {
                if (item.X  > 470 || item.X < 10)
                    item.VectorSpeed.coordinateX = -item.VectorSpeed.coordinateX;
                if (item.Y  > 490 || item.Y < 30)
                    item.VectorSpeed.coordinateY = -item.VectorSpeed.coordinateY;
            }

            for (int i = 0; i < Balls.Count; i++) //Перебор всех шариков
            {
                for (int j = i; j < Balls.Count; j++) //Перебор всех шариков}
                {
                    int red = Balls[i].Color.R;
                    if(red > 0)
                        Balls[i].Color = Color.FromArgb(red - 1, 0, 0);
                    if ((Balls[i].X != Balls[j].X) && (Balls[i].Y != Balls[j].Y)) //Условия которое исключает проверку исходного шарика к самому себе                      
                    {
                        if ((Math.Pow((Balls[i].X - Balls[j].X), 2) + Math.Pow((Balls[i].Y - Balls[j].Y), 2)) <= Balls[i].Radius * Balls[j].Radius) //Условие столкновения шариков
                        {
                            FileWriter += "\r\n" + "Столкунлись шарики номер : " + Convert.ToString(i) + " ; " + Convert.ToString(j) + " . " + "\r\n" + "Координаты центра шарика № " + Convert.ToString(i) + " - " + "(" + Balls[i].X + ";" + Balls[i].Y + ")" + " . " + "\r\n" + "Координаты центра шарика № " + Convert.ToString(j) + " - " + "(" + Balls[j].X + ";" + Balls[j].Y + ")" + "\r\n";
                            FileWriter += "Скорость до : \r\n";
                            FileWriter += "Скорость шарика № " + Convert.ToString(i) + " - " + Math.Sqrt(Math.Pow(Balls[i].VectorSpeed.coordinateX, 2) + Math.Pow(Balls[i].VectorSpeed.coordinateY, 2)) + " . " + "\r\n";
                            FileWriter += "Скорость шарика № " + Convert.ToString(j) + " - " +  Math.Sqrt(Math.Pow(Balls[j].VectorSpeed.coordinateX, 2) + Math.Pow(Balls[j].VectorSpeed.coordinateY, 2)) + " . " + "\r\n";

                            tmp1 = ((Balls[i].Weight - Balls[j].Weight) / (Balls[i].Weight + Balls[j].Weight)) * Balls[i].VectorSpeed + ((2 * Balls[j].Weight) / (Balls[i].Weight + Balls[j].Weight)) * Balls[j].VectorSpeed;
                            tmp2 = ((Balls[j].Weight - Balls[i].Weight) / (Balls[i].Weight + Balls[j].Weight)) * Balls[j].VectorSpeed + ((2 * Balls[i].Weight) / (Balls[i].Weight + Balls[j].Weight)) * Balls[i].VectorSpeed;
                            Balls[j].Color = Balls[i].Color = Color.FromArgb(255, 0, 0);  
                            Balls[i].VectorSpeed = tmp1;
                            Balls[j].VectorSpeed = tmp2;
                            FileWriter += "Скорость после : \r\n";
                            FileWriter += "Скорость шарика № " + Convert.ToString(i) + " - " + Math.Sqrt(Math.Pow(Balls[i].VectorSpeed.coordinateX, 2) + Math.Pow(Balls[i].VectorSpeed.coordinateY, 2)) + " . " + "\r\n";
                            FileWriter += "Скорость шарика № " + Convert.ToString(j) + " - " + Math.Sqrt(Math.Pow(Balls[j].VectorSpeed.coordinateX, 2) + Math.Pow(Balls[j].VectorSpeed.coordinateY, 2)) + " . " + "\r\n";
                            FileWriter += "____________________________________________________________________________________________________";
                            LogWriter.Write(FileWriter);
                            tmp1 = new Vector();
                            tmp2 = new Vector();
                        }
                    }                    
                }
            }           

            foreach (var item in Balls)
            {
                item.X += item.VectorSpeed.coordinateX;
                item.Y += item.VectorSpeed.coordinateY;
            }
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MouseDown += Form1_MouseDown;
            LogWriter = new StreamWriter("LogFile1.txt");//Реализует TextWriter для записи символов в поток в определенной кодировке.
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            double Distance;
            int TIndex = 0;
            foreach (var item in Balls)
            {
                Distance = Math.Sqrt(Math.Pow((MPosition.X - item.X), 2) + Math.Pow((MPosition.Y - item.Y), 2));
                if (Distance <= item.Radius)
                {                  
                    MIndex = TIndex;
                    IsClicked = true;
                }
                TIndex++;
            }
            WriteIntoLabel();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            IsClicked = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            MPosition.X = e.X;
            MPosition.Y = e.Y;
            if (IsClicked)
            {
                Balls[MIndex].X = e.X;
                Balls[MIndex].Y = e.Y;
                Invalidate();
            }
        }        

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream A = new FileStream("Balls", FileMode.OpenOrCreate);//Предоставляет Stream для файла с поддержкой синхронных и асинхронных операций чтения и записи.
            BinaryFormatter B = new BinaryFormatter();//Сериализует и десериализует объект или весь граф связанных объектов в двоичном формате.
            B.Serialize(A, Balls);
            A.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream A = new FileStream("Balls", FileMode.OpenOrCreate);
            BinaryFormatter C = new BinaryFormatter();
            Balls = (List<Ball>)C.Deserialize(A);
            A.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            LogWriter.Close();
        }        
    }

    [Serializable]
    public class Ball
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }
        public double Weight { get; set; }
        public Color Color { get; set; }
        public Vector VectorSpeed { get; set; }      
        public Ball(double x, double y, int R, int W, Vector S, Color color)
        {
            X = x;
            Y = y;
            Radius = R;
            Weight = W;
            VectorSpeed = S;
            Color = color;
        }        
    }
}
