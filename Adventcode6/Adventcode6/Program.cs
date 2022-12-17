using System.Collections.Generic;

string textFile = @"file.txt";
string[] lines = File.ReadAllLines(textFile);



Console.WriteLine(start(lines[0],14));
int start(string input, int adding)
{
    for ( int i = adding - 1; i < input.Length; i++)
    {
        List<char> vs = new List<char>();
        for(int j = 0; j < adding; j++)
        {
            vs.Add(input[i - j]);
        }
        IEnumerable<char> duplicates = from x in vs
                                      group x by x into g
                                      where g.Count() > 1
                                      select g.Key;
        if(duplicates.Count() == 0)
        {
            return i + 1;
        }
    }
    return -1;
}