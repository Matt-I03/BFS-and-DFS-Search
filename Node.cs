using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_and_DFS
{
    internal class Node
    {
        public string Word { get; set; }
        public Node Left { get; set; } = null!;
        public Node Right { get; set; } = null!;

        public Node(string word = "")
        {
            Word = word;
        }

        public virtual void Insert(string newWord)
        {
            int res = newWord.CompareTo(Word);

            if (res <= 0)
            {
                if (Left == null)
                    Left = new Node(newWord);
                else
                    Left.Insert(newWord);
            }
            else
            {
                if (Right == null)
                    Right = new Node(newWord);
                else
                    Right.Insert(newWord);
            }
        }
    }
}
