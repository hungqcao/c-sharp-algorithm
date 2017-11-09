using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class TextEditor
    {
        private string _content;
        public string Content { get { return string.IsNullOrWhiteSpace(_content) ? "" : _content; } set { _content = value; } }
        public Stack<EditorCommand> commands;
        public TextEditor()
        {
            Content = string.Empty;
            commands = new Stack<EditorCommand>();
        }

        public void Execute(EditorCommand command)
        {
            command.Execute(this);
        }

        public void Undo()
        {
            if (commands.Any())
            {
                var command = commands.Pop();
                command.Undo(this);
            }
        }
    }

    public abstract class EditorCommand
    {
        protected string name;
        protected string input;
        protected bool statusLastTime;
        public EditorCommand(string inputVal)
        {
            input = inputVal;
        }
        public abstract void Execute(TextEditor source);

        public abstract void Undo(TextEditor source);
    }

    public class AddCommand : EditorCommand
    {
        public AddCommand(string input) : base(input) { name = "add"; }

        public override void Execute(TextEditor source)
        {
            var builder = new StringBuilder(source.Content);
            source.Content = builder.Append(input).ToString();
            statusLastTime = true;
        }

        public override void Undo(TextEditor source)
        {
            if (statusLastTime)
            {
                source.Content = source.Content.Substring(0, source.Content.Length - input.Length);
            }
            else
            {
                Console.Write($"cannot undo");
            }
        }
    }

    public class PrintCommand : EditorCommand
    {
        public PrintCommand(string input) : base(input) { name = "print"; }

        public override void Execute(TextEditor source)
        {
            int ind;
            if (int.TryParse(input, out ind) && ind > 0 && ind - 1 < source.Content.Length)
            {
                Console.WriteLine(source.Content[ind - 1]);
            }
            else
            {
                Console.Write($"cannot {name}");
            }
        }

        public override void Undo(TextEditor source)
        {
            return;
        }
    }

    public class DeleteCommand : EditorCommand
    {
        private string originalChars;
        public DeleteCommand(string input) : base(input) { name = "delete"; }

        public override void Execute(TextEditor source)
        {
            int ind;
            if (int.TryParse(input, out ind) && ind > 0)
            {
                if(ind > source.Content.Length)
                {
                    ind = source.Content.Length;
                }

                originalChars = source.Content.Substring(source.Content.Length - ind, ind);
                source.Content = source.Content.Substring(0, source.Content.Length - ind);
                statusLastTime = true;
            }
            else
            {
                Console.Write($"cannot {name}");
            }
        }

        public override void Undo(TextEditor source)
        {
            if (statusLastTime)
            {
                var builder = new StringBuilder(source.Content);
                source.Content = builder.Append(originalChars).ToString();
            }
            else
            {
                Console.Write($"cannot undo");
            }
        }
    }
}
