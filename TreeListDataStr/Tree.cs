using System;
using System.Collections;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _TreeListDataStr
{
    // Search: key --> value
    public class Tree    //: IDictionary !!! Homework
    {
        private Node _root = null;

        public void Add(int key, string data)
        {
            Add(ref _root, key, data);
        }

        private void Add(ref Node root, int key, string data)
        {
            if (root == null)
            {
                root = new Node(key, data);
                return;
            }

            if (key < root.Key)
            {
                Add(ref root.Lefl, key, data);
            }
            else
            {
                Add(ref root.Right, key, data);
            }
        }

        public bool TryGetValue(int key, out string data)
        { 
            Node result = GetNodeByKey(_root, key);

            if (result == null)
            {
                data = string.Empty;

                return false;
            }

            data = result.Data;

            return true;
        }

        private static Node GetNodeByKey(Node root, int key)
        {
            if (root == null)
            {
                return null;
            }

            if (root.Key == key)
            {
                return root;
            }

            if (key < root.Key)
            {
                return GetNodeByKey(root.Lefl, key);
            }
            else
            {
                return GetNodeByKey(root.Right, key);
            }
        }

#if DEBUG

        //public void Print()
        //{
        //    Print(_root);
        //    Console.WriteLine();
        //}

        //private static void Print(Node root)
        //{
        //    if (root == null)
        //    {
        //        return;
        //    }

        //    // (1)
        //    //Print(root.Lefl);

        //    //Console.Write("{0} ", root.Info);

        //    //Print(root.Right);

        //    // (2)
        //    Print(root.Right);

        //    Console.Write("{0} ", root.Info);

        //    Print(root.Lefl);
        //}

        // (3)
        //private static void Print(Node root, int level = 0)
        //{
        //    if (root == null)
        //    {
        //        return;
        //    }

        //    Print(root.Lefl, level + 1);

        //    for (int i = 0; i < level; i++)
        //    {
        //        Console.Write('\t');
        //    }
        //    Console.WriteLine("{0} ", root.Info);

        //    Print(root.Right, level + 1);
        //}
#endif

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(1024);

            ToString(result, _root);

            return result.ToString();
        }

        private static void ToString(StringBuilder result, Node root, int level = 0)
        {
            if (root == null)
            {
                return;
            }

            ToString(result, root.Lefl, level + 1);

            for (int i = 0; i < level; i++)
            {
                result.Append('\t');
            }
            result.AppendFormat("{0} ({1}) ", root.Key, root.Data);
            result.AppendLine();

            ToString(result, root.Right, level + 1);
        }

        private class Node
        {
            public Node(int key, string data) 
            {
                Key = key; 
                Data = data;

                Lefl = null;
                Right = null;
            }

            public int Key;
            public string Data;    // Value

            public Node Lefl;
            public Node Right;
        }
    }
}
