using System;
using System.Collections.Generic;
using System.Threading;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create

            #region Arrays
            // Create an integer Array of size 50
            int[] array = new int[50];

            //Create a method to populate the number array with 50 random numbers that are between 0 and 50
            Populater(array);

            //Print the first number of the array
            Console.WriteLine(array[0]);

            //Print the last number of the array
            Console.WriteLine(array[array.Length - 1]);

            Console.WriteLine("All Numbers Original");
            //Use this method to print out your numbers from arrays or lists
            //NumberPrinter();
            NumberPrinter(array);
            Console.WriteLine("-------------------");

            //Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*     Hint: Array._____(); Create a custom method     */
            Array.Reverse(array);

            Console.WriteLine("All Numbers Reversed:");

            NumberPrinter(array);

            Console.WriteLine("---------REVERSE CUSTOM------------");

            ReverseArray(array);
            NumberPrinter(array);

            Console.WriteLine("-------------------");

            //Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(array);
            NumberPrinter(array);

            Console.WriteLine("-------------------");

            //Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");

            Array.Sort(array);
            NumberPrinter(array);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //Create an integer List
            List<int> numList = new List<int>();


            //Print the capacity of the list to the console
            Console.WriteLine(numList.Count);

            //Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(numList);

            //Print the new capacity
            Console.WriteLine(numList.Count);


            Console.WriteLine("---------------------");

            //Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            Console.WriteLine("What number will you search for in the number list?");
            int searchNum;

            while(!int.TryParse(Console.ReadLine(), out searchNum))
            {
                Console.WriteLine("Please enter a valid integer!");
            }

            NumberChecker(numList, searchNum);
            Thread.Sleep(1000);


            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //Print all numbers in the list
            //NumberPrinter();
            NumberPrinter(numList);
            Console.WriteLine("-------------------");

            //Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            OddKiller(numList);
            NumberPrinter(numList);

            Console.WriteLine("------------------");

            //Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            numList.Sort();
            NumberPrinter(numList);
            
            Console.WriteLine("------------------");

            //Convert the list to an array and store that into a variable
            int[] arrayFromList = numList.ToArray();

            //Clear the list
            numList.Clear();

            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0)
                {
                    numbers[i] = 0;
                }
            }
        }

        private static void OddKiller(List<int> numberList)
        {
            numberList.RemoveAll(t => t % 2 != 0);
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            bool check = false;
            foreach (int num in numberList)
            {
                if(num == searchNumber)
                {
                    Console.WriteLine($"Yes, {searchNumber} is in the list!");
                    check = true;
                    break;
                }
            }

            if (check == false)
            {
                Console.WriteLine($"No, {searchNumber} is not in the list!");
            }
        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();
            for (int i = 0; i < 50; i++)
            {
                numberList.Add(rng.Next(0, 50));
            }

        }

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();

            for(int i = 0; i < numbers.Length; i++)
            {
               numbers[i] = rng.Next(0, 50);
            }
        }        

        private static void ReverseArray(int[] array)
        {
            int arraySize = array.Length;
            int[] tempArray = new int[arraySize];

            for (int i = arraySize; i > 0; i--)
            {
                tempArray[Math.Abs(i - arraySize)] = array[i - 1];
            }

            for (int i = 0; i < arraySize; i++)
            {
                array[i] = tempArray[i];
            }
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
