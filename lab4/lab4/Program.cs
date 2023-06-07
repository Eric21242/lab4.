using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] array = GenerateRandomArray();
        Console.WriteLine("Исходный массив:");
        PrintArray(array);

        Array.Sort(array); // Сортировка методом вставок

        Console.WriteLine("Отсортированный массив:");
        PrintArray(array);

        Console.Write("Введите ключевое значение: ");
        int key = int.Parse(Console.ReadLine());

        int count = CountOccurrences(array, key);
        Console.WriteLine($"Значение {key} встречается {count} раз в массиве.");

        Console.Write("Введите ключевое значение для поиска: ");
        int searchKey = int.Parse(Console.ReadLine());

        int index = BinarySearch(array, searchKey);
        if (index >= 0)
            Console.WriteLine($"Значение {searchKey} найдено в массиве на позиции {index}.");
        else
            Console.WriteLine($"Значение {searchKey} не найдено в массиве.");

        Console.ReadLine();
    }

    static int[] GenerateRandomArray()
    {
        Random random = new Random();
        int size = CalculateArraySize();
        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(10, 101);
        }

        return array;
    }

    static int CalculateArraySize()
    {
        Console.Write("Введите номер студента: ");
        int k = int.Parse(Console.ReadLine());
        int size = (int)(20 + 0.6 * k);
        return size;
    }

    static void PrintArray(int[] array)
    {
        foreach (int num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    static int CountOccurrences(int[] array, int key)
    {
        int count = array.Count(n => n == key);
        return count;
    }

    static int BinarySearch(int[] array, int key)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int middle = (left + right) / 2;

            if (array[middle] == key)
                return middle;

            if (array[middle] < key)
                left = middle + 1;
            else
                right = middle - 1;
        }

        return -1; // Значение не найдено
    }
}
