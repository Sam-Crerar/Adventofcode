using Adventcode4;

string textFile = @"file.txt";
string[] lines = File.ReadAllLines(textFile);
Console.WriteLine(part2(lines));
Console.WriteLine("done");

int part1(string[] puzzleInput)
{
    int total = 0;
    foreach(string line in puzzleInput)
    {
        string[] subs = line.Split(',');
        string[] sec1 = subs[0].Split('-');
        string[] sec2 = subs[1].Split('-');
        int start1 = int.Parse(sec1[0]);
        int end1 = int.Parse(sec1[1]);
        int start2 = int.Parse(sec2[0]);
        int end2 = int.Parse(sec2[1]);
        int range1 = end1 - start1;
        int range2 = end2 - start2;
        Console.WriteLine("Start 1: {0} End 1: {1} Start 2: {2} End 2: {3}", start1, end1, start2, end2);

        if (start1 >= start2)
        {
            if(end1 <= end2)
            {
                total++;
                Console.WriteLine("Yes");
                continue;
            }
        }
        if(start2 >= start1)
        {
            if(end2 <= end1)
            {
                total++;
                Console.WriteLine("Yes");
                continue;
            }
        }

    }
    return total;
}

int part2(string[] puzzleInput)
{
    int total = 0;
    foreach (string line in puzzleInput)
    {
        string[] subs = line.Split(',');
        string[] sec1 = subs[0].Split('-');
        string[] sec2 = subs[1].Split('-');
        int start1 = int.Parse(sec1[0]);
        int end1 = int.Parse(sec1[1]);
        int start2 = int.Parse(sec2[0]);
        int end2 = int.Parse(sec2[1]);
        int range1 = end1 - start1;
        int range2 = end2 - start2;
        Console.WriteLine("Start 1: {0} End 1: {1} Start 2: {2} End 2: {3}", start1, end1, start2, end2);


        if(start2 <= end1 && start2 >= start1)
        {
            total++;
            Console.WriteLine("Worked");
            continue;
        }
        if(start1 <= end2 && start1 >= start2)
        {
            total++;
            Console.WriteLine("Worked");
            continue;
        }
    }
    return total;
}