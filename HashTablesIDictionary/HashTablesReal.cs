using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HashTablesIDictionary;

public class HashTablesReal<TKey, TValue> : IDictionary<TKey, TValue>
{
    private struct Bucket
    {
        public TKey _key;
        public TValue _value;
    }

    private Bucket[] _bucket = null;
    public int _count;

    public HashTablesReal()
    {
        
    }

    public ICollection<TKey> Keys => new KeyCollection(this);

    private struct KeyCollection : ICollection<TKey>
    {
        private HashTablesReal<TKey, TValue> _source;

        public KeyCollection(HashTablesReal<TKey, TValue> source)
        {
            _source = source;
        }

        public int Count => _source._count;

        public bool IsSynchronized => false;

        public object SyncRoot => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(TKey item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(TKey item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(TKey[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            return new HashTablesRealEnumerator(_source, HashTablesRealEnumerator.Keys);
        }

        public bool Remove(TKey item)
        {
            throw new NotImplementedException();
        }

        IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public ICollection<TValue> Values => throw new NotImplementedException();

    private struct ValueICollection : ICollection
    {
        private HashTablesReal<TKey, TValue> _source;

        public ValueICollection(HashTablesReal<TKey, TValue> source)
        {
            _source = source;
        }

        public int Count => _source._count;

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            return new HashTablesRealEnumerator(_source, HashTablesRealEnumerator.Values);
        }
    }

    public int Count => _count;

    public bool IsReadOnly => throw new NotImplementedException();

    public TValue this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Add(TKey key, TValue value)
    {
        throw new NotImplementedException();
    }

    public bool ContainsKey(TKey key)
    {
        throw new NotImplementedException();
    }

    public bool Remove(TKey key)
    {
        throw new NotImplementedException();
    }

    public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
    {
        throw new NotImplementedException();
    }

    public void Add(KeyValuePair<TKey, TValue> item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(KeyValuePair<TKey, TValue> item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new HashTablesRealEnumerator(this, HashTablesRealEnumerator.DictEntry);
    }

    private class HashTablesRealEnumerator : IDictionaryEnumerator, ICloneable
    {
        private HashTablesReal<TKey, TValue>? _source;
        private int _bucketCount;
        private TKey? _currentKey;
        private TValue? _currentValue;
        private bool _currentBool;
        private int _collectionId;

        //Dictionaty
        internal const int Keys = 0;
        internal const int Values = 1;
        internal const int DictEntry = 2;   //DictionaryEntry

        public HashTablesRealEnumerator(HashTablesReal<TKey, TValue> source, int collectionId)
        {
            _source = source;
            _collectionId = collectionId;
            _currentBool = false;
            _bucketCount = _source._bucket.Length;
        }

        public DictionaryEntry Entry
        {
            get
            {
                if (!_currentBool)
                {
                    throw new InvalidOperationException("_current is empty");
                }

                return new DictionaryEntry(_currentKey!, _currentValue);
            }
        }

        public object Key => _currentKey!;

        public object? Value => _currentValue;

        public object Current
        {
            get
            {
                if (_collectionId == Keys)
                {
                    return _currentKey!;
                }
                if (_collectionId == Values)
                {
                    return _currentValue!;
                }

                return new DictionaryEntry(_currentKey!, _currentValue);
            }
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            while (_bucketCount > 0)
            {
                _bucketCount--;
                object keyvalue = _source._bucket[_bucketCount]._key;

                if (keyvalue != null)
                {
                    _currentKey = (TKey)keyvalue;
                    _currentValue = _source._bucket[_bucketCount]._value;
                    _currentBool = true;

                    return _currentBool;
                }
            }

            _currentBool = false;

            return _currentBool;
        }

        public void Reset()
        {
            _bucketCount = _source._bucket.Length;
        }
    }
}
