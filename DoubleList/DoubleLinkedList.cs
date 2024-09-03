using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoubleList
{
    // !!! *** Виконати сортування значень двозв'язкового списку (!!! переміщуємо посилання !!!)
    public class DoubleLinkedList: IEnumerable
    {
        private Item _first = null;
        private Item _last = null;

        public void AddToBegin(int data)
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
            // HW
        }

        public int GetFromBegin()
        {
            // HW
            return 0;
        }

        public int GetFromEnd()
        {
            // ToDo: !!!
            if (Empty)
            {
                throw new InvalidOperationException("List is emplty!");    // має кидатися власний виняток (HW!)
            }

            int result2 = _last.Info;
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


        private class Item
        {
            public Item(int info, Item next = null)
            {
                Info = info;
                Next = next;
                Prev = null;
            }

            public int Info { get; set; }    // інформаційна частина

            public Item Next { get; set; }    // посилання на наступний елемент списку
            public Item Prev { get; set; }    // посилання на попередній елемент списку
        }
    }
}
