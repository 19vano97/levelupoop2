using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SingleList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SingleLinkedList lst1 = new SingleLinkedList();

            Console.Write("lst1: ");

            lst1.AddToBegin(321);
            lst1.AddToBegin(-21);
            lst1.AddToBegin(12214);

#if DEBUG
            lst1.Print();
#endif

            while (!lst1.Empty)
            {
                int n = lst1.GetFromEnd();

                Console.Write("({0}), ", n);
#if DEBUG
                Console.Write("lst1: ");
                lst1.Print();
#endif
            }

            Console.Write("Press any key...");
            Console.ReadKey();
        }
    }
}
