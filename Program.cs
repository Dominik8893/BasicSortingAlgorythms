using System.Diagnostics;

class Program
{
     static int[] IntArray;
    static string[] StringArray;
    
    static void InsertionSort<T>(T[] Array) where T : IComparable<T>
    {
        int n = Array.Length;
        int j;
        for (int i = 1; i < n; i++)
        {
            j = i;
            while (j > 0 && (Array[j - 1].CompareTo(Array[j]) > 0))
            {              
                (Array[j], Array[j - 1]) = (Array[j - 1], Array[j]);              
                j--;
            }
        }
    }


    static void SelectionSort<T>(T[] Array) where T : IComparable<T>
    {
        int n = Array.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (Array[j].CompareTo(Array[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }

            T temp = Array[minIndex];
            Array[minIndex] = Array[i];
            Array[i] = temp;
        }
    }

    static void BubbleSort<T>(T[] Array) where T : IComparable<T>
    {
        bool HasAnythingChanged = true;

        while (HasAnythingChanged == true)
        {
            HasAnythingChanged = false;
            int n = Array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (Array[i].CompareTo(Array[i + 1]) > 0)
                {
                    T temp = Array[i];

                    Array[i] = Array[i + 1];
                    Array[i + 1] = temp;
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
        IntArray = new int[Lines.Length];

        // Parse each line as an integer and store it in the array
        for (int i = 0; i < Lines.Length; i++)
        {
            IntArray[i] = int.Parse(Lines[i]);
        }
    }

    static void ReadStringsToArray(int Amount)
    {
        StringArray = File.ReadAllLines("Words.txt").Take(Amount).ToArray();    
    }

    static bool CheckArray<T>(T[] Array) where T : IComparable<T>
    {
        T LastIndex = Array[0];
        for (int i = 0; i < Array.Length; i++)
        {
            if (LastIndex.CompareTo(Array[i]) <= 0)
            {
                LastIndex = Array[i];
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
        Stopwatch Stopwatch = new Stopwatch();
        int j = 1;


        Console.WriteLine("SelectionSort Integers");
       // SelectionSort
        for (int i = 0; i < 5; i++)
        {

            GenerateNumbers(j * 8000);
            ReadNumbersToArray();
            Stopwatch.Restart();
            SelectionSort(IntArray);
            Stopwatch.Stop();

            if (CheckArray(IntArray) == false)
            {
                Console.WriteLine("Sorted Incorrectly");
            }

            Console.WriteLine("{0} integers Elapsed time: {1}", j * 8000, Stopwatch.Elapsed);
            j *= 2;
        }


        Console.WriteLine();
        Console.WriteLine("BubbleSort  Integers");
        j = 1;
        //BubbleSort
        for (int i = 0; i < 5; i++)
        {

            GenerateNumbers(j * 8000);
            ReadNumbersToArray();
            Stopwatch.Restart();
            BubbleSort(IntArray);
            Stopwatch.Stop();

            if (CheckArray(IntArray) == false)
            {
                Console.WriteLine("Sorted Incorrectly");
            }

            Console.WriteLine("{0} integers Elapsed time: {1}", j * 8000, Stopwatch.Elapsed);
            j *= 2;
        }

        Console.WriteLine();
        Console.WriteLine("InsertionSort  Integers");
        j = 1;
        //InsertionSort
        for (int i = 0; i < 5; i++)
        {

            GenerateNumbers(j * 8000);
            ReadNumbersToArray();
            Stopwatch.Restart();
            InsertionSort(IntArray);
            Stopwatch.Stop();

            if (CheckArray(IntArray) == false)
            {
                Console.WriteLine("Sorted Incorrectly");
            }

            Console.WriteLine("{0} integers Elapsed time: {1}", j * 8000, Stopwatch.Elapsed);
            j *= 2;
        }


        Console.WriteLine();
        Console.WriteLine("InsertionSort  Strings");
    
        //InsertionSort
        for (int i = 0; i < 5; i++)
        {

            ReadStringsToArray((i+1)*4000);
            Stopwatch.Restart();

            InsertionSort(StringArray);
            Stopwatch.Stop();

            if (CheckArray(StringArray) == false)
            {
                Console.WriteLine("Sorted Incorrectly");
            }

            Console.WriteLine("{0} Strings Elapsed time: {1}", (i + 1) * 4000, Stopwatch.Elapsed); 
        }

        Console.WriteLine();
        Console.WriteLine("SelectionSort  Strings");

        //SelectionSort
        for (int i = 0; i < 5; i++)
        {

            ReadStringsToArray((i + 1) * 4000);
            Stopwatch.Restart();

            SelectionSort(StringArray);
            Stopwatch.Stop();

            if (CheckArray(StringArray) == false)
            {
                Console.WriteLine("Sorted Incorrectly");
            }

            Console.WriteLine("{0} Strings Elapsed time: {1}", (i + 1) * 4000, Stopwatch.Elapsed);
        }

        Console.WriteLine();
        Console.WriteLine("BubbleSort  Strings");

        //BubbleSort
        for (int i = 0; i < 5; i++)
        {

            ReadStringsToArray((i + 1) * 4000);
            Stopwatch.Restart();

            BubbleSort(StringArray);
            Stopwatch.Stop();

            if (CheckArray(StringArray) == false)
            {
                Console.WriteLine("Sorted Incorrectly");
            }

            Console.WriteLine("{0} Strings Elapsed time: {1}", (i + 1) * 4000, Stopwatch.Elapsed);
        }

    }
}