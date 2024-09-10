using System;
using System.Collections;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _ListException;

namespace _DoubleList
{
    // !!! *** Виконати сортування значень двозв'язкового списку (!!! переміщуємо посилання !!!)
    public class DoubleLinkedList: IEnumerable, IComparer
    {
        private Item _first = null;
        private Item _last = null;

        private class Item
        {
            public Item(object info, Item next = null, Item prev = null)
            {
                Info = info;
                Next = next;
                Prev = prev;
            }

            public Item(Item item) : this(item.Info, item.Next, item.Prev)
            {}

            public object Info { get; set; }    // інформаційна частина
            public Item Next { get; set; }    // посилання на наступний елемент списку
            public Item Prev { get; set; }    // посилання на попередній елемент списку
        }

        public void AddToBegin(object data)
        {
            Item newItem = new Item(data);    // (1)

            newItem.Next = _first;    // (2)

            if (_first != null)
            {
                _first.Prev = newItem;
            }

            _first = newItem;    // (3)

            if (_last == null)
            {
                _last = _first;
            }
        }

        public void AddToEnd(int data)
        {
            if (_first == null)
            {
                _first = new Item(data);
                _last = _first;

                return;
            }

            Item newItem = new Item(data);

            newItem.Prev = _last;
            _last.Next = newItem;
            _last = newItem;
        }

        public object GetFromBegin()
        {
            if (_first == null)
            {
                throw new EmptyListExceptions("List is empty!");
            }

            object res = _first.Info;

            _first = _first.Next;
            _first.Prev = null;

            return res;
        }

        public object GetFromEnd()
        {
            if (Empty)
            {
                throw new EmptyListExceptions("List is emplty!");
            }

            object result2 = _last.Info;
            // 1) видалення останнього емементу зі списку
            if (_last.Prev == null)
            {
                _last = null;
                _first = null;
            }
            else   // 2)
            {
                _last = _last.Prev;
                _last.Next = null;
            }

            return result2;
        }

        #region MyRegion

        public IEnumerator GetEnumerator()
        {
            return new DoubleLinkedListIterator(this);
        }

        private struct DoubleLinkedListIterator: IEnumerator
        {
            private DoubleLinkedList _source;
            private bool _lasrItem;
            private Item _curent;

            public DoubleLinkedListIterator(DoubleLinkedList source)
            {
                _source = source;
                _lasrItem = true;
                _curent = _source._last;
            }

            public object Current
            {
                get
                {
                    return _curent.Info;
                }
            }

            public bool MoveNext()
            {
                if (_lasrItem)
                {
                    _curent = _source._last;
                    _lasrItem = false;
                }
                else
                {
                    _curent = _curent.Prev;
                }

                return _curent != null;
            }

            public void Reset()
            {
                _lasrItem = true;
                _curent = _source._last;
            }
        }

        #endregion


        public bool Empty
        {
            get
            {
                return _first == null;
            }
        }

        public void Sort()
        {
            bool swapped;
            Item current;

            do
            {
                swapped = false;
                current = _first;

                while (current != null && current.Next != null)
                {
                    Item next = current.Next;

                    //ICompare or ICompareable
                    int objectCompareIndex = Compare(current.Info, next.Info);

                    if (objectCompareIndex == -1)
                    {
                        Swap(current, next);
                        swapped = true;
                    }

                    current = current.Next;
                }
            } while (swapped);
        }

        private void Swap(Item first, Item second)
        {
            if (first.Prev != null)
            {
                first.Prev.Next = second;
            }
            else
            {
                _first = second;
            }

            if (second.Next != null)
            {
                second.Next.Prev = first;
            }

            Item tempPrev = first.Prev;
            Item tempNext = second.Next;

            first.Next = tempNext;
            first.Prev = second;

            second.Prev = tempPrev;
            second.Next = first;
        }

        public int Compare(object? x, object? y)
        {
            Item first = x as Item;
            Item second = y as Item;

            string strFirst = (string)first.Info;
            string strSecond = (string)second.Info;

            if (int.TryParse(strFirst, out int valueFirst) && int.TryParse(strSecond, out int valueSecond))
            {
                if (valueFirst < valueSecond)
                {
                    return 1;
                }

                if (valueFirst > valueSecond)
                {
                    return -1;
                }

                return 0;
            }

            return strFirst.CompareTo(strSecond);
        }
    }
}
