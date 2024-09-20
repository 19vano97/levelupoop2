using System;

namespace GenericsLesson;

public class QueueGeneric<T>
{
    private class Item
    {
        public Item(T info, Item next = null)
        {
            Info = info;
            Next = next;
        }

        public T Info { get; set; }
        public Item Next { get; set; }
    }

    private Item _head = null;
    private Item _tail = null;

    public void EnQueue(T data)
    {
        if (_head == null)
        {
            _tail = _head = new Item(data);
            return;
        }

       _tail.Next = new Item(data);
       _tail = _tail.Next; 
    }

    public bool Empty => _head == null || _tail == null;

    public T DeQueue()
    {
        if (_head == null)
        {
            // return null;
            throw new InvalidOperationException();
        }

        T res = _head.Info;

        _head = _head.Next;

        if (_head == null)
        {
            _tail = null;
        }

        return res;
    }
}
