using System;

namespace zadanie6
{
    class Program
    {
        static void Main(string[] args)
        {
            int a1, a2, a3, N;

            Console.WriteLine("Введите а1");
            a1 = InputInt();

            Console.WriteLine("Введите а2");
            a2 = InputInt();

            Console.WriteLine("Введите а3");
            a3 = InputInt();

            Console.WriteLine("Введите N");
            N = InputInt(3, 100);

            double[] arr = new double[N];
            arr[0] = a1;
            arr[1] = a2;
            arr[2] = a3;

            arr = CreateArray(arr, 0);

            double[] result = FindMaxlength(arr);

            Console.WriteLine("Элементы последовательности:");
            foreach (var num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Длина максимальной возрастающей подпоследовательности");
            Console.WriteLine(result[0]);
            Console.WriteLine("Последний элемент максимальной возрастающей подпоследовательности");
            Console.WriteLine(result[1]);

            Console.ReadLine();
        }

        private static double[] CreateArray(double[] arr, int i)
        {
            if (i == arr.Length)
            {
                return arr;
            }

            if (i >= 3)
            {
                arr[i] = (arr[i - 1] + arr[i - 2]) / 2 - arr[i - 3];
            }

            return CreateArray(arr, ++i);
        }

        private static double[] FindMaxlength(double[] arr, int i = 0, int j = 1, int[] counts = null)
        {
            if (counts == null)
            {
                counts = new int[arr.Length];

                for (int k = 0; k < arr.Length; k++)
                {
                    counts[k] = 1;
                }
            }

            if (arr[j] > arr[i])
            {
                if (counts[j] <= counts[i])
                {
                    counts[j] = counts[j] + 1;
                }
            }

            if (i == arr.Length - 2)
            {
                // result[0] - длина максимальной возрастающей подпоследовательности
                // result[1] - последний элемент максимальной возрастающей подпоследовательности
                double[] result = new double[2];

                int maxLength = 0;
                int indexOfLastElem = 0;
                for (int k = 0; k < counts.Length; k++)
                {
                    if (counts[k] > maxLength)
                    {
                        maxLength = counts[k];
                        indexOfLastElem = k;
                    }
                }

                result[0] = maxLength;
                result[1] = arr[indexOfLastElem];

                return result;
            }

            return i == j - 1 ? FindMaxlength(arr, 0, ++j, counts) : FindMaxlength(arr, ++i, j, counts);
        }

        private static int InputInt()
        {
            int num;
            bool isOk;

            do
            {
                isOk = int.TryParse(Console.ReadLine(), out num);

                if (!isOk)
                {
                    Console.WriteLine("Введите целое число");
                }
            } while (!isOk);

            return num;
        }

        private static int InputInt(int min, int max)
        {
            int num;
            bool isOk;

            do
            {
                isOk = int.TryParse(Console.ReadLine(), out num);

                if (!isOk)
                {
                    Console.WriteLine("Введите целое число");
                }

                if (num < min || num > max)
                {
                    Console.WriteLine($"Введите целое число от {min} до {max}");
                    isOk = false;
                }
            } while (!isOk);

            return num;
        }
    }
}

