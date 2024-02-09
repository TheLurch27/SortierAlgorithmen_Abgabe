using System;
using System.Linq;

namespace SortierAlgorithmen_Abgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.PrintMainMenu();
        }

        public static void GenerateSequence()
        {
            Console.Clear();
            int size = ReadSizeInput();

            Random random = new Random();
            var sequence = Enumerable.Range(1, size).Select(_ => random.Next(1, 101)).ToArray();

            Console.WriteLine("Generated sequence:");
            PrintArray(sequence);
            Menu.PrintSortMenu(sequence);
        }

        public static void OwnSequence()
        {
            Console.Clear();
            Console.WriteLine("Enter your own sequence of numbers (separated by spaces):");
            string input;
            bool isValidInput;
            do
            {
                input = Console.ReadLine();
                string[] numbers = input.Split(' ');
                isValidInput = numbers.Length >= 10 && numbers.Length <= 50;
                foreach (string number in numbers)
                {
                    isValidInput &= int.TryParse(number, out int _) && Math.Abs(int.Parse(number)) < 100;
                }
                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid sequence of 10 to 50 numbers separated by spaces.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                    Console.Clear();
                    Console.WriteLine("Enter your own sequence of numbers (separated by spaces):");
                }
            } while (!isValidInput);

            var sequence = input.Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine("Entered sequence:");
            PrintArray(sequence);
            Menu.PrintSortMenu(sequence);
        }

        public static void SortOrderMenu(string selectedAlgorithm, int[] sequence)
        {
            Menu.PrintOrderMenu(selectedAlgorithm, sequence);
        }

        public static void SortSelectedOrder(string selectedAlgorithm, string order, int[] sequence)
        {
            Console.Clear();
            Console.WriteLine($"Selecting {order.ToLower()} order for {selectedAlgorithm}...");
            Console.WriteLine($"Original sequence:");
            PrintArray(sequence);
            Console.WriteLine();

            switch (order.ToLower())
            {
                case "ascending":
                    SortAlgorithmStepByStep(selectedAlgorithm, sequence, ascending: true);
                    break;
                case "descending":
                    SortAlgorithmStepByStep(selectedAlgorithm, sequence, ascending: false);
                    break;
                case "zigzag":
                    ZigzagSort(sequence);
                    break;
            }

            Console.WriteLine($"Sorted sequence:");
            PrintArray(sequence);
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey(true);
            Menu.PrintMainMenu();
        }

        public static void DisplaySortStepByStep(int[] array)
        {
            if (array == null || array.Length <= 1)
            {
                Console.WriteLine("Array is already sorted or empty.");
                return;
            }

            int[] tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);

            Console.WriteLine("Unsorted array: " + string.Join(", ", tempArray));

            Console.WriteLine("Sorted array: " + string.Join(", ", tempArray));
        }

        private static int ReadSizeInput()
        {
            int size;
            bool isValidInput;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter the size of the sequence (between 10 and 50):");
                string input = Console.ReadLine();
                isValidInput = int.TryParse(input, out size) && size >= 10 && size <= 50;
                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer between 10 and 50.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                }
            } while (!isValidInput);

            return size;
        }

        private static void PrintArray(int[] array)
        {
            foreach (var num in array)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }

        public static void SortAlgorithmStepByStep(string algorithm, int[] sequence, bool ascending)
        {
            switch (algorithm.ToLower())
            {
                case "mergesort":
                    if (ascending)
                        Mergesort.Sort(sequence);
                    else
                        Mergesort.MergesortDescending(sequence);
                    break;
                case "selectionsort":
                    if (ascending)
                        Selectionsort.Sort(sequence);
                    else
                        Selectionsort.SortDescending(sequence);
                    break;
                case "quicksort":
                    if (ascending)
                        Quicksort.Sort(sequence, 0, sequence.Length - 1);
                    else
                        Quicksort.SortDescending(sequence, 0, sequence.Length - 1);
                    break;
                default:
                    Console.WriteLine("Invalid algorithm selected.");
                    break;
            }
        }

        public static void ZigzagSort(int[] sequence)
        {
            Array.Sort(sequence);
            int left = 0, right = sequence.Length - 1;
            int[] result = new int[sequence.Length];
            int index = 0;

            while (left <= right)
            {
                result[index++] = sequence[right--];
                if (left <= right)
                {
                    result[index++] = sequence[left++];
                }
            }

            result.CopyTo(sequence, 0);
        }

        public static void PrintZigzag(int[] _numbers)
        {
            int[] zigzagNumbers = new int[_numbers.Length];

            int left = 0;
            int right = _numbers.Length - 1;
            bool isLeftTurn = true;

            for (int i = 0; i < _numbers.Length; i++)
            {
                if (isLeftTurn)
                {
                    zigzagNumbers[i] = _numbers[right];
                    right--;
                }
                else
                {
                    zigzagNumbers[i] = _numbers[left];
                    left++;
                }

                isLeftTurn = !isLeftTurn;
            }

            Console.WriteLine("Sorted in zigzag:");
            Console.WriteLine(string.Join(" ", zigzagNumbers));
        }
    }
}
