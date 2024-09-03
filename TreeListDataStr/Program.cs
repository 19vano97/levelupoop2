using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _TreeListDataStr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree t1 = new Tree();

            t1.Add(20, "Mikola");
            t1.Add(-3, "Alex");
            t1.Add(23, "Ivan");
            t1.Add(-100, "Dmytro");
            t1.Add(100, "Oleksandr");
            t1.Add(-1000, "Petro");
            //t1.Add(500);
            //t1.Add(-500);
            //t1.Add(22);
            //t1.Add(4);
            //t1.Add(-2000);

            //#if DEBUG
            //            t1.Print();
            //#endif
            Console.WriteLine(t1);


            #region Search by key

            int k = -1000;

            if (t1.TryGetValue(k, out string info))
            {
                Console.WriteLine($"[{k}] = {info}");
            }
            else
            {
                Console.WriteLine("Value with {0} key not found!", k);
            }


            #endregion

            Console.ReadKey(); 
        }
    }
}
