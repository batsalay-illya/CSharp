using System;

namespace Контрольна_робота
{
    internal class Program
    {
        private static Random random = new Random();

        static void Main()
        {
            //Для підтримки української мови
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть розмір першого масиву (> 0): ");
            int first_array_length = GetUserInput();
            Console.Write("Введіть розмір другого масиву (> 0): ");
            int second_array_length = GetUserInput();

            int[] first_array = new int[first_array_length];
            int[] second_array = new int[second_array_length];
            int[] result;

            //Виклики функції, яка задає випадкові числа (0-9) у масив
            first_array = GenerateRandomNumbers(first_array);
            second_array = GenerateRandomNumbers(second_array);

            //Виклик функції, яка додає кожен елемен одного масиву, до відповідного у другому масиві
            result = SumTwoArrays(first_array, second_array);

            //Обертання масиву
            Array.Reverse(result);

            Console.WriteLine("Перший масив:");
            PrintArray(first_array);
            Console.WriteLine("Другий масив:");
            PrintArray(second_array);

            Console.WriteLine("\nРезультат додавання:");
            PrintArray(first_array);
            PrintArray(second_array);

            for (int i = 0; i < second_array_length; i++)
                Console.Write("-");

            Console.WriteLine();
            PrintArray(result);

            //Очікування будь-якого вводу, для закриття програми
            Console.ReadKey();
        }
        private static int GetUserInput()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Clear();
                Console.WriteLine("Ви ввели неправельні дані...");
                Console.Write("Введіть розмір масиву (> 0): ");
            }
            if (result <= 0)
            {
                Console.Clear();
                Console.WriteLine("Введений розмір масиву меньший, або рівний нулю...");
                Console.Write("Введіть розмір масиву (> 0): ");
                result = GetUserInput();
            }
            return result;
        }
        private static int[] GenerateRandomNumbers(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i == 0 ? random.Next(1, 9) : random.Next(0, 9);
            }
            return array;
        }
        private static int[] SumTwoArrays(int[] first_array, int[] second_array)
        {
            int maxLenght = Math.Max(first_array.Length, second_array.Length);
            int[] temp_result = new int[maxLenght+1];

            try
            {
                for (int i = 0; i < maxLenght; i++)
                {
                    int first_value = i < first_array.Length ? first_array[(first_array.Length-1) - i] : 0;
                    int second_value = i < second_array.Length ? second_array[(second_array.Length-1) - i] : 0;

                    int sum = first_value + second_value + temp_result[i];
                    if (sum >= 10)
                    {
                        temp_result[i] = sum % 10;
                        temp_result[i + 1] = sum / 10;
                        continue;
                    }
                    temp_result[i] = sum;
                }

                if (temp_result[maxLenght] == 0)
                    Array.Resize(ref temp_result, maxLenght);

                return temp_result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new int[maxLenght];
            }
        }
        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
            Console.WriteLine();
        }
    }
}