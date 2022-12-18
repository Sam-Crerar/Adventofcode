string textFile = @"file.txt";
string[] lines = File.ReadAllLines(textFile);
string[] sub;
int cycle = 1;
int total = 0;
int x = 1;
int[] checking = new int[] { 20, 60, 100, 140, 180, 220};
List<string> list = new List<string>();
list.Add("#");
part1(lines);
Console.WriteLine(total);

void part1(string[] PuzzleInput)
{
    foreach(string line in PuzzleInput)
    {
        sub = line.Split(' ');
        if(sub[0] == "noop")
        {
            cycle++;
            Console.WriteLine("Current cycle: {0} Current X: {1} Command NOOP",cycle,x);
            Checking();
            addtoCRT();
        }
        else
        {
            cycle++;
            Console.WriteLine("Current cycle: {0} Current X: {1} Command ADDX 1", cycle, x);
            Checking();
            addtoCRT();
            x += int.Parse(sub[1]);
            cycle++;
            Console.WriteLine("Current cycle: {0} Current X: {1} Command ADDX 2", cycle, x);
            Checking();
            addtoCRT();
        }
    }
    printlist();
}

void Checking()
{
    for(int i =0; i < checking.Length; i++)
    {
        if(checking[i] == cycle)
        {
            Console.WriteLine("Adding: " + (checking[i] * cycle) + " Which is "+ checking[i] + " " + x);
            total += checking[i] * x;
        }
    }
}

void addtoCRT()
{
    int position = list.Count% 40;
    if (position >= x-1 && position <= x + 1)
    {
        list.Add("#");
        Console.WriteLine("Adding: #");
        return;
    }
    list.Add(".");
    Console.WriteLine("Adding: .");
}

void printlist()
{
    int couter = 0;
    for (int i = 0; i < list.Count/40; i ++)
    {
        for (int j = 0; j < 40; j++)
        {
            try
            {
                Console.Write(list[j+ (couter*40)]);
            }
            catch
            {
                Console.Write("0");
            }
            
        }
        Console.WriteLine();
        couter++;
    }
}