string textFile = @"file.txt";
string[] lines = File.ReadAllLines(textFile);
//Console.WriteLine(Part1(lines));
Console.WriteLine(Part2(lines));

int Part1(string[] puzzleInput)
{
    int total = 0;
    for(int i =0; i < puzzleInput.Length; i++)
    {
        int current = 0;
        string line = puzzleInput[i];
        switch (line[2])
        {
            case 'X':
                total += 1;
                current += 1;
                if (line[0] == 'A')
                {
                    total += 3;
                    current += 3;
                }
                else if (line[0] == 'B')
                {
                    total += 0;
                    current += 0;
                }
                else if(line[0] == 'C')
                {
                    total += 6;
                    current += 6;
                }
                else { Console.WriteLine("fucked A"); }
                Console.WriteLine("The line" + i + " " + line[0] + " vs " + line[2] + " = " + current);
                break;
            case 'Y':
                total += 2;
                current += 2;
                if (line[0] == 'A')
                {
                    total += 6;
                    current += 6;
                }
                else if(line[0] == 'B')
                {
                    total += 3;
                    current += 3;
                }
                else if(line[0] == 'C')
                {
                    total += 0;
                    current += 0;
                }
                else { Console.WriteLine("fucked B"); }
                Console.WriteLine("The line" + i + " " + line[0] + " vs " + line[2] + " = " + current);
                break;
            case 'Z':
                total += 3;
                current += 3;
                if (line[0] == 'A')
                {
                    total += 0; 
                    current += 0;
                }
                else if(line[0] == 'B')
                {
                    total += 6;
                    current += 6;
                }
                else if(line[0] == 'C')
                {
                    total += 3;
                    current += 3;
                }
                else { Console.WriteLine("fucked C"); }
                Console.WriteLine("The line" + i + " " + line[0] + " vs " + line[2] + " = " + current);
                break;
            default:
                Console.WriteLine("You fucked up you shouldnt see me"); 
                break;
        }
    };

    return total;
}

int Part2(string[] puzzleInput)
{
    int total = 0;
    for (int i = 0; i < puzzleInput.Length; i++)
    {
        int current = 0;
        string line = puzzleInput[i];
        switch (line[2])
        {
            case 'X':
                total += 0;
                if(line[0] == 'A') { total += 3; current += 3; }
                if (line[0] == 'B') { total += 1; current += 1; }
                if (line[0] == 'C') { total += 2; current += 2; }
                Console.WriteLine("The line" + i + " " + line[0] + " vs " + line[2] + " = " + current);
                break;
            case 'Y':
                total += 3;
                current += 3;
                if (line[0] == 'A') { total += 1; current += 1; }
                if (line[0] == 'B') { total +=2; current += 2; }
                if (line[0] == 'C') { total += 3; current += 3; }
                Console.WriteLine("The line" + i + " " + line[0] + " vs " + line[2] + " = " + current);
                break;
            case 'Z':
                total += 6;
                current += 6;
                if (line[0] == 'A') { total += 2; current += 2; }
                if (line[0] == 'B') { total += 3; current += 3; }
                if (line[0] == 'C') { total += 1; current += 1; }
                Console.WriteLine("The line" + i + " " + line[0] + " vs " + line[2] + " = " + current);
                break;
        }
    }
    return total;
}