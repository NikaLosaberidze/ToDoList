namespace ToDoList
{


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, this is ToDo List\nIf you want to create a new file," +
                    " type 'new'\nIf you want to open a file, type the name of the file that you wish to open" +
                    "\nIf you want to exit, type 'exit'");
            string ans = "";
            
            while (true)
            {
                ans = Console.ReadLine();
                if (ans == "exit")
                {
                    break;
                }
                else if (ans == "new")
                {
                    Console.Write("Write a file name:");
                    ans = Console.ReadLine();
                    ToDo.MakeFile(ans + ".txt");   
                    File.AppendAllText(@"../../../"+ans+".txt", "      ToDo Tasks     \n");
                    

                    Console.WriteLine($"File '{ans}' has been created.\n");
                    


                }
                else
                {
                    if (!File.Exists(@"../../../" + ans + ".txt"))
                    {
                        Console.WriteLine("404 : FILE NOT FOUND!\nIf you want to create a file, type 'new'" +
                            "\nIf you want to open the file, type file's name" +
                            "\nIf you want to exit, write 'exit'");
                        continue;
                    }
                    


                }

                ToDo.ShowFile(ans);

                while (true)
                {
                    

                    Console.WriteLine("\nif you want to add a task, type 'a'" +
                        "\nif you want to delete a task, type 'd'\nif you want to exit, type 'exit'");

                    string newAns = Console.ReadLine();
                    if (newAns == "a")
                    {

                        Console.WriteLine("Write you task");
                        string task = Console.ReadLine();
                        ToDo.Add(ans, task);
                        ToDo.ShowFile(ans);
                    }
                    else if (newAns == "d")
                    {
                        while (true)
                        {
                            Console.WriteLine("Write a number of task that you want to delete");
                            int n = int.Parse(Console.ReadLine());

                            try
                            {
                                ToDo.Remove(ans, n);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("INVALID NUMBER!");
                            }
                            ToDo.ShowFile(ans);
                            break;
                        }
                    }
                    else if (newAns == "exit")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("INVALID INPUT!");
                    }
                }
            }


        }

        
    }
}
