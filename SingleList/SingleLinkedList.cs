using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _ListException;

namespace _SingleList
{
    public class SingleLinkedList : IEnumerable
    {
        private class Item
        {
            public Item(object info, Item next = null)
            {
                Info = info;
                Next = next;
            }

            public object Info { get; set; }

            public Item Next { get; set; }
        }

        private Item _first = null;

        public void AddToBegin(object data)
        {
            Item newItem = new Item(data);    // (1)
             
            newItem.Next = _first;    // (2)

            _first = newItem;    // (3)
        }

        public void AddToEnd(object data)
        {
            if (Empty)
            {
                _first = new Item(data);
                
                return;
            }

            Item current = _first;
            Item newItem = new Item(data);

            if (current.Next == null)
            {
                current.Next = newItem;
                
                return;
            }

            while(current.Next.Next != null)
            {
                current = current.Next;
            }

            current.Next.Next = newItem;
        }

        public object GetFromBegin()
        { 
            if (Empty)
            {
                throw new EmptyListExceptions("List is empty");
            }

            object res = _first.Info;

            _first = _first.Next;

            return res;
        }

        public object GetFromEnd()
        {
            if (Empty)
            {
                throw new EmptyListExceptions("List is empty");
            }

            if (_first.Next == null)    // один елемент в списку
            {
                object result = _first.Info;    // (1)
                _first = null;               // (2)

                return result;
            }

            Item current = _first;    // (3)

            while (current.Next.Next != null)
            {
                current = current.Next;    // (4)
            }

            object result2 = current.Next.Info;    // (5)
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new SingleLinkedListEnumerator(this);
        }

        private struct SingleLinkedListEnumerator : IEnumerator
        {
            private SingleLinkedList _list;
            private int _position;
            private Item _current;

            public SingleLinkedListEnumerator (SingleLinkedList list)
            {
                _list = list;
                _position = -1;
                _current = _list._first;
            }

            public object Current => _current.Info;

            public bool MoveNext()
            {
                if (_position == -1)
                {
                    _position++;
                    
                    return true;
                }

                if (_current.Next != null)
                {
                    _current = _current.Next;

                    return true;
                }

                return false;
            }

            public void Reset()
            {
                _current = _list._first;
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
    }
}
