using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciGen1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = 100;
            int[] fibonacci = new int[length];

            for (int i = 1; i < length; i++)
            {
                if (i == 1 || i == 2)
                {
                    fibonacci[i] = 1;
                }
                else
                {
                    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
                }
                Console.WriteLine(fibonacci[i]);
            }
            Console.ReadKey();
        }
    }
}
