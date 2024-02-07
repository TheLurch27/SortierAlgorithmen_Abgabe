using System;

namespace SortierAlgorithmen_Abgabe
{
    public class Menu
    {
        private static int selectedOption = 0;
        private static string[] mainMenuOptions = { "Generated sequence of numbers", "Own sequence of numbers", "Exit" };
        private static string[] sortMenuOptions = { "Mergesort", "Selectionsort", "Quicksort" };
        private static string[] orderMenuOptions = { "Ascending", "Descending", "Zigzag" };

        public static void PrintMainMenu()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                for (int i = 0; i < mainMenuOptions.Length; i++)
                {
                    if (i == selectedOption)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(mainMenuOptions[i]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(mainMenuOptions[i]);
                    }
                }

                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedOption = (selectedOption + 1) % mainMenuOptions.Length;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedOption = (selectedOption - 1 + mainMenuOptions.Length) % mainMenuOptions.Length;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    switch (selectedOption)
                    {
                        case 0:
                            Program.GenerateSequence();
                            break;
                        case 1:
                            Program.OwnSequence();
                            break;
                        case 2:
                            Environment.Exit(0);
                            break;
                    }
                }

            } while (key.Key != ConsoleKey.Escape);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }

        public static void PrintSortMenu(int[] sequence)
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                for (int i = 0; i < sortMenuOptions.Length; i++)
                {
                    if (i == selectedOption)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(sortMenuOptions[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(sortMenuOptions[i]);
                    }
                }

                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedOption = (selectedOption + 1) % sortMenuOptions.Length;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedOption = (selectedOption - 1 + sortMenuOptions.Length) % sortMenuOptions.Length;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Program.SortOrderMenu(sortMenuOptions[selectedOption], sequence);
                    return;
                }

            } while (key.Key != ConsoleKey.Escape);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }

        public static void PrintOrderMenu(string selectedAlgorithm, int[] sequence)
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine($"Select the sort order for {selectedAlgorithm}:");
                for (int i = 0; i < orderMenuOptions.Length; i++)
                {
                    if (i == selectedOption)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(orderMenuOptions[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(orderMenuOptions[i]);
                    }
                }

                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedOption = (selectedOption + 1) % orderMenuOptions.Length;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedOption = (selectedOption - 1 + orderMenuOptions.Length) % orderMenuOptions.Length;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Program.SortSelectedOrder(selectedAlgorithm, orderMenuOptions[selectedOption], sequence);
                    return;
                }

            } while (key.Key != ConsoleKey.Escape);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }
    }
}
