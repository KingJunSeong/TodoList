using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo
{
    class Function
    {
        static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CS_TodoList");
        static string txtpath = path + @"\todo.txt";
        public static void WelCome()
        {
            Console.WriteLine("Welcome to Todo List!");
            Console.WriteLine();
            Console.WriteLine("add [your todo] : input your todo");
            Console.WriteLine("rm [remove todo's id] : delete your Todos");
            Console.WriteLine("ls : show your Todos.");
            Console.WriteLine("clear : Clear Todos.");
        }

        public static void AddCommand(string todo)
        {
            StreamWriter writer;
            writer = File.AppendText(txtpath);
            writer.Write(todo + "\n");
            Console.WriteLine($"{todo}was added");
            writer.Close();
        }

        public static void RemoveCommand(int num)
        {
            var file = new List<string>(File.ReadAllLines(txtpath));
            if (num - 1 >= file.Count)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                string rmtodo = file[num - 1];
                file.RemoveAt(num - 1);
                File.WriteAllLines(txtpath, file.ToArray());
                Console.WriteLine($"({rmtodo}) has been removed!");
            }
        }

        public static void ShowTodoCommand()
        {
            int count = 0;
            foreach (string line in File.ReadLines(txtpath))
            {
                count++;
                Console.WriteLine($"todo {count}: {line}");
            }
            Console.WriteLine($"total todos : {count}");
        }
        public static void ClearTodoCommand()
        {
            File.WriteAllText(txtpath, String.Empty);
            Console.WriteLine("TodoList Clear!");
        }
    }
}
