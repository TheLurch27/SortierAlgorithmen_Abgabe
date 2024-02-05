using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        ZeigeHauptmenü();
    }

    static void ZeigeHauptmenü()
    {
        List<string> options = new List<string>
        {
            "1. Zufallszahlen generieren",
            "2. Eigene Zahlen eingeben",
            "3. Beenden"
        };
        Console.Clear();

        int selectedIndex = 0;
        while (true)
        {
            Console.Clear();
            foreach (string option in options)
            {
                if (options.IndexOf(option) == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(option);
                Console.ResetColor();
            }

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + options.Count) % options.Count;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % options.Count;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                if (selectedIndex == options.Count - 1)
                {
                    Environment.Exit(0); // Beende das Programm
                }
                else
                {
                    VerarbeiteHauptmenüAuswahl(selectedIndex + 1);
                }
            }
        }
    }

    static void VerarbeiteHauptmenüAuswahl(int option)
    {
        switch (option)
        {
            case 1:
                GeneriereZufälligeZahlen();
                break;
            case 2:
                EingabeEigenerZahlen();
                break;
            case 3:
                Environment.Exit(0);
                break;
            default:
                break;
        }
    }

    static void GeneriereZufälligeZahlen()
    {
        int count = 0; // Variable initialisieren#
        Console.Clear();
        Console.WriteLine("Wie viele Zahlen möchten Sie generieren? (10-50)");
        bool validInput = false;

        while (!validInput)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out count))
            {
                if (count >= 10 && count <= 50)
                {
                    validInput = true;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl zwischen 10 und 50 ein.");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey(true);
                    Console.Clear();
                    Console.WriteLine("Wie viele Zahlen möchten Sie generieren? (10-50)");
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl zwischen 10 und 50 ein.");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(true);
                Console.Clear();
                Console.WriteLine("Wie viele Zahlen möchten Sie generieren? (10-50)");
            }
        }

        // Code für die Generierung von Zufallszahlen mit der Anzahl "count" hier
        Random random = new Random();
        List<int> generatedNumbers = new List<int>();
        for (int i = 0; i < count; i++)
        {
            generatedNumbers.Add(random.Next(1, 101)); // Zufallszahl zwischen 1 und 100
        }

        Console.Clear();
        Console.WriteLine($"Generierte Zahlen ({count}): {string.Join(", ", generatedNumbers)}");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren.");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey(true);
        ZeigeSortierAlgorithmenMenü(generatedNumbers);
    }

    static void EingabeEigenerZahlen()
    {
        Console.Clear();
        Console.WriteLine("Geben Sie die Zahlenreihenfolge ein, getrennt durch Leerzeichen:");
        string input;
        List<int> numbers = new List<int>();
        bool validInput = false;

        while (!validInput)
        {
            input = Console.ReadLine();
            string[] inputArray = input.Split(' ');

            if (inputArray.Length >= 10 && inputArray.Length <= 50)
            {
                validInput = true;
                foreach (string numStr in inputArray)
                {
                    if (int.TryParse(numStr, out int num))
                    {
                        numbers.Add(num);
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ungültige Eingabe. Bitte geben Sie nur ganze Zahlen getrennt durch Leerzeichen ein.");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey(true);
                        Console.Clear();
                        Console.WriteLine("Geben Sie die Zahlenreihenfolge erneut ein:");
                        validInput = false;
                        break;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie zwischen 10 und 50 Zahlen getrennt durch Leerzeichen ein.");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(true);
                Console.Clear();
                Console.WriteLine("Geben Sie die Zahlenreihenfolge ein, getrennt durch Leerzeichen:");
            }
        }

        // Hier können Sie die eingegebenen Zahlen verwenden, z.B. sortieren oder analysieren
        Console.WriteLine("Eingegebene Zahlen:");
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
        Console.ReadKey(true);
        ZeigeSortierAlgorithmenMenü(numbers);
    }

    static void ZeigeSortierAlgorithmenMenü(List<int> numbers)
    {
        List<string> options = new List<string>
    {
        "1. Selection Sort",
        "2. Merge Sort",
        "3. Quick Sort",
        "4. Zurück zum Hauptmenü"
    };

        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Bitte wählen Sie einen Sortieralgorithmus:");
            foreach (string option in options)
            {
                if (options.IndexOf(option) == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(option);
                Console.ResetColor();
            }

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + options.Count) % options.Count;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % options.Count;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                if (selectedIndex == options.Count - 1)
                {
                    break; // Exit aus dem Menü
                }
                else
                {
                    VerarbeiteSortierAuswahl(selectedIndex + 1, numbers);
                    break; // Aus dem Menü aussteigen, nachdem die Auswahl verarbeitet wurde
                }
            }
        }
    }

    static void VerarbeiteSortierAuswahl(int option, List<int> numbers)
    {
        switch (option)
        {
            case 1:
                SelectionSort(numbers);
                break;
            case 2:
                MergeSort(numbers, 0, numbers.Count - 1);
                break;
            case 3:
                QuickSort(numbers, 0, numbers.Count - 1);
                break;
            case 4:
                ZeigeHauptmenü();
                break;
            default:
                break;
        }
    }

    static void SelectionSort(List<int> arr)
    {
        List<int> originalNumbers = new List<int>(arr); // Speichern der unsortierten Zahlen

        int n = arr.Count;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;

            // Ausgabe mit farblich hervorgehobenen verschobenen Zahlen und Erklärung
            Console.Clear();
            Console.WriteLine($"Unsortierte Zahlen: {string.Join(", ", originalNumbers)}");
            Console.WriteLine();
            Console.Write($"Schritt {i + 1}: ");
            for (int k = 0; k < arr.Count; k++)
            {
                if (k == minIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // Gelb für die verschobene Zahl
                }
                else if (k <= i)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Grün für die Zahlen an der richtigen Position
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Rot für die Zahlen an der falschen Position
                }
                Console.Write(arr[k]);
                Console.ResetColor();
                if (k != arr.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }

        // Ausgabe der unsortierten Zahlen und Erklärung nach dem Sortiervorgang
        Console.WriteLine();
        Console.WriteLine("Rote Zahlen sind an der falschen Position.");
        Console.WriteLine("Gelbe Zahlen zeigen an, welche Zahlen verschoben wurden.");
        Console.WriteLine("Grüne Zahlen stehen an der richtigen Position.");
        Console.WriteLine();
        Console.WriteLine("Drücken Sie eine beliebige Taste, um zum Hauptmenü zurückzukehren.");
        Console.ReadKey(true);
        ZeigeHauptmenü();
    }

    static void MergeSort(List<int> arr, int l, int r)
    {
        if (l < r)
        {
            int m = l + (r - l) / 2;

            MergeSort(arr, l, m);
            MergeSort(arr, m + 1, r);

            Merge(arr, l, m, r);
        }
    }

    static void Merge(List<int> arr, int l, int m, int r)
    {
        // Implementierung von Merge
    }

    static void QuickSort(List<int> arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);

            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    static int Partition(List<int> arr, int low, int high)
    {
        int pivot = arr[high];
        int i = (low - 1);

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int temp1 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp1;

        // Ausgabe mit farblich hervorgehobener verschobener Zahl
        Console.Write($"Partition: ");
        for (int k = low; k <= high; k++)
        {
            if (k == i + 1)
            {
                Console.ForegroundColor = ConsoleColor.Green; // Farbe für die verschobene Zahl
            }
            Console.Write(arr[k]);
            Console.ResetColor();
            if (k != high)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();

        return i + 1;
    }


    static string GetSortierAlgorithmusName(int option)
    {
        switch (option)
        {
            case 1:
                return "Selection Sort";
            case 2:
                return "Merge Sort";
            case 3:
                return "Quick Sort";
            default:
                return "Unknown";
        }
    }

}
