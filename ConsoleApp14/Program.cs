namespace ConsoleApp14
{
    class Program
    {
        static void Main()
        {
            int[] array = { 2, 4, 6, 8, 10, 9, 14, 18, 21, 945, 1000 };

            CalculateProduct(array);
            CalculateCount(array);
            CalculateCountDivisibleBy9(array);
            CalculateCountDivisibleBy7GreaterThan945(array);
            CalculateSum(array);
            CalculateSumEvenNumbers(array);
            CalculateMin(array);
            CalculateMax(array);
            CalculateAverage(array);
            DisplayMaxThree(array);
            DisplayMinThree(array);
            DisplayNumberStats(array);
            DisplayEvenNumberStats(array);
            DisplayEvenOddNumberStats(array);
        }

        static void CalculateProduct(int[] array)
        {
            int product = array.Aggregate((x, y) => x * y);
            Console.WriteLine("Добуток елементів масиву: " + product);
        }

        static void CalculateCount(int[] array)
        {
            int count = array.Length;
            Console.WriteLine("Кількість елементів масиву: " + count);
        }

        static void CalculateCountDivisibleBy9(int[] array)
        {
            int countDivisibleBy9 = array.Count(x => x % 9 == 0);
            Console.WriteLine("Кількість елементів масиву, кратних 9: " + countDivisibleBy9);
        }

        static void CalculateCountDivisibleBy7GreaterThan945(int[] array)
        {
            int countDivisibleBy7GreaterThan945 = array.Count(x => x % 7 == 0 && x > 945);
            Console.WriteLine("Кількість елементів масиву, кратних 7 і більших, ніж 945: " + countDivisibleBy7GreaterThan945);
        }

        static void CalculateSum(int[] array)
        {
            int sum = array.Sum();
            Console.WriteLine("Сума елементів масиву: " + sum);
        }

        static void CalculateSumEvenNumbers(int[] array)
        {
            int sumEvenNumbers = array.Where(x => x % 2 == 0).Sum();
            Console.WriteLine("Сума парних елементів масиву: " + sumEvenNumbers);
        }

        static void CalculateMin(int[] array)
        {
            int min = array.Min();
            Console.WriteLine("Мінімум в масиві: " + min);
        }

        static void CalculateMax(int[] array)
        {
            int max = array.Max();
            Console.WriteLine("Максимум в масиві: " + max);
        }

        static void CalculateAverage(int[] array)
        {
            double average = array.Average();
            Console.WriteLine("Середнє значення в масиві: " + average);
        }

        static void DisplayMaxThree(int[] array)
        {
            var maxThree = array.OrderByDescending(x => x).Take(3);
            Console.WriteLine("Три перші максимальні елементи:");
            Console.WriteLine(string.Join(", ", maxThree));
        }

        static void DisplayMinThree(int[] array)
        {
            var minThree = array.OrderBy(x => x).Take(3);
            Console.WriteLine("Три перші мінімальні елементи:");
            Console.WriteLine(string.Join(", ", minThree));
        }

        static void DisplayNumberStats(int[] array)
        {
            var numberStats = array.GroupBy(x => x)
                                   .Select(group => new { Number = group.Key, Count = group.Count() });

            Console.WriteLine("Статистика входження чисел до масиву:");
            foreach (var stat in numberStats)
            {
                Console.WriteLine($"{stat.Number} - {stat.Count} рази");
            }
        }

        static void DisplayEvenNumberStats(int[] array)
        {
            var evenNumberStats = array.Where(x => x % 2 == 0)
                                       .GroupBy(x => x)
                                       .Select(group => new { Number = group.Key, Count = group.Count() });

            Console.WriteLine("Статистика входження парних чисел до масиву:");
            foreach (var stat in evenNumberStats)
            {
                Console.WriteLine($"{stat.Number} - {stat.Count} рази");
            }
        }

        static void DisplayEvenOddNumberStats(int[] array)
        {
            var evenOddNumberStats = array.GroupBy(x => x % 2 == 0 ? "Парні" : "Непарні")
                                          .Select(group => new { Type = group.Key, Count = group.Count() });

            Console.WriteLine("Статистика входження парних і непарних чисел до масиву:");
            foreach (var stat in evenOddNumberStats)
            {
                Console.WriteLine($"{stat.Type} - {stat.Count} рази");
            }
        }
    }
}