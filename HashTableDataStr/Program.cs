using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeStamp;

namespace _HashTableDataStr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringHashTable ht = new StringHashTable();


            ht.Add("test", 200);
            ht.Add("abc", 333);
            ht.Add("klm", 222);
            ht.Add("bca", 765);
            ht.Add("bca", 768);

            {
                int res;
                string key1 = "bca";
                if (ht.TryGetValue(key1, out res))
                {
                    Console.WriteLine($"ht[{key1}] = {res}");
                }
                else
                {
                    Console.WriteLine($"key {key1} not found");
                }
            }

            {
                int res;
                string key1 = "bca";
                if (ht.TryGetValue(key1, out res))
                {
                    Console.WriteLine($"ht[{key1}] = {res}");
                }
                else
                {
                    Console.WriteLine($"key {key1} not found");
                }
            }

        
            Console.ReadKey();
        }
    }
}
