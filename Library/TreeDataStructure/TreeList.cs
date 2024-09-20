using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Text;

namespace TreeDataStructure;

public class TreeList<TKey, TValue> : IDictionary<TKey, TValue>
{
    private class Node
    {
        public TKey key;
        public TValue data;
        public Node left;
        public Node right;
        public Node parent;
        public bool isActive;

        public Node(TKey Key, TValue Data, Node Left = null, Node Right = null, Node Parent = null)
        {
            key = Key;
            data = Data;
            left = Left;
            right = Right;
            parent = Parent;
            isActive = true;
        }

        public Node(Node node) : this(node.key, node.data, node.left, node.right, node.parent)
        {}
    }

    private Node _root = null;

    public ICollection<TKey> Keys => new TreeListKeysICollection(this);

    private struct TreeListKeysICollection : ICollection<TKey>
    {
        private TreeList<TKey, TValue> _source;
        private Node _current;
        private bool _isFirstIter;

        public TreeListKeysICollection(TreeList<TKey, TValue> source)
        {
            _source = source;
            _current = _source._root;
            _isFirstIter = true;
        }

        public int Count => _source.Count;

        public bool IsSynchronized => false;

        public object SyncRoot => throw new NotImplementedException();

        public bool IsReadOnly => false;

        public void Add(TKey item)
        {
            _source.Add(ref _source._root, item);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(TKey item)
        {
            return _source.ContainsKey(item);
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
            return new TreeListEnumerator(_source, TreeListEnumerator.Keys);
        }

        public bool MoveNext()
        {
            if (_source.MoveNextEnum(ref _current, _source._root, ref _isFirstIter))
                {
                    _isFirstIter = false;
                    return true;
                }

            return false;
        }
        
        public bool Remove(TKey item)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            _current = _source._root;
        }

        IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
        {
            return new TreeListKeyICollectionEnumGen(_source);
        }

        private struct TreeListKeyICollectionEnumGen : IEnumerator<TKey>
        {
            private TreeList<TKey, TValue> _source;
            private Node _current;
            private bool _isFirstIter;

            public TreeListKeyICollectionEnumGen(TreeList<TKey, TValue> source)
            {
                _source = source;
                _current = _source._root;
                _isFirstIter = true;
            }

            public TKey Current => _current.key;

            object IEnumerator.Current => new TreeListEnumerator(_source, TreeListEnumerator.Keys);

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            public bool MoveNext()
            {
                if (_source.MoveNextEnum(ref _current, _source._root, ref _isFirstIter))
                {
                    _isFirstIter = false;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                _current = _source._root;
            }
        }
    }

    public ICollection<TValue> Values => new TreeListValueICollection(this);

    private struct TreeListValueICollection : ICollection<TValue>
    {
        private TreeList<TKey, TValue> _source;
        private Node _current;
        private bool _isFirstIter;

        public TreeListValueICollection(TreeList<TKey, TValue> source)
        {
            _source = source;
            _current = _source._root;
            _isFirstIter = true;
        }

        public int Count => _source.Count;

        public bool IsSynchronized => false;

