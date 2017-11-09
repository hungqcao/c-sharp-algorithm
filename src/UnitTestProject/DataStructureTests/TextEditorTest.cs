using Algorithms.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.DataStructureTests
{
    [TestClass]
    public class TextEditorTest
    {
        [TestMethod]
        public void MyTestMethod()
        {
           // var numInstructions = new string[] { "add abc", "print 3", "delete 3", "add xy", "print 2", "undo", "undo" };
            var numInstructions = new string[] { "delete 4", "delete 4", "add -1", "undo" };

            var editor = new TextEditor();
            for (var i = 0; i < numInstructions.Length; i++)
            {
                var currentInstruction = numInstructions[i];
                var commands = currentInstruction.Split(' ');
                switch (commands[0].ToLower())
                {
                    case "add":
                        var addCommand = new AddCommand(commands[1]);
                        editor.commands.Push(addCommand);
                        editor.Execute(addCommand);
                        break;
                    case "print":
                        var printCommand = new PrintCommand(commands[1]);
                        editor.Execute(printCommand);
                        break;
                    case "delete":
                        var deleteCommand = new DeleteCommand(commands[1]);
                        editor.commands.Push(deleteCommand);
                        editor.Execute(deleteCommand);
                        break;
                    case "undo":
                        editor.Undo();
                        break;
                    default:
                        break;
                }
            }

            Assert.AreEqual("test", editor.Content);
        }

        [TestMethod]
        public void Test_Method()
        {
            int[] inputArray = new int[] { 1, 2, 3 };
            var test = inputArray.Where(i => i % 2 == 0).Select(i => (i + i + 3) * 2).OrderBy(i => i).ToArray();

            inputArray = new int[] { };
            test = inputArray.Where(i => i % 2 == 0).Select(i => (i + i + 3) * 2).OrderBy(i => i).ToArray();

            inputArray = new int[] { 1, 2, 3 };
            test = inputArray.Where(i => i % 2 == 0).Select(i => (i + i + 3) * 2).OrderBy(i => i).ToArray();

            inputArray = new int[] { 1, 2, 3 };
            test = inputArray.Where(i => i % 2 == 0).Select(i => (i + i + 3) * 2).OrderBy(i => i).ToArray();
        }
    }
}
