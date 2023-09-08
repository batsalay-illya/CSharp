using System;

namespace Контрольна_робота
{
    internal class Program
    {
        private static Random random = new Random();

        public enum Operators
        {
            Addition,
            Subtraction,
            None
        }

        static void Main()
        {
            //Для підтримки української мови
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            int first_array_length = GetUserInput(msg:"Введіть розмір першого масиву: ", clampMin:1);
            int second_array_length = GetUserInput(msg:"Введіть розмір другого масиву: ", clampMin:1);

            Operators _operator = Operators.None;
            GetOperatorFromUserInput(ref _operator);

            int[] first_array = new int[first_array_length];
            int[] second_array = new int[second_array_length];
            int[] result;

            //Виклики функції, яка задає випадкові числа (0-9) у масив
            first_array = GenerateRandomNumbers(first_array);
            second_array = GenerateRandomNumbers(second_array);

            switch (_operator)
            {
                case Operators.Addition:
                    //Виклик функції, яка додає кожен елемен одного масиву, до відповідного у другому масиві
                    result = SumTwoArrays(first_array, second_array);
                    break;
                
                case Operators.Subtraction:
                    result = SubtractTwoArrays(first_array, second_array);
                    break;

                default:
                    result = new int[] { };
                    Console.WriteLine("Некоректно задано операцію над масивами");
                    break;
            }

            //Обертання масиву
            Array.Reverse(result);

            Console.WriteLine("Перший масив:");
            PrintArray(first_array);
            Console.WriteLine("Другий масив:");
            PrintArray(second_array);

            Console.WriteLine("\nРезультат:");
            PrintArray(first_array);
            PrintArray(second_array);

            for (int i = 0; i < second_array_length; i++)
                Console.Write("-");

            Console.WriteLine();
            PrintArray(result);

            //Очікування будь-якого вводу, для закриття програми
            Console.ReadKey();
        }
        private static int GetUserInput(string msg = "Введіть дані: ", int clampMin = int.MinValue, int clampMax = int.MaxValue)
        {
            int input;
            Console.Write(msg);
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                PrintError();
                Console.Write(msg);
            }
            
            return Math.Min(Math.Max(input, clampMin), clampMax);
        }
        private static void GetOperatorFromUserInput(ref Operators _operator)
        {
            int operatorIndex = GetUserInput(msg:"Оберіть номер відповідної операції над масивами: \n|0 = (+)| \n|1 = (-)|\n ");
            switch (operatorIndex)
            {
                case 0:
                    _operator = Operators.Addition;
                    break;
                case 1:
                    _operator = Operators.Subtraction;
                    break;

                default:
                    PrintError();
                    GetOperatorFromUserInput(ref _operator);
                    break;
            }
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
        private static int[] SubtractTwoArrays(int[] first_array, int[] second_array)
        {
            int maxLenght = Math.Max(first_array.Length, second_array.Length);
            int firstFullValue = GetFullValueFromArray(first_array);
            int secondFullValue = GetFullValueFromArray(second_array);
            
            int[] temp_result = new int[maxLenght+1];

            try
            {
                for (int i = 0; i < maxLenght; i++)
                {
                    int first_value = i < first_array.Length ? first_array[(first_array.Length - 1) - i] : 0;
                    int second_value = i < second_array.Length ? second_array[(second_array.Length - 1) - i] : 0;

                    int subtract;

                    if (firstFullValue < secondFullValue)
                         subtract = (second_value + temp_result[i]) - first_value;
                    else
                        subtract = (first_value + temp_result[i]) - second_value;

                    if (subtract < 0)
                    {
                        temp_result[i] = 10 + subtract;
                        temp_result[i + 1] = temp_result[i + 1] - 1;
                        continue;
                    }
                    temp_result[i] = subtract;
                }

                int final_lenght = maxLenght;
                for (int i = maxLenght-1; i >= 0; i--)
                {
                    if (temp_result[i] == 0)
                    {
                        final_lenght--;
                    }
                }

                Array.Resize(ref temp_result, final_lenght);

                if (firstFullValue < secondFullValue)
                {
                    temp_result[temp_result.Length - 1] *= -1;
                }

                return temp_result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new int[maxLenght];
            }
        }
        private static int GetFullValueFromArray(int[] array)
        {
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                result += array[0] * (int)Math.Pow(10, array.Length - i); 
            }

            return result;
        }
        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
            Console.WriteLine();
        }
        private static void PrintError()
        {
            Console.Clear();
            Console.WriteLine("Ви ввели неправельні дані...");
        }
    }
}
