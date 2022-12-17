string textFile = @"test.txt";
string[] lines = File.ReadAllLines(textFile);
List<List<int>> area = new List<List<int>>();
start(lines, 2);
void start(string[] puzzleInput, int part)
{
    if (part == 1)
    {
        int[,] array = new int[5, 5];
        int total = 0;
        for (int i = 0; i < puzzleInput.Length; i++)
        {
            List<int> row = new List<int>();
            for (int j = 0; j < puzzleInput[i].Length; j++)
            {
                row.Add(int.Parse(puzzleInput[i][j].ToString()));
            }
            area.Add(row);
        }
        Console.WriteLine();
        for (int i = 0; i < puzzleInput.Length; i++)
        {
            for (int j = 0; j < puzzleInput[i].Length; j++)
            {
                int currenthight = area[i][j];
                //look left
                bool visibleleft = true;
                if (j == 0)
                {
                    visibleleft = true;
                }
                else
                {
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (area[i][k] >= currenthight)
                        {
                            visibleleft = false;
                        }
                    }
                }
                //look right
                bool visibleright = true;
                if (j == area[i].Count)
                {
                    visibleright = true;
                }
                else
                {
                    for (int k = j + 1; k < area[i].Count; k++)
                    {
                        if (area[i][k] >= currenthight)
                        {
                            visibleright = false;
                        }
                    }
                }
                //look up
                bool visibleup = true;
                if (i == 0)
                {
                    visibleup = true;
                }
                else
                {
                    for (int k = i - 1; k >= 0; k--)
                    {
                        if (area[k][j] >= currenthight)
                        {
                            visibleup = false;
                        }
                    }
                }
                //look down
                bool visibledown = true;
                if (i == area.Count)
                {
                    visibledown = true;
                }
                else
                {
                    for (int k = i + 1; k < area.Count; k++)
                    {
                        if (area[k][j] >= currenthight)
                        {
                            visibledown = false;
                        }
                    }
                }
                if (!visibleleft && !visibleright && !visibleup && !visibledown)
                {
                    //array[i, j] = 0;
                }
                else
                {
                    total++;
                    //array[i, j] = 1;
                }
            }
        }
        Console.WriteLine(total);
        /*for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write(array[i,j]);
            }
            Console.WriteLine();
        }*/
    }
    else
    {
        int[,] array = new int[5, 5];
        int total = 0;
        for (int i = 0; i < puzzleInput.Length; i++)
        {
            List<int> row = new List<int>();
            for (int j = 0; j < puzzleInput[i].Length; j++)
            {
                row.Add(int.Parse(puzzleInput[i][j].ToString()));
            }
            area.Add(row);
        }
        Console.WriteLine();
        List<int> scenery = new List<int>();
        for (int i = 0; i < puzzleInput.Length; i++)
        {
            for (int j = 0; j < puzzleInput[i].Length; j++)
            {
                int currenthight = area[i][j];
                int leftscenery = 1;
                int rightscenery = 1;
                int upscenery = 1;
                int downscenery = 1;
                //look left
                bool visibleleft = true;
                if (j == 0)
                {
                    visibleleft = true;
                }
                else
                {
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (area[i][k] >= currenthight)
                        {
                            visibleleft = false;
                            break;
                        }
                        if (k != 0)
                        {
                            leftscenery++;
                        }
                    }
                }
                //look right
                bool visibleright = true;
                if (j == area[i].Count)
                {
                    visibleright = true;
                }
                else
                {
                    for (int k = j + 1; k < area[i].Count; k++)
                    {
                        if (area[i][k] >= currenthight)
                        {
                            visibleright = false;
                            break;
                        }
                        if(k != area[i].Count-1)
                        {
                            rightscenery++;
                        }
                    }
                }
                //look up
                bool visibleup = true;
                if (i == 0)
                {
                    visibleup = true;
                }
                else
                {
                    for (int k = i - 1; k >= 0; k--)
                    {
                        if (area[k][j] >= currenthight)
                        {
                            visibleup = false;
                            break;
                        }
                        if (k != 0)
                        {
                            upscenery++; 
                        }
                    }
                }
                //look down
                bool visibledown = true;
                if (i == area.Count)
                {
                    visibledown = true;
                }
                else
                {
                    for (int k = i + 1; k < area.Count; k++)
                    {
                        if (area[k][j] >= currenthight)
                        {
                            visibledown = false;
                            break;
                        }
                        if (k != area.Count - 1)
                        {
                            downscenery++;
                        }
                    }
                }
                if (!visibleleft && !visibleright && !visibleup && !visibledown)
                {
                    //array[i, j] = 0;
                    scenery.Add(leftscenery * rightscenery * upscenery * downscenery);
                }
                else
                {
                    total++;
                    scenery.Add(leftscenery * rightscenery * upscenery * downscenery);
                    //array[i, j] = 1;
                }

            }
        }
        int highestValue = scenery[0];

        // Iterate through the list and check if each element is greater than the current highest value
        foreach (int number in scenery)
        {
            if (number > highestValue)
            {
                highestValue = number;
            }
        }
        Console.WriteLine(highestValue);
    }
}