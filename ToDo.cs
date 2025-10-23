

namespace ToDoList
{
    internal class ToDo
    {
        
        public static void MakeFile(string name)
        {
            File.WriteAllText(@"../../../" + name, "");
            
        }

        public static void ShowFile(string name)
        {
            string[] info = File.ReadAllLines(@"../../../" + $"{name}.txt");
            for (int i = 0; i < info.Length; i++)
            {
                Console.WriteLine(info[i]);
            }
        }

        public static void Add(string path,string s)
        {
            int count = File.ReadAllLines(@"../../../" + path + ".txt").Length;

            File.AppendAllText(@"../../../" + path+".txt",$"{count}. "+s+"\n");
        }

        public static void Remove(string path,int n)
        {
            List<string> arr = File.ReadAllLines(@"../../../" + path + ".txt").ToList();
            if(n <= 0 || n >= arr.Count())
            {
                throw new ArgumentOutOfRangeException();
            }
            arr.RemoveAt(n);

            File.WriteAllText(@"../../../" + path + ".txt", "      ToDo Tasks     \n");
            for (int i = 1; i < arr.Count; i++)
            {
                File.AppendAllText(@"../../../" + path + ".txt", $"{i}. {arr[i].Substring(3)}\n");
            }

        }

    }


}
