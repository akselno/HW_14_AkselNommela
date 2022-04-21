using System;
namespace EX_01
{
    public class Diamond
    {
        public Diamond()
        {
        }

        public void DrawDiamond(int input)
        {
            int i;
            int j;
            for (i = 0; i <= input / 2 + 1; i++)
            {
                for (j = 1; j <= input - i; j++)
                {
                    Console.Write(" ");
                }
                for (j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }

            for (i = input / 2; i >= 1; i--)
            {
                for (j = 1; j <= input - i; j++)
                {
                    Console.Write(" ");
                }
                for (j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }

        }
    }
}
