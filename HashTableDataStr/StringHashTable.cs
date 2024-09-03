using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _HashTableDataStr
{
    // 0.68!!!   :    2 / 3
    public class StringHashTable // HW! : IDictionary
    {
        public const int DEFAUL_CAPACITY = 100;

        // string --> int
        private string[] _keys;
        private int[] _values;

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
    }
}
