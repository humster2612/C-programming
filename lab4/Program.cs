using System;
using System.Collections.Generic;

namespace lab4
{
    class Shape
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public virtual void Draw()
        {
            Console.WriteLine($"Rysowanie shape ({X}, {Y}) o wysokości {Height} i szerokości {Width}");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Rectangle(0, 0, 5, 10));

            shapes.Add(new Triangle(0, 0, 5, 10));

            shapes.Add(new Circle(0, 5, 10));

            foreach (var shape in shapes)
            {
                shape.Draw();
                Console.WriteLine();
            }

        }
    }
    class Rectangle : Shape
    {
        public Rectangle(int x, int y, int height, int width)
        {
            X = x;

            Y = y;

            Height = height;

            Width = width;
        }
        public override void Draw()
        {

            Console.WriteLine($"Rysowanie shape ({X}, {Y}) o wysokości {Height} i szerokości {Width}");

        }
    }

    class Triangle : Shape
    {
        public Triangle(int x, int y, int height, int width)
        {
            X = x;

            Y = y;

            Height = height;

            Width = width;
        }
        
        public override void Draw()
        {
            Console.WriteLine($"Rysowanie shape ({X}, {Y}) o wysokości {Height} i szerokości {Width}");
        }
    }
    class Circle : Shape
    {
        public Circle(int x, int y, int radius)
        {
            X = x;

            Y = y;

            Height = radius * 2;

            Width = radius * 2;
        }

        public override void Draw()
        {
            Console.WriteLine($"Rysowanie shape ({X}, {Y}) o radius {Height / 2}");
        }
    }
}