using System.Linq;

namespace ConsoleApp14
{

    class Car
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int Year { get; set; }

        public Car(string name, string manufacturer, int year)
        {
            Name = name;
            Manufacturer = manufacturer;
            Year = year;
        }
    }

    class CarComparer : IEqualityComparer<Car>
    {
        public bool Equals(Car x, Car y)
        {
            return x.Manufacturer == y.Manufacturer;
        }

        public int GetHashCode(Car obj)
        {
            return obj.Manufacturer.GetHashCode();
        }
    }
        class Program
    {
        static void Main()
        {
            //3 частина (1-3)
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
            //2 частина номер 1
            string[] array2 = { "apple", "banana", "cherry",  "elderberry" };

            Console.WriteLine("Сортування за спаданням довжини рядків:");
            SortByStringLengthDescending(array2);

            Console.WriteLine("Сортування за зростанням довжини рядків:");
            SortByStringLengthAscending(array2);

            //2 частина номер 2
            int[] arr1 = { 1, 2, 3, 4, 5 };
            int[] arr2 = { 4, 5, 6, 7, 8 };

            Console.WriteLine("Різниця двох масивів:");
            var difference = arr1.Except(arr2);
            PrintArray(difference);

            Console.WriteLine("Перетин двох масивів:");
            var intersection = arr1.Intersect(arr2);
            PrintArray(intersection);

            Console.WriteLine("Об'єднання двох масивів без дублікатів:");
            var union = arr1.Union(arr2);
            PrintArray(union);

            Console.WriteLine("Вміст першого масиву без повторень:");
            var distinct = arr1.Distinct();
            PrintArray(distinct);

            //2 частина номер 3
            Car[] cars1 = {
            new Car("BMW", "BMW Group", 2018),
            new Car("Toyota Camry", "Toyota", 2019),
            new Car("Honda Accord", "Honda", 2020)
                };

            Car[] cars2 = {
            new Car("BMW", "BMW Group", 2018),
            new Car("Toyota Corolla", "Toyota", 2021),
            new Car("Ford Mustang", "Ford", 2017)
                };

            Console.WriteLine("Різниця двох масивів:");
            var difference3 = cars1.Except(cars2, new CarComparer());
            PrintCars(difference3);

            Console.WriteLine("Перетин двох масивів:");
            var intersection3 = cars1.Intersect(cars2, new CarComparer());
            PrintCars(intersection3);

            Console.WriteLine("Об'єднання двох масивів:");
            var union3 = cars1.Union(cars2, new CarComparer());
            PrintCars(union3);
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

        static void SortByStringLengthDescending(string[] array2)
        {
            var sortedArray = array2.OrderByDescending(str => str.Length);
            Console.WriteLine(string.Join(", ", sortedArray));
        }

        static void SortByStringLengthAscending(string[] array2)
        {
            var sortedArray = array2.OrderBy(str => str.Length);

            Console.WriteLine(string.Join(", ", sortedArray));
           
        }

        static void PrintArray(IEnumerable<int> array)
        {
            Console.WriteLine(string.Join(", ", array));

        }

        static void PrintCars(IEnumerable<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"Назва: {car.Name}, Виробник: {car.Manufacturer}, Рік випуску: {car.Year}");
            }
            Console.WriteLine();
        }

    }
}