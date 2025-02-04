///Простейшая программа для ввода и обратного вывода списка геом.фигур с несколькими общими характеристиками
///Фигуры хранятся в виде структур в списке (List<T>)
///При некорректном вводе параметров очередной фигуры консоль предлагает повторный ввод
///После каждой очередной фигуры консоль предлагает прекратить ввод
using System.Drawing;
using System.Linq.Expressions;

namespace GeometryStructures
{
    public enum FigureType { Circle, Triangle, Rectangle, Polyangle };
    internal struct Figure
    {
        public FigureType Type;
        public Point Center;
        public Point StartingPoint;
        public double Space;
        public double Perimeter;
        public Figure(FigureType Type, Point Center, Point StartingPoint, double Space, double Perimeter)
        {
            this.Type = Type;
            this.Center = Center;
            this.StartingPoint = StartingPoint;
            this.Space = Space;
            this.Perimeter = Perimeter;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            FigureType type;
            Point center;
            Point start;
            int space;
            int perimeter;
            int i;
            List<Figure> figures = new List<Figure>();
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите тип фигуры (0 = Круг, 1 = Теугольник, 2 = Прямоугольник, 3 = Многоугольник)");
                    type = (FigureType)int.Parse(Console.ReadLine() ?? "");
                    Console.WriteLine("Введите центр фигуры (x,y)");
                    var coords = (Console.ReadLine() ?? "").Split(',');
                    center = new Point(int.Parse(coords[0]), int.Parse(coords[1]));
                    Console.WriteLine("Введите начальную координату фигуры (x,y)");
                    coords = (Console.ReadLine() ?? "").Split(',');
                    start = new Point(int.Parse(coords[0]), int.Parse(coords[1]));
                    Console.WriteLine("Введите площадь фигуры");
                    space = int.Parse(Console.ReadLine() ?? "");
                    Console.WriteLine("Введите периметр фигуры");
                    perimeter = int.Parse(Console.ReadLine() ?? "");
                }
                catch (Exception ex) { Console.WriteLine("Некорректный ввод, повторите"); continue; }
                figures.Add(new Figure(type, center, start, space, perimeter));
                Console.WriteLine("Завершить ввод фигур? Y/n");
                if ((Console.ReadLine() ?? "").ToUpper() == "Y") break;
            }
            i = 0;
            foreach (Figure f in figures)
            {
                Console.WriteLine($"Фигура #{i}: {f.Type} с центром в {f.Center}, началом отсчета в {f.StartingPoint}, площадью {f.Space} и периметром {f.Perimeter}");
                i++;
            }
        }
    }
}
