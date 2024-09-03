using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoubleList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList lst1 = new DoubleLinkedList();

            Console.Write("lst1: ");

            lst1.AddToBegin(321);
            lst1.AddToBegin(-21);
            lst1.AddToBegin(12214);

            foreach (int item in lst1)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            while (!lst1.Empty)
            {
                int n = lst1.GetFromEnd();

                Console.Write("({0}), ", n);

                foreach (int item in lst1)
                {
                    Console.Write("{0} ", item);
                }
                Console.WriteLine();
            }

            Console.Write("Press any key...");
            Console.ReadKey();
        }
    }
}
