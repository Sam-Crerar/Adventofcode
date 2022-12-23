using adventofcode11;

string textFile = @"test.txt";
string[] lines = File.ReadAllLines(textFile);
List<monkey> monkeys = new List<monkey>();
int rounds = 20;

for(int i = 0; i < lines.Length; i+= 7)
{
    List<int> items = new List<int>();
    string[] subs = lines[i+1].Split(' ');
    for(int j = 4; j < subs.Length; j++)
    {
        string holder = subs[j].Replace(",", "");
        items.Add(int.Parse(holder));
    }
    subs = lines[i + 2].Split(' ');
    char operationtype = char.Parse(subs[6]);
    string operationvalue = subs[7];
    subs = lines[i + 3].Split(' ');
    int testvalue = int.Parse(subs[5]);
    subs = lines[i + 4].Split(' ');
    int trueto = int.Parse(subs[9]);
    subs = lines[i + 5].Split(' ');
    int falseto = int.Parse(subs[9]);
    monkey x = new monkey(items,operationtype,operationvalue,testvalue,trueto,falseto);
    monkeys.Add(x);
}
Console.WriteLine();

for(int i = 0; i < rounds; i++)
{
    for(int j = 0; j < monkeys.Count; j++)
    {
        for(int k = 0; k < monkeys[j].items.Count; k++)
        {
            decimal worry = monkeys[j].calculateworry();
            worry /= 3;
            worry = Math.Round(worry);
            int monk = monkeys[j].whichmonkeytogive(worry);
            monkeys[monk].items.Add(worry);
        }
    }
}