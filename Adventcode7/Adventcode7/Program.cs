using Adventcode7;

public class Program {
    public static int total;
    public static List<Folder> bigenough = new List<Folder>();
    public static int sizeneeded;
    public static void Main(string[] args)
    {
        string textFile = @"file.txt";
        string[] lines = File.ReadAllLines(textFile);
        start(lines, 1);
    }

    public static void start(string[] puzzleInput, int part)
    {
        List<Folder> path = new List<Folder>();
        Folder currentdir = new Folder("root");
        path.Add(currentdir);
        foreach (string line in puzzleInput)
        {
            string[] subs = line.Split(' ');
            if (subs[0] == "$")
            {
                if (subs[1] == "cd")
                {
                    //stop looking at this bit
                    if (subs[2] == "/")
                    {
                        continue;
                    }
                    if (subs[2] == "..")
                    {
                        path.RemoveAt(path.Count - 1);
                        continue;
                    }
                    path.Add(path[path.Count - 1].Searchfor(subs[2]));
                }
                Console.WriteLine("CMD: " + line);
            }
            else if (subs[0] == "dir")
            {
                Console.WriteLine("Folder: " + line);
                path[path.Count - 1].addingfolder(subs[1]);
            }
            else
            {
                Console.WriteLine("File: " + line);
                path[path.Count - 1].addingfilestr(int.Parse(subs[0]), subs[1]);
            }
        }
        path[0].calculatesize();
        path[0].sizeoffilebelow();
        Console.WriteLine("PART 1: " + total);
        Console.WriteLine("Total Space: 70000000");
        Console.WriteLine("Space Used: " + path[0].size);
        Console.WriteLine("Space Unused: " + (70000000 - path[0].size));
        Console.WriteLine("Space Needed: " + (30000000 - (70000000 - path[0].size)));
        sizeneeded = 30000000 - (70000000 - path[0].size);
        path[0].listofbigenoughfiles();
        int smallest = 70000001;
        for(int i = 0; i < bigenough.Count; i++)
        {
            if(bigenough[i].size < smallest)
            {
                smallest = bigenough[i].size;
            }
        }

        Console.WriteLine("The Smallest File is: " + smallest);
    }
}