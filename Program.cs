using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;

class Program
{
    static int[] NumberArray;

    static void InsertionSort(int[] NumberArray)
    {
        int n = NumberArray.Length;
        int j;
        for (int i = 1; i < n; i++)
        {
            j = i;
               while(j>0 && (NumberArray[j-1] > NumberArray[j]))
               {
                
                int temp = NumberArray[j];
                NumberArray[j] = NumberArray[j-1];
                NumberArray[j-1] = temp;
                j--;   
               }
        }
    }
    static void SelectionSort(int[] NumberArray)
    {
        int n = NumberArray.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (NumberArray[j] < NumberArray[minIndex])
                {
                    minIndex = j;
                }
            }

            int temp = NumberArray[minIndex];
            NumberArray[minIndex] = NumberArray[i];
            NumberArray[i] = temp;
        }
    }

    static void BubbleSort(int[] NumberArray)
    {
        bool HasAnythingChanged = true;

        while (HasAnythingChanged == true)
        {
            HasAnythingChanged = false;
            int n = NumberArray.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (NumberArray[i] > NumberArray[i + 1])
                {
                    int temp = NumberArray[i];

                    NumberArray[i] = NumberArray[i + 1];
                    NumberArray[i + 1] = temp;
                    HasAnythingChanged = true;  
                }
            }
        }
    }

    static void GenerateNumbers(int NumberAmount)
    {
        Random rnd = new Random();

        using (StreamWriter Writer = new StreamWriter("RandomNumbers.txt"))
        {
            for (int i = 0; i < NumberAmount; i++)
            {
                Writer.WriteLine(rnd.Next(0, 1000000));
            }
        }
    }

    static void ReadNumbersToArray()
    {
        string[] Lines = File.ReadAllLines("RandomNumbers.txt");

        // Create an array to store the integers
        NumberArray = new int[Lines.Length];

        // Parse each line as an integer and store it in the array
        for (int i = 0; i < Lines.Length; i++)
        {
            NumberArray[i] = int.Parse(Lines[i]);
        }
    }

    static bool CheckArray(int[] arr)
    {
        int LastNumber = 0;
        for (int i = 0; i < arr.Length; i++) 
        {
            if (LastNumber <= arr[i])
            {
                LastNumber = arr[i];
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    static void Main()
    {
        Console.WriteLine("SelectionSort");
        //SelectionSort
        Stopwatch Stopwatch = new Stopwatch();
        int j = 1;
        for (int i = 0; i < 5; i++)
        {

            GenerateNumbers(j * 8000);
            ReadNumbersToArray();
            Stopwatch.Restart();
            SelectionSort(NumberArray);
            Stopwatch.Stop();

            if (CheckArray(NumberArray) == false)
            {
                Console.WriteLine("Sorted Incorrectly");
            }

            Console.WriteLine("{0} integers Elapsed time: {1}", j * 8000, Stopwatch.Elapsed);
            j *= 2;
        }


        Console.WriteLine();
        Console.WriteLine("BubbleSort");
        j = 1;
        //BubbleSort
        for (int i = 0; i < 5; i++)
        {

            GenerateNumbers(j * 8000);
            ReadNumbersToArray();
            Stopwatch.Restart();
            BubbleSort(NumberArray);
            Stopwatch.Stop();

            if (CheckArray(NumberArray) == false)
            {
                Console.WriteLine("Sorted Incorrectly");
            }

            Console.WriteLine("{0} integers Elapsed time: {1}", j * 8000, Stopwatch.Elapsed);
            j *= 2;
        }

        Console.WriteLine();
        Console.WriteLine("InsertionSort");
        j = 1;
        //InsertionSort
        for (int i = 0; i < 5; i++)
        {

            GenerateNumbers(j * 8000);
            ReadNumbersToArray();
            Stopwatch.Restart();
            InsertionSort(NumberArray);
            Stopwatch.Stop();

            if (CheckArray(NumberArray) == false)
            {
                Console.WriteLine("Sorted Incorrectly");
            }

            Console.WriteLine("{0} integers Elapsed time: {1}", j * 8000, Stopwatch.Elapsed);
            j *= 2;
        }
    }
}