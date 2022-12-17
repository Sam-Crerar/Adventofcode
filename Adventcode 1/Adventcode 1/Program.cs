string textFile = @"C:\Users\Sam\Documents\elfsnacks.txt";
string[] lines = File.ReadAllLines(textFile);
List<int> elffood = findingit(lines);
int[] vs = elffood.ToArray();
Console.WriteLine(vs[0]);
Console.WriteLine(vs[0] + vs[1] + vs[2]);

List<int> findingit (string[] puzzleInput)
{
    int elf = 0;
    List<int> elffood = new List<int> ();

    foreach (string line in puzzleInput)
    {
        if (line != "")
        {
            elf += int.Parse(line);
        }
        else
        {
            elffood.Add(elf);
            elf = 0;
        }
    };

    return elffood.OrderByDescending(x => x).ToList();
}