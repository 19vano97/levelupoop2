using System.Collections;
using System.Data;
using System.Text;

namespace TreeDataStructure;

public class TreeList : IDictionary
{
    private class Node
    {
        public object key;
        public object data;
        public Node left;
        public Node right;
        public Node parent;
        public bool isActive;

        public Node(object Key, object Data, Node Left = null, Node Right = null, Node Parent = null)
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

    public void Add(object key, object data)
    {
        Add(ref _root, key, data);
    }

    private void Add(ref Node root, object key, object data, Node parent = null)
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

    public bool TryGetValue(object key, out object data)
    {
        Node res = GetNodeByKey(_root, key);

        if (res == null || !res.isActive)
        {
            data = null;

            return false;
        }

        data = res.data;

        return true;
    }

    private Node GetNodeByKey(Node root, object key)
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

    private Node SetDataByKey(object key, object newData)
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

    #region IDictionary

        public bool IsFixedSize => false;
    
        public bool IsReadOnly => false;
    
        public ICollection Keys
        {
            get
            {
                return new TreeListKeysICollection(this);
            }
        }

        private struct TreeListKeysICollection : ICollection
        {
            private TreeList _source;
            private Node _current;

            public TreeListKeysICollection(TreeList source)
            {
                _source = source;
                _current = _source._root;
            }

            public int Count => _source.Count;

            public bool IsSynchronized => false;

            public object SyncRoot => throw new NotImplementedException();

            public void CopyTo(Array array, int index)
            {
                throw new NotImplementedException();
            }

            public IEnumerator GetEnumerator()
            {
                yield return new TreeListKeysICollection(_source);
            }

            public object Current => _current.key;

            public bool MoveNext()
            {
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

            public void Reset()
            {
                _current = _source._root;
            }
        }
    
        public ICollection Values => new TreeListValueICollection(this);

        private struct TreeListValueICollection : ICollection
        {
            private TreeList _source;
            private Node _current;

            public TreeListValueICollection(TreeList source)
            {
                _source = source;
                _current = _source._root;
            }

            public int Count => _source.Count;

            public object Current => _current.data;

            public bool IsSynchronized => false;

            public object SyncRoot => throw new NotImplementedException();

            public void CopyTo(Array array, int index)
            {
                throw new NotImplementedException();
            }

            public IEnumerator GetEnumerator()
            {
                return new TreeListEnumerator(this);
            }

            public bool MoveNext()
            {
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

                Node current = _root;

                do
                {
                    if (current == null)
                    {
                        isRunning = false;
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

        public bool IsSynchronized => false;
    
        public object SyncRoot => throw new NotImplementedException();
    
        public object? this[object key] 
        { 
            get
            {
                if (TryGetValue(key, out object data))
                {
                    return  data;
                }

                return null;
            } 
            set
            {
                SetDataByKey(key, value);
            }
        }
    
        public void Clear()
        {
            throw new NotImplementedException();
        }
    
        public bool Contains(object key)
        {
            if (TryGetValue(key, out object data))
            {
                return true;
            }

            return false;
        }
    
        public IDictionaryEnumerator GetEnumerator()
        {
            return new TreeListEnumerator(this);
        }
    
        public void Remove(object key) 
        {
            Node current = GetNodeByKey(_root, key);
            current.isActive = false;
            Node init = current;

            bool isRunning = true;

            do
            {
                if (current == null)
                {
                    isRunning = false;
                }
                else if (current.left != null)
                {
                    current = current.left;
                    current.isActive = false;
                }
                else if (current.right != null)
                {
                    current = current.right;
                    current.isActive = false;
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
                    }
                    
                }
            } while (isRunning);

        }
    
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new TreeListEnumerator(this);
        }

        #region TreeListEnumerator

            private struct TreeListEnumerator : IEnumerator, IDictionaryEnumerator
            {
                private TreeList _source;
                private Node _current;


                public TreeListEnumerator(TreeList source)
                {
                    _source = source;
                    _current = _source._root;
                }

                public object Current => _current.data;

                public DictionaryEntry Entry => throw new NotImplementedException();
        
                public object Key => _current.key;
        
                public object? Value => _current.data;
        
                public bool MoveNext()
                {         
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
        
                public void Reset()
                {
                    _current = _source._root;
                }
            }

        #endregion  

    #endregion
}