        public object SyncRoot => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(TValue item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(TValue item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(TValue[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            return new TreeListEnumerator(_source, TreeListEnumerator.Values);
        }

        public bool MoveNext()
        {
            if (_source.MoveNextEnum(ref _current, _source._root, ref _isFirstIter))
                {
                    _isFirstIter = false;
                    return true;
                }

            return false;
        }

        public bool Remove(TValue item)
        {
            throw new NotImplementedException();
        }

        public void Reset()
            {
                _current = _source._root;
            }

        IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
        {
            return new TreeListValueICollectionEnumGen(_source);
        }

        private struct TreeListValueICollectionEnumGen : IEnumerator<TValue>
        {
            private TreeList<TKey, TValue> _source;
            private Node _current;
            private bool _isFirstIter;

            public TreeListValueICollectionEnumGen(TreeList<TKey, TValue> source)
            {
                _source = source;
                _current = _source._root;
                _isFirstIter = true;
            }

            public TValue Current => _current.data;

            object IEnumerator.Current => new TreeListEnumerator(_source, TreeListEnumerator.Values);

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            public bool MoveNext()
            {
                if (_source.MoveNextEnum(ref _current, _source._root, ref _isFirstIter))
                {
                    _isFirstIter = false;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                _current = _source._root;
            }
        }
    }

    private struct TreeListValueICollectionEnumGen : IEnumerator<TValue>
    {
        private TreeList<TKey, TValue> _source;
        private Node _current;
        private bool _isFirstIter;

        public TreeListValueICollectionEnumGen(TreeList<TKey, TValue> source)
        {
            _source = source;
            _current = _source._root;
            _isFirstIter = true;
        }

        public TValue Current => _current.data;

        object IEnumerator.Current => new TreeListEnumerator(_source, TreeListEnumerator.Values);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool MoveNext()
        {
            if (_source.MoveNextEnum(ref _current, _source._root, ref _isFirstIter))
            {
                _isFirstIter = false;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _current = _source._root;
        }
    }

    public int Count
    {
        get
            {
                int index = 0;

                bool isRunning = true;
                bool _isFirstIter = true;

                Node current = _root;

                do
                {
                    if (current == null)
                    {
                        isRunning = false;
                    }
                    else if (current == _root && _isFirstIter)
                    {
                        index++;
                        _isFirstIter = false;
                    }
                    else if (current.left != null && current.left.isActive)
                    {
                        current = current.left;
                        index++;
                    }
                    else if (current.right != null && current.right.isActive)
                    {
                        current = current.right;
                        index++;
                    }
                    else
                    {
                        Node last = null;
                        do
                        {
                            if (current?.parent == null && last !=_root.right)
                            {
                                break;
                            }
                            else if (current?.parent == null && last ==_root.right)
                            {
                                isRunning = false;
                                break;
                            }
                            else if (last != null && !(last?.isActive ?? false))
                            {
                                isRunning = false;
                                break;
                            }
    
                            last = current;
                            current = current.parent;
                        } while (current?.right == null || current.right == last);
    
                        if (isRunning && current.right.isActive)
                        {
                            current = current.right;
                            index++;
                        }
                        else
                        {
                            isRunning = false;
                        }
                        
                    }
                } while (isRunning);

                return index;
            }
    }

    public bool IsReadOnly => false;

    public TValue this[TKey key] 
    { 
        get
        {
            Node res = GetNodeByKey(_root, key);

            if (res != null)
            {
                return res.data;
            }

            return default;
        }
        set
        {
            Node res = GetNodeByKey(_root, key);

            if (res != null)
            {
                res.data = value;
            }

            return;
        }
    } 

    private void Add(ref Node root, TKey key, TValue data, Node parent = null)
    {
        if (root == null || !root.isActive)
        { 
            Node newNode = new Node(key, data);
            newNode.parent = parent;
            root = newNode;

            return;
        }

        if (Compare(key, root.key) > 0 && root.isActive)
        {
            Add(ref root.left, key, data, root);
        }
        else
        {
            Add(ref root.right, key, data, root);
        }
    }

    private void Add(ref Node root, TKey key, Node parent = null)
    {
        if (root == null || !root.isActive)
        { 
            Node newNode = new Node(key, default);
            newNode.parent = parent;
            root = newNode;

            return;
        }

        if (Compare(key, root.key) > 0 && root.isActive)
        {
            Add(ref root.left, key, root);
        }
        else
        {
            Add(ref root.right, key, root);
        }
    }

    private Node GetNodeByKey(Node root, TKey key)
    {
        if (root == null || !root.isActive)
        {
            return null;
        }

        if (Compare(key, root.key) == 0)
        {
            return root;
        }

        if (Compare(key, root.key) > 0 && root.isActive)
        {
            return GetNodeByKey(root.left, key);
        }
        else
        {
            return GetNodeByKey(root.right, key);
        }
    }

    private Node SetDataByKey(TKey key, TValue newData)
    {
        if (_root == null || !_root.isActive)
        {
            return null;
        }

        if (Compare(key, _root.key) == 0)
        {
            _root.data = newData;
            return _root;
        }

        if (Compare(key, _root.key) > 0)
        {
            return GetNodeByKey(_root.left, key);
        }
        else
        {
            return GetNodeByKey(_root.right, key);
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder(1024);
        ToString(result, _root);
        return result.ToString();
    }

    private static void ToString(StringBuilder result, Node root, int level = 0)
    {
        if (root == null || !root.isActive)
        {
            return;
        }
        ToString(result, root.left, level + 1);
        for (int i = 0; i < level; i++)
        {
            result.Append('\t');
        }
        result.AppendFormat("{0} ({1}) ", root.key, root.data);
        result.AppendLine();
        ToString(result, root.right, level + 1);
    }

    public int Compare(object? x, object? y)
    {
        string strFirst = x.ToString();
        string strSecond = y.ToString();

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

    private bool MoveNextEnum(ref Node _current, Node root, ref bool isFirstIter)
    {
        if (_current == root && isFirstIter)
        {
            // _current = _current?.left ?? _current?.right ?? null;
            return true;
        }

        if (_current == null)
        {
            return false;
        }
        else if (_current.left != null && _current.left.isActive)
        {
            _current = _current.left;
        }
        else if (_current.right != null && _current.right.isActive)
        {
            _current = _current.right;
        }
        else
        {
            Node last;
            do
            {
                if (_current.parent == null)
                {
                    return false;
                }
                last = _current;
                _current = _current.parent;
            } while (_current.right == null || _current.right == last);
            _current = _current.right;
        }

        return true;
    }
    

    public void Add(TKey key, TValue value)
    {
        Add(ref _root, key, value);
    }

    public bool ContainsKey(TKey key)
    {
        Node res = GetNodeByKey(_root, key);

        if (res == null || !res.isActive)
        {
            return false;
        }

        return true;
    }

    public bool Remove(TKey key)
    {
        Node current = GetNodeByKey(_root, key);
        current.isActive = false;
        Node init = current;
        bool isRunning = true;
        bool res = false;

        do
        {
            if (current == null)
            {
                res = false;
                isRunning = false;
            }
            else if (current.left != null)
            {
                current = current.left;
                current.isActive = false;
                res = true;
            }
            else if (current.right != null)
            {
                current = current.right;
                current.isActive = false;
                res = true;
            }
            else
            {
                Node last = null;
                do
                {
                    if (current == init && last !=init.right && current.isActive == false)
                    {
                        break;
                    }
                    else if (current == init && last ==init.right && current.isActive == false)
                    {
                        isRunning = false;
                        break;
                    }

                    last = current;
                    current = current.parent;
                } while (current?.right == null || current.right == last);

                if (isRunning)
                {
                    current = current.right;
                    current.isActive = false;
                    res = true;
                }
                
            }
        } while (isRunning);

        return res;
    }

    public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
    {
        Node res = GetNodeByKey(_root, key);

        if (res == null || !res.isActive)
        {
            value = default;

            return false;
        }

        value = res.data;

        return true;
    }

    public void Add(KeyValuePair<TKey, TValue> item)
    {
        Add(ref _root, item.Key, item.Value);
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(KeyValuePair<TKey, TValue> item)
    {
        Node root = _root;
        Node res = GetNodeByKey(root, item.Key);

        if (res != null)
        {
            return true;
        }

        return false;
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
        return Remove(item.Key);
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        return new TreeListEnumeratorGeneric(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new TreeListEnumerator(this, TreeListEnumerator.DictEntry);
    }

    #region TreeListEnumerator

        private struct TreeListEnumerator : IEnumerator, IDictionaryEnumerator
        {
            private TreeList<TKey, TValue> _source;
            private Node _current;
            private int _collectionId;
            private bool _isFirstIter;

            internal const int Keys = 0;
            internal const int Values = 1;
            internal const int DictEntry = 2;

            public TreeListEnumerator(TreeList<TKey, TValue> source, int collectionId)
            {
                _source = source;
                _current = _source._root;
                _collectionId = collectionId;
                _isFirstIter = true;
            }

            public object Current
            {
                get
                {
                    if (_collectionId == 0)
                    {
                        return _current.key;
                    }
                    if (_collectionId == 1)
                    {
                        return _current.data;
                    }
                    return new DictionaryEntry(_current.key, _current.data);
                }
            }

            public DictionaryEntry Entry
            {
                get
                {
                    if (_current == null)
                    {
                        throw new InvalidOperationException();
                    }
                    return new DictionaryEntry(_current.key, _current.data);
                }
            }
    
            public object Key => _current.key;
    
            public object? Value => _current.data;
    
            public bool MoveNext()
            {         
                if (_source.MoveNextEnum(ref _current, _source._root, ref _isFirstIter))
                {
                    _isFirstIter = false;
                    return true;
                }

                return false;
            }
    
            public void Reset()
            {
                _current = _source._root;
            }
        }


    private struct TreeListEnumeratorGeneric : IEnumerator<KeyValuePair<TKey, TValue>>
    {
        private TreeList<TKey, TValue> _source;
        private Node _current;
        private KeyValuePair<TKey, TValue> _currentKeyV;
        private bool _isFirstIter;

        public TreeListEnumeratorGeneric(TreeList<TKey, TValue> source)
        {
            _source = source;
            _current = _source._root;
            _currentKeyV = new KeyValuePair<TKey, TValue>(_current.key, _current.data);
            _isFirstIter = true;
        }

        public KeyValuePair<TKey, TValue> Current => _currentKeyV;

        object IEnumerator.Current => new TreeListEnumerator(_source, TreeListEnumerator.DictEntry);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool MoveNext()
        {
            if (_source.MoveNextEnum(ref _current, _source._root, ref _isFirstIter))
                {
                    _isFirstIter = false;
                    _currentKeyV = new KeyValuePair<TKey, TValue>(_current.key, _current.data);
                    return true;
                }
            
            _currentKeyV = new KeyValuePair<TKey, TValue>(_current.key, _current.data);

            return false;
        }

        public void Reset()
        {
            _current = _source._root;
            _currentKeyV = new KeyValuePair<TKey, TValue>(_current.key, _current.data);
        }
    }
    #endregion  
}
