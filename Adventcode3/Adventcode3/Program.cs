using Adventcode3;

string textFile = @"file.txt";
string[] lines = File.ReadAllLines(textFile);
Console.WriteLine(part2(lines));
Console.WriteLine("done");

int part1(string[] puzzleInput)
{
    int total = 0;
    List<Rucksack> items = new List<Rucksack>();

    foreach (string line in puzzleInput)
    {
        Rucksack x = new Rucksack(line);
        items.Add(x);
    }
    foreach (Rucksack x in items)
    {
        total += x.getsameone();
    }
    return total;
}

int part2(string[] puzzleInput)
{
    int total = 0;
    List<Group> items = new List<Group>();
    for (int i =0; i < puzzleInput.Length; i += 3)
    {
        Group group = new Group();
        group.elf1 = puzzleInput[i];
        group.elf2 = puzzleInput[i+ 1];
        group.elf3 = puzzleInput[i + 2];
        items.Add(group);
        group.calculatecom();
        total += group.getComanality();
    }
    return total;
}