using Algorithms.Array;
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
            //Arrays.MoveZeroes(new int[] { 0, 1, 4, 3, 12, 0, 0, 3, 0 });
            //Arrays.ConstructRectangle(10);
            //Arrays.MaxCount(3, 3, new int[,] { { 2, 2 }, { 3, 3 } });
            //Arrays.firstDuplicate(new int[] { 2, 3, 3, 1, 5, 2 });
            //Arrays.FindMaxConsecutiveOnes(new int[] { 1, 1, 0, 1, 0, 0, 1, 1, 1 });
            //Arrays.TwoSum(new int[] { -1, 0 }, -1);
            //Arrays.FirstUniqChar("loveleetcode");

            //[2147483647,2147483647,2147483647]
            var root = new TreeNode(8);
            var node3 = new TreeNode(3);
            var node10 = new TreeNode(10);
            var node1 = new TreeNode(1);
            var node9 = new TreeNode(9);
            var node14 = new TreeNode(14);
            root.left = node3;
            root.right = node10;
            node3.left = node1;
            node3.right = node9;
            node10.right = node14;
            node10.left = new TreeNode(15);
            node1.left = new TreeNode(0);

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
            var ret = Arrays.ReadBinaryWatch(2);
        }
    }
}
