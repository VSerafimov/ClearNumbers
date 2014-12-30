using System;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string lineToPrint;

            for (int i = 1; i <= 100; i++)
            {
                lineToPrint = i.ToString();
                if (i % 3 == 0)
                {
                    lineToPrint += " fizz";
                }

                if (i % 5 == 0)
                {
                    lineToPrint += " buzz";
                }

                Console.Write(lineToPrint);
            }
            Console.ReadLine();
        }
    }
}
