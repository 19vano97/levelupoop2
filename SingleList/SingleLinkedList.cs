using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SingleList
{

    // HW*: перевести інформаційну частину на використання boxing / unboxing
    public class SingleLinkedList
    {
        private Item _first = null;

        public void AddToBegin(int data)
        {
            Item newItem = new Item(data);    // (1)
             
            newItem.Next = _first;    // (2)

            _first = newItem;    // (3)
        }

        public void AddToEnd(int data)
        {
            // HW
        }

        public int GetFromBegin()
        { 
            // HW
            return 0;
        }

        public int GetFromEnd()
        {
            if (Empty)
            {
                throw new InvalidOperationException("List is emplty!");    // має кидатися власний виняток (HW!)
            }

            if (_first.Next == null)    // один елемент в списку
            {
                int result = _first.Info;    // (1)
                _first = null;               // (2)

                return result;
            }


            Item current = _first;    // (3)

            while (current.Next.Next != null)
            {
                current = current.Next;    // (4)
            }

            int result2 = current.Next.Info;    // (5)
            current.Next = null;    // (6)

            return result2;
        }

        public bool Empty
        {
            get
            {
                return _first == null;
            }
        }

#if DEBUG

        public void Print()
        {
            Item current = _first;

            while (current != null) 
            {
                Console.Write("{0} ", current.Info);

                current = current.Next;
            }
            Console.WriteLine();
        }

#endif


        // окремий елемент списку
        private class Item
        {
            public Item(int info, Item next = null)
            {
                Info = info;
                Next = next;
            }

            public int Info { get; set; }    // інформаційна частина

            public Item Next { get; set; }    // посилання на наступний елемент списку
        }
    }
}
