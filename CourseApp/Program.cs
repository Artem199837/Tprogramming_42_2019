using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp
{
    public class Program
    {
        public static double FuncthionZnach(double x)
        {
            double a = 1.2;
            double b = 0.28;
            double result = (Math.Pow(b, 3) + Math.Pow(Math.Sin(a * x), 2)) / (Math.Asin(x * b * x) + Math.Exp(-x / 2));
            return result;
        }

        public static double[] FuncthionForShag(double x_natch, double x_konch, double x_shag)
        {
            var result = new double[(int)((x_konch - x_natch) / x_shag) + 1];
            int kolch = 0;
            for (double i = x_natch; i <= x_konch; i += x_shag)
            {
                result[kolch] = FuncthionZnach(i);
                kolch++;
            }

            return result;
        }

        public static double[] FuncthionForMass(double[] x)
        {
            var y = new double[x.Length];
            for (var i = 0; i < x.Length; i++)
            {
                y[i] = FuncthionZnach(x[i]);
            }

            return y;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine($"Задание A:");
            foreach (double element in FuncthionForShag(0.7, 2.2, 0.3))
            {
                Console.WriteLine(element);
            }

            Console.WriteLine($"\nЗадание B:");
            var x = new double[] { 0.25, 0.36, 0.56, 0.94, 1.28 };
            foreach (var element in FuncthionForMass(x))
            {
                Console.WriteLine($"y = {element}");
            }

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
