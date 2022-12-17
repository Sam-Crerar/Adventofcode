using System.Collections.Generic;

string textFile = @"file.txt";
string[] lines = File.ReadAllLines(textFile);
List<List<char>> dock = new List<List<char>>();

//Test
/*
char[] one = { 'Z', 'N'};
char[] two = { 'M', 'C', 'D'};
char[] three = { 'P'};
dock.Add(one.ToList());
dock.Add(two.ToList());
dock.Add(three.ToList());
*/
char[] one = { 'Q', 'M', 'G', 'C', 'L' };
char[] two = { 'R', 'D', 'L', 'C', 'T', 'F', 'H', 'G' };
char[] three = { 'V', 'J', 'F', 'N', 'M', 'T', 'W', 'R' };
char[] four = { 'J', 'F', 'D', 'V', 'Q', 'P' };
char[] five = { 'N', 'F', 'M', 'S', 'L', 'B', 'T' };
char[] six = { 'R', 'N', 'V', 'H', 'C', 'D', 'P' };
char[] seven = { 'H', 'C', 'T' };
char[] eight = { 'G', 'S', 'J', 'V', 'Z', 'N', 'H', 'P' };
char[] nine = { 'Z', 'F', 'H', 'G' };

dock.Add(one.ToList());
dock.Add(two.ToList());
dock.Add(three.ToList());
dock.Add(four.ToList());
dock.Add(five.ToList());
dock.Add(six.ToList());
dock.Add(seven.ToList());
dock.Add(eight.ToList());
dock.Add(nine.ToList());

printdocks();
Console.WriteLine(part(lines, 2));
Console.WriteLine("done");

string part(string[] puzzleInput, int part)
{

    int total = 0;
    foreach (string line in puzzleInput)
    {
        string[] subs = line.Split(' ');
        int amount = int.Parse(subs[1]);
        int from = int.Parse(subs[3]);
        int to = int.Parse(subs[5]);
        if (part == 1)
        {
            moving(amount, from, to);
        }
        else
        {
            moving2(amount, from, to);
        }
        Console.WriteLine("amount: {0} from: {1} to: {2}", amount, from, to);
        //printdocks();
    }
    printdocks();
    string result = "";
    for (int i = 0; i < dock.Count; i++)
    {
        result += dock[i][dock[i].Count - 1];
    }

    return result;

}

void moving2(int amount, int from, int to)
{
    List<char> fromlist = dock[from - 1];
    List<char> tolist = dock[to - 1];
    List<char> temp = new List<char>();
    for (int i = 0; i < amount; i++)
    {
        temp.Add(fromlist[fromlist.Count - 1]);
        fromlist.RemoveAt(fromlist.Count - 1);
    }
    int counter = temp.Count;
    for (int i = 0; i < counter; i++)
    {
        tolist.Add(temp[temp.Count - 1]);
        temp.RemoveAt(temp.Count - 1);
    }
    dock[from - 1] = fromlist;
    dock[to - 1] = tolist;
}

void moving(int amount, int from, int to)
{
    List<char> fromlist = dock[from - 1];
    List<char> tolist = dock[to - 1];

    for (int i = 0; i < amount; i++)
    {
        char item = fromlist[fromlist.Count - 1];
        tolist.Insert(tolist.Count, item);
        fromlist.RemoveAt(fromlist.Count - 1);
    }
    dock[from - 1] = fromlist;
    dock[to - 1] = tolist;
}

void printdocks()
{
    Console.WriteLine("  1    2    3    4    5    6    7    8    9");
    int longestList = dock.Max(list => list.Count);
    for (int j = 0; j < longestList; j++)
    {
        for (int i = 0; i < dock.Count; i++)
        {
            try
            {
                Console.Write(" [" + dock[i][j] + "] ");
            }
            catch 
            {
                Console.Write(" [*] ");
            }

        }
        Console.WriteLine();
    }
}