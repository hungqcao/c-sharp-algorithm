using Algorithms.Array;
using Algorithms.Trie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            TrieNode root = new TrieNode();
            TrieImplementations.Insert(root, "test");
            TrieImplementations.Insert(root, "a");
            TrieImplementations.Insert(root, "and");
            TrieImplementations.Insert(root, "angry");
            TrieImplementations.Insert(root, "anger");
            TrieImplementations.Insert(root, "angola");
            TrieImplementations.Insert(root, "absolute");

            var isFound = TrieImplementations.Search(root, "testor");

            var result = new List<string>();
            TrieImplementations.Suggest(root, "an", result);
        }
    }
}
