using Algorithms.ArrayProb;
using Algorithms.Bit;
using Algorithms.Sorting;
using Algorithms.Tree;
using Algorithms.Tree.BinarySearchTree;
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
            var strings = new string[] { "greeneggs", "ham", "sam", "i", "am" };
            var sb = new StringBuilder();
            var dict = new int[26];
            foreach (var str in strings)
            {
                Console.WriteLine(str);
                foreach (var character in str)
                {
                    var idx = character - 'a';
                    if (idx < 0 || idx >= 26)
                    {
                        //ingore unexpected characters
                        continue;
                    }
                    dict[character - 'a']++;
                }
            }
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < dict[i]; j++)
                {
                    sb.Append((char)('a' +i));
                }
            }
            //Trie
            //TrieNode root = new TrieNode();
            //TrieImplementations.Insert(root, "test");
            //TrieImplementations.Insert(root, "a");
            //TrieImplementations.Insert(root, "and");
            //TrieImplementations.Insert(root, "angry");
            //TrieImplementations.Insert(root, "anger");
            //TrieImplementations.Insert(root, "angola");
            //TrieImplementations.Insert(root, "absolute");

            //var isFound = TrieImplementations.Search(root, "testor");

            //var result = new List<string>();
            //TrieImplementations.Suggest(root, "an", result);

            //Radix sort
            //RadixSort.radixsort(new int[] {63, 1, 48, 53, 24, 10, 12, 30 }, 8, 8);

            //Binary insertion sort
            //BinaryInsertionSort.main();

            //Insertion sort
            //InsertionSort.sort(new int[] { 63, 1, 48, 53, 24, 10, 12, 30 });

            //BinarySearchTree
            //BinarySearchTree tree = new BinarySearchTree();
            //tree.Main();


            //Strings.FindWords(new string[] { "Hello", "Alaska", "Dad", "Peace" });
            //Strings.ReverseWords("Let's take LeetCode contest");

            //BitManipulation.GetSum(1, 2);
            //var res = BitManipulation.FindComplement(5);


            //Arrays.NextGreaterElement(new int[] { 4, 1, 2 }, new int[] { 4, 3, 1, 2 });
            //Arrays.MoveZeroes(new int[] { 0, 4, 8, 0, 4, 1, 13, 0 });
            //Arrays.ConstructRectangle(10);
            //Arrays.MaxCount(3, 3, new int[,] { { 2, 2 }, { 3, 3 } });
            //Arrays.firstDuplicate(new int[] { 2, 3, 3, 1, 5, 2 });
            //Arrays.FindMaxConsecutiveOnes(new int[] { 1, 1, 0, 1, 0, 0, 1, 1, 1 });
            //Arrays.TwoSum(new int[] { -1, 0 }, -1);
            //Arrays.FirstUniqChar("loveleetcode");

            //[2147483647,2147483647,2147483647]
            var root = new TreeNode(10);
            var node5 = new TreeNode(5);
            var nodeM3 = new TreeNode(-3);
            var node3 = new TreeNode(3);
            var node2 = new TreeNode(2);
            var node11 = new TreeNode(11);
            var node3_1 = new TreeNode(3);
            var nodeM2 = new TreeNode(-2);
            var node1 = new TreeNode(1);
            root.left = node5;
            root.right = nodeM3;
            node5.left = node3;
            node5.right = node2;
            nodeM3.right = node11;
            node3.right = nodeM2;
            node3.left = node3_1;
            node2.right = node1;
            BinaryTreeProblems.pathSum(root, 8);

            //BSTProblems.GetMinimumDifference(root);
            //BSTProblems.ConvertBST(root);
            //var ret = BSTProblems.IsCorr1BST(root);
            //BSTProblems.connect2(root);

            //var a = Strings.reverseString("  i like this program      very much  ");

            //BinaryTreeProblems.AverageOfLevels(root);
            //BinaryTreeProblems.Tree2str(root);
            //BinaryTreeProblems.SumOfLeftLeaves(root);

            //Strings.DetectCapitalUse("Google");
            //Strings.DetectCapitalUse("USA");
            //Strings.DetectCapitalUse("google");
            //Strings.DetectCapitalUse("goOgle");
            //Strings.DetectCapitalUse("googlE");
            //Strings.TitleToNumber("AAA");
            //Strings.FindRelativeRanks(new int[] { 1, 4, 3, 2, 5 });
            //Strings.LongestPalindrome("ccc");
            //int[][] jaggedArray3 =
            //{
            //    new int[] {0, 0},
            //    new int[] {1, 0},
            //    new int[] {2, 0}
            //};
            //Arrays.NumberOfBoomerangs(jaggedArray3);
            //var ret = Arrays.ReadBinaryWatch(2);
            //BinaryTreeProblems.SortedArrayToBST(new int[] { 1, 2, 3, 4, 5 });

            //int[,] input = new int[,] { { 1, 1, 0, 1 }, { 1, 1, 0, 1 }, { 0, 0, 1, 0 }, { 1, 1, 0, 0 } };
            //var uf = new Graph.FriendCircleUnionFind();
            //var count = uf.FindCircleNum(input);

            //Arrays.productExceptSelf(new int[] { 1, 2, 3, 4 });

            var backTrack = new Backtracking.BackTrackingProblems();
            //backTrack.generateParenthesis(3);
            //Arrays.FindDuplicate(new int[] { 2, 3, 1, 1, 4, 5, 6 });



            //var root = new GNode(1);
            //var node1 = new GNode(2);
            //var node2 = new GNode(3);
            //var node3 = new GNode(4);
            //root.Children = new GNode[] { node1, node2, node3 };
            //var node4 = new GNode(5);
            //var node5 = new GNode(6);
            //node1.Children = new GNode[] { node4, node5 };
            //var node6 = new GNode(7);
            //node3.Children = new GNode[] { node6 };

            //var node7 = new GNode(8);
            //node4.Children = new GNode[] { node7 };
            //var node8 = new GNode(9);
            //node6.Children = new GNode[] { node8 };
            //Trees.Connect(root);
            Arrays.maxProfit(new int[] { 4, 5, 1, 8, 10 });
            Console.Read();
        }
    }
}
