using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeStamp;

namespace _HashTableDataStr
{
    // 0.68!!!   :    2 / 3
    public class StringHashTable : IDictionary
    {
        public const int DEFAUL_CAPACITY = 100;

        // string --> int
        private string[] _keys;
        private int[] _values;

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        public ICollection Keys => throw new NotImplementedException();

        public ICollection Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public object? this[object key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public StringHashTable(int capacity = DEFAUL_CAPACITY)
        {
            _keys = new string[capacity];
            _values = new int[capacity];
        }

        public int GetHash(string key)
        {
            if (key.Length < 4)
            {
                // throw 
            }

            GetTimestamp time = new GetTimestamp();

            return ((ushort)(key[0]) + (ushort)(key[1]) + (ushort)(key[2])) % _keys.Length; 
        }


        // hash function key ---> int (position)
        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

        public void Add(string key, int number)
        {
            int pos = GetHash(key);

            while (_keys[pos] != null)
            {
                pos++;
            }

            _keys[pos] = key;
            _values[pos] = number;
            // ???
        }

        public bool TryGetValue(string key, out int number)
        { 
            bool result = false;
            number = 0;

            int pos = GetHash(key);

            while (pos < _keys.Length && _keys[pos] != key)
            {
                pos++;
            }

            if (pos < _keys.Length && _keys[pos] != null)
            {
                number = _values[pos];
                result = true;
            }

            return result;
        }

        public void Add(object key, object? value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object key)
        {
            throw new NotImplementedException();
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(object key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
