using System;

namespace EX_3_Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            //creating a random variable
            int[] array = new int[10];
            //creating an int type array with 10 items
            for (int i = 0; i < 10; i++)
            {
                //creating a for loop
                array[i] = rnd.Next(0, 1001);
                //creating 10 random numbers for the array
            }
            Console.WriteLine("Starting sorting the numbers: ");
            Console.WriteLine("");

            for (int i = 0; i < 10; i++)
            {
                //creating a for loop
                int numberInArray = array[i];
                //creating an int variable for a number at index i in the array
                int j = i - 1;
                //creating new int variable j, showing how
                //many times i for loop has run, subtract 1

                while (j >= 0 && array[j] > numberInArray)
                {
                    //comparing elements in an array
                    array[j + 1] = array[j];
                    //changing the number indexes (places in the array)
                    j = j - 1;
                    //subtract 1 from j
                }

                array[j + 1] = numberInArray;
                //updating the rest of the array

                for (int k = 0; k < 10; k++)
                {
                    Console.Write(array[k] + " ");
                }
                //printing the array
                Console.WriteLine("");
                //linebreak
            }
        }
    }
}
