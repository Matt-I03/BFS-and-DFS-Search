using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BFS_and_DFS
{
    internal class BinaryTree : Node
    {
        public Node Root { get; set; } = null!;

        public override void Insert(string word)
        {
            if (Root == null) // empty tree
                Root = new Node(word);
            else
                Root.Insert(word);
        }

        public static void InOrder(Node root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                Console.Write(" {0}", root.Word);
                InOrder(root.Right);
            }
        }

        public void FillTree(string file)
        {
            const int MAX_LINES = 10000;
            string[] text = new string[MAX_LINES];

           text = File.ReadAllLines(file);
            
           foreach (string line in text)
           {
                string[] words = line.Split(' ');
                foreach (string word in words)
                {
                    if (!string.IsNullOrEmpty(word))
                        Insert(word);
                }
           }
        }

        public int BFS(string word) 
        {
                int counter = 0;
                Queue<Node> q = new Queue<Node>();
                
                if (Root != null)
                    q.Enqueue(Root);

                while (q.Count != 0)
                {
                    Node temp = q.Dequeue();

                    if (temp.Word == word)
                        counter++;

                    if (temp.Left != null)
                        q.Enqueue(temp.Left);

                    if (temp.Right != null)
                        q.Enqueue(temp.Right);
                }
                return counter;
        }

        public int DFS(string word)
        { 
            int counter = 0;

            Stack<Node> s = new Stack<Node>();
            if (Root != null)
                s.Push(Root);

            while (s.Count != 0)
            {
                Node temp = s.Pop();

                if (temp.Word == word)
                    counter++;

                if (temp.Left != null)
                    s.Push(temp.Left);

                if (temp.Right != null)
                    s.Push(temp.Right);
            }

            return counter;
        }

        public static Node EmptyTree(Node root)
        {
            while (root != null)
            {
                EmptyTree(root.Left);
                EmptyTree(root.Right);
                root = null!;
            }

            return root;
        }
    }
}
