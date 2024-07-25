using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting;

namespace BFS_and_DFS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            string input = "";

            Console.WriteLine("Type 'please exit' to exit the program at any time");

            do
            {
                Console.WriteLine("Please enter the file name: ");
                input = Console.ReadLine();

                try
                {
                    if (input != "please exit")
                    {
                        input = "TextFiles/" + input;
                        tree.FillTree(input);

                        input = SearchLoop(input, tree); // no longer need input for the file so using it for the search inputs

                        tree.Root = BinaryTree.EmptyTree(tree.Root);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0}", e.Message);
                }

            } while (input != "please exit");
        }

        public static string SearchLoop(string input, BinaryTree tree)
        {
            while (input != "empty tree" && input != "please exit")
            {
                Console.WriteLine("Please input a word you would like to search for or if you are done searching this file type 'empty tree'");
                input = Convert.ToString(Console.ReadLine());

                if (input != "empty tree" && input != "please exit")
                {
                    Console.WriteLine("\nBFS of {0}, resulted in {1} matches", input, tree.BFS(input));
                    Console.WriteLine("DFS of {0}, resulted in {1} matches\n", input, tree.DFS(input));
                }
            }

            return input;
        }
    }
}