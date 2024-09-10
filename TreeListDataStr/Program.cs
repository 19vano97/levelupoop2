using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeDataStructure;

namespace _TreeListDataStr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeList t1 = new TreeList();

            t1.Add(20, "Mikola");
            t1.Add(-3, "Alex");
            t1.Add(23, "Ivan");
            t1.Add(-100, "Dmytro");
            t1.Add(100, "Oleksandr");
            t1.Add(-1000, "Petro");
            t1.Add(-50, "Test");
            t1.Add(-75, "Test3");
            t1.Add(-200, "Test1");
            t1.Add(-85, "Test4");
            //t1.Add(500);
            //t1.Add(-500);
            //t1.Add(22);
            //t1.Add(4);
            //t1.Add(-2000);

            t1.Remove(-200);

            System.Console.WriteLine(t1.Count);

            // Console.ReadKey();

            // //#if DEBUG
            // //            t1.Print();
            // //#endif
            // //Console.WriteLine(t1);

            System.Console.WriteLine("foreach");

            int i = 0;

            foreach (object item in t1)
            {
                System.Console.WriteLine(item);
                // i++;
                // System.Console.WriteLine(i);
            }

            foreach (var item in t1.Values)
            {
                System.Console.WriteLine(item);
            }


            // #region Search by key

            // int k = -1000;

            // if (t1.TryGetValue(k, out object info))
            // {
            //     Console.WriteLine($"[{k}] = {info}");
            // }
            // else
            // {
            //     Console.WriteLine("Value with {0} key not found!", k);
            // }


            // #endregion
        }
    }
}
