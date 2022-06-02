using System;
using System.IO;

namespace DyerHasNItems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // объект для чтения из файла
            using (StreamReader sr = new StreamReader("file.txt"))
            {
                int position = 0;
                var inputData = sr.ReadToEnd().Replace("\r\n", " "); // чтение строки из файла
                var separateData = inputData.Split(' '); // разбиение строки на числа
                int n = ReadData(ref position, separateData);
                // массив строк
                int[,] mas = new int[n, 3];
                for (int i = 0; i < n; i++)
                {
                    mas[i, 0] = ReadData(ref position, separateData);
                    mas[i, 1] = ReadData(ref position, separateData);
                    mas[i, 2] = i;
                }

                for (int q = 0; q < n; q++)
                {
                    for (int i = 0; i < n - 1; i++)
                    {
                        if (mas[i, 1] < mas[i + 1, 1])
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                Swap(ref mas[i, j],ref mas[i + 1, j]);
                            }
                        }    
                    }  
                }
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"{mas[i, 2] + 1} ");
                }
            }
            Console.ReadLine();
        }

        // меняем местами
        static void Swap(ref int lhs, ref int rhs)
        {
            int temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        // при каждом вызове берется следующее значение из файла (строки)
        static int ReadData(ref int position, string[] separateData)
        {
            var result = Convert.ToInt32(separateData[position]);
            position++;
            return result;
        }
    }
}