using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите коэффициенты");
            Console.WriteLine("Введите a : ");
            float a = float.Parse(Console.ReadLine());
            Console.WriteLine("Введите b : ");
            float b = float.Parse(Console.ReadLine());
            Console.WriteLine("Введите c : ");
            float c = float.Parse(Console.ReadLine());
            var d = b * b - 4 * a * c;
            Console.WriteLine("D = {0}", d);
            var x1 = (-b - Math.Sqrt(d)) / 2 / a;
            var x2 = (-b + Math.Sqrt(d)) / 2 / a;
            Console.WriteLine("Результат : ");
            Console.WriteLine("x1 = {0}, x2 = {1}", x1, x2);
            Console.ReadKey();
        }
    }
}
