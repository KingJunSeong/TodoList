using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace todo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CS_TodoList");
            string txtpath = path + @"\todo.txt";

            DirectoryInfo txtdir = new DirectoryInfo(txtpath);

            if (args.Length < 1)
            {
                if (!File.Exists(txtpath))
                {
                    File.Create(txtpath);
                    Console.WriteLine($"created txt file at \"{txtdir}\"!");
                }
                Function.WelCome();
                return;
            }


            string option = args[0];
            string str = "";
            int result = 0;
            switch (option.ToLower())
            {
                case "add":
                    if(args.Length == 1)
                    {
                        Console.WriteLine("Command does not exist.");
                    }
                    for(int i=2; i<=args.Length; i++)
                    {
                        str += args[i-1] + " ";
                    }
                    Function.AddCommand(str);
                    break;
                case "rm":
                    if (args.Length == 1 || args.Length >= 3)
                    {
                        Console.WriteLine("Command does not exist.");
                        return;
                    }
                    if (int.TryParse(args[1], out result) != true)
                    {
                        Console.WriteLine("Command does not exist.");
                        return;
                    }
                    Function.RemoveCommand(int.Parse(args[1]));
                    break;
                case "ls":
                    Function.ShowTodoCommand();
                    break;
                case "clear":
                    Function.ClearTodoCommand();
                    break;
                default:
                    Console.WriteLine($"Command does not exist.");
                    break;
            }

        }
    }
}