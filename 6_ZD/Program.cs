using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersice6
{
    class Program
    {
        static bool ok = false;
        static bool NeMonoton = true;
        static void PrintMas(double[] mas1)
        {
            if (mas1.Length == 0) return;
            else
                for (int i = 0; i < mas1.Length; i++)
                {
                    Console.WriteLine(mas1[i]);
                }
        }
        static double Function(double[] mas1, int n)
        {
            if (n == 0)
            {
                return mas1[0];
            }
            else
            if (n == 1)
            {
                return mas1[1];
            }
            else
            if (n == 2)
            {
                return mas1[2];
            }
            else
                return mas1[n] = 0.7 * mas1[n - 1] - 0.2 * mas1[n - 2] + n * mas1[n - 3];
        }

        static void NeChetnost(double[] mas)
        {
            int Length = 0;
            for (int i = 1; i < mas.Length + 1; i++)
            {
                if (i % 2 != 0)
                {
                    Length++;
                }
                else continue;
            }

            double[] ne_chet_mas = new double[Length];
            int count = 0;
            for (int i = 1; i < mas.Length + 1; i++)
            {
                if (i % 2 != 0)
                {
                    ne_chet_mas[count] = mas[i - 1];
                    count++;
                }
                else continue;
            }
            PrintMas(ne_chet_mas);

            for (int i = 1; i < ne_chet_mas.Length; i++)
            {
                if (ne_chet_mas[i - 1] < ne_chet_mas[i])
                {
                    ok = false;
                    NeMonoton = false;

                }
                else if (ne_chet_mas[i - 1] > ne_chet_mas[i])
                {
                    ok = true;
                    NeMonoton = false;
                }
                else NeMonoton = true;
            }
        }

        static void Main(string[] args)
        {
            int a1, a2, a3, N;

            Console.WriteLine("Введите число a1: ");
            a1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите число a2: ");
            a2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите число a3: ");
            a3 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество элементов массива N: ");
            N = Convert.ToInt32(Console.ReadLine());

            try
            {
                double[] mas2 = new double[N];
                mas2[0] = a1;
                mas2[1] = a2;
                mas2[2] = a3;

                int place = 3;

                while (place < mas2.Length)
                {
                    Function(mas2, place);
                    place++;
                }
                PrintMas(mas2);

                Console.WriteLine("Массив с нечетными элементами!");
                NeChetnost(mas2);
            }
            catch
            {
                Console.WriteLine("Неверный размер массива!");
            }

            Console.WriteLine();

            Console.WriteLine("Определение последовательности на монотонность: ");
            if (ok == false && NeMonoton == false) Console.WriteLine("Монотонная неубывающая последовательность - возрастает");
            else if (ok == true && NeMonoton == false) Console.WriteLine("Монотонная убывающая последовательность - убывает");
            else Console.WriteLine("Последовательность - не монотонная");
            Console.ReadKey();
        }
    }
}