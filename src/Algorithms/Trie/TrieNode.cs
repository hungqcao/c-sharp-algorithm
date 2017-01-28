using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Trie
{
    public class TrieNode
    {
        public TrieNode[] Nodes { get; set; }

        /// <summary>
        /// isLeaf is true if the node represents end of a word
        /// </summary>
        public bool IsLeaf { get; set; }
        public TrieNode()
        {
            //English alphabet
            Nodes = new TrieNode[26];
        }
    }

    public static class TrieImplementations
    {
        public static void Insert(TrieNode root, string word)
        {
            //Check corner cases

            if (string.IsNullOrEmpty(word))
            {
                return;
            }

            var lowerCaseWord = word.ToLower();
            var firstLetter = lowerCaseWord[0];

            //Create child node
            var childNode = new TrieNode();

            //Asign to parent node
            root.Nodes[firstLetter - 'a'] = childNode;

            //If we only have 1 letter left then mark it as leaf and return
            if (word.Length == 1)
            {
                childNode.IsLeaf = true;
                return;
            }

            //Continue inserting the rest of the word
            Insert(childNode, word.Remove(0, 1));
        }

        public static bool Search(TrieNode root, string word)
        {
            if (string.IsNullOrEmpty(word) || root == null) return false;

            var firstLetter = word[0];

            if (word.Length == 1 && root.Nodes[firstLetter - 'a'] != null && root.Nodes[firstLetter - 'a'].IsLeaf)
            {
                return true;
            }
            else
            {
                return Search(root.Nodes[firstLetter - 'a'], word.Remove(0, 1));
            }
        }

        public static void Suggest(TrieNode root, string prefix, List<string> result)
        {
            if (string.IsNullOrEmpty(prefix) || root == null) return;

            TrieNode prefixRootNode = root;
            var keyword = prefix;
            while (keyword.Length > 1)
            {
                //Couldn't find prefixRootNode
                if (prefixRootNode == null) return;

                var firstLetter = keyword[0];
                prefixRootNode = prefixRootNode.Nodes[firstLetter - 'a'];
                keyword = keyword.Remove(0, 1);
            }

            var lastLetter = keyword[0];
            //keyword has 1 character
            if (prefixRootNode.Nodes[lastLetter - 'a'] != null && prefixRootNode.Nodes[lastLetter - 'a'].IsLeaf)
            {
                result.Add(prefix);
            }

            FindAllChildren(prefixRootNode.Nodes[lastLetter - 'a'], result, prefix);
        }

        private static void FindAllChildren(TrieNode root, List<string> result, string prefix)
        {
            if (root == null) return;

            for (int i = 0; i < root.Nodes.Length; i++)
            {
                if (root.Nodes[i] != null && root.Nodes[i].IsLeaf)
                {
                    result.Add(string.Concat(prefix, char.ConvertFromUtf32('a' + i)));
                }
                else
                {
                    FindAllChildren(root.Nodes[i], result, string.Concat(prefix, char.ConvertFromUtf32('a' + i)));
                }
            }
        }
    }
}
