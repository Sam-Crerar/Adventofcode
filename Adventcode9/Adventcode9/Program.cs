using Adventcode9;

string textFile = @"file.txt";
string[] lines = File.ReadAllLines(textFile);
List<List<Point>> grid = new List<List<Point>>();
int gridsize = 1000;
int total = 0;
part2(lines,10);
void part1(string[] puzzleInput)
{
    for (int i = 0; i < gridsize; i++)
    {
        List<Point> row = new List<Point>();
        for (int j = 0; j < gridsize; j++)
        {
            Point point = new Point(i, j);
            row.Add(point);
        }
        grid.Add(row);
    }
    Point head = grid[(gridsize / 2) - 1][(gridsize / 2) - 1];
    Point tail = grid[(gridsize / 2) - 1][(gridsize / 2) - 1];
    head.head = true;
    tail.tail = true;
    tail.visiteed = true;
    foreach (String line in puzzleInput)
    {
        Console.WriteLine("START");
        Console.WriteLine(line);
        string[] subs = line.Split(' ');
        string direction = subs[0];
        int amount = int.Parse(subs[1]);
        switch (direction)
        {
            case "R":
                for (int i = 0; i < amount; i++)
                {
                    head.head = false;
                    head = grid[head.x][head.y + 1];
                    head.head = true;                    
                    tail = tailmoving(head, tail);
                    //printgrid();
                }
                break;
            case "L":
                for (int i = 0; i < amount; i++)
                {
                    head.head = false;
                    head = grid[head.x][head.y - 1];
                    head.head = true;
                    tail = tailmoving(head, tail);
                    //printgrid();
                }
                break;
            case "U":
                for (int i = 0; i < amount; i++)
                {
                    head.head = false;
                    head = grid[head.x - 1][head.y];
                    head.head = true;
                    tail = tailmoving(head, tail);
                    //printgrid();
                }
                break;
            case "D":
                for (int i = 0; i < amount; i++)
                {
                    head.head = false;
                    head = grid[head.x + 1][head.y];
                    head.head = true;
                    tail = tailmoving(head, tail);
                    //printgrid();
                }
                break;
        }
        Console.WriteLine("END");
    }
    for (int i = 0; i < gridsize; i++)
    {
        for (int j = 0; j < gridsize; j++)
        {
            if (grid[i][j].visiteed)
            {
                total++;
            }
        }
    }

    Console.WriteLine("Total: " + total);
}

void part2(string[] puzzleInput,int ropesize)
{
    List<Point> rope = new List<Point>();
    for (int i = 0; i < gridsize; i++)
    {
        List<Point> row = new List<Point>();
        for (int j = 0; j < gridsize; j++)
        {
            Point point = new Point(i, j);
            row.Add(point);
        }
        grid.Add(row);
    }
    for(int i = 0; i < ropesize; i++)
    {
        rope.Add(grid[(gridsize / 2) - 1][(gridsize / 2) - 1]);
    }
    rope[0].head = true;
    rope[rope.Count - 1].tail = true;
    rope[rope.Count - 1].visiteed = true;
    foreach (String line in puzzleInput)
    {
        Console.WriteLine("START");
        Console.WriteLine(line);
        string[] subs = line.Split(' ');
        string direction = subs[0];
        int amount = int.Parse(subs[1]);
        switch (direction)
        {
            case "R":
                for (int i = 0; i < amount; i++)
                {
                    rope[0].head = false;
                    rope[0] = grid[rope[0].x][rope[0].y + 1];
                    rope[0].head = true;
                    for (int j = 1; j < rope.Count; j++)
                    {
                        rope[j] = pointmoving(rope[j-1], rope[j]);
                    }
                    rope[rope.Count - 1].visiteed = true;
                    //printgrid();
                }
                break;
            case "L":
                for (int i = 0; i < amount; i++)
                {
                    rope[0].head = false;
                    rope[0] = grid[rope[0].x][rope[0].y - 1];
                    rope[0].head = true;
                    for (int j = 1; j < rope.Count; j++)
                    {
                        rope[j] = pointmoving(rope[j - 1], rope[j]);
                    }
                    rope[rope.Count - 1].visiteed = true;
                    //printgrid();
                }
                break;
            case "U":
                for (int i = 0; i < amount; i++)
                {
                    rope[0].head = false;
                    rope[0] = grid[rope[0].x - 1][rope[0].y];
                    rope[0].head = true;
                    for (int j = 1; j < rope.Count; j++)
                    {
                        rope[j] = pointmoving(rope[j - 1], rope[j]);
                    }
                    rope[rope.Count - 1].visiteed = true;
                    //printgrid();
                }
                break;
            case "D":
                for (int i = 0; i < amount; i++)
                {
                    rope[0].head = false;
                    rope[0] = grid[rope[0].x + 1][rope[0].y];
                    rope[0].head = true;
                    for (int j = 1; j < rope.Count; j++)
                    {
                        rope[j] = pointmoving(rope[j - 1], rope[j]);
                    }
                    rope[rope.Count - 1].visiteed = true;
                    //printgrid();
                }
                break;
        }
        Console.WriteLine("END");
    }
    for (int i = 0; i < gridsize; i++)
    {
        for (int j = 0; j < gridsize; j++)
        {
            if (grid[i][j].visiteed)
            {
                total++;
            }
        }
    }
    Console.WriteLine(total);
}


void printgrid()
{
    for (int i = 0; i < gridsize; i++)
    {
        Console.Write((i+1) + " ");
        for (int j = 0; j < gridsize; j++)
        {
            if (grid[i][j].head)
            {
                Console.Write("H ");
            }
            else if (grid[i][j].tail)
            {
                Console.Write("T ");
            }
            else if (grid[i][j].visiteed)
            {
                Console.Write("# ");
            }
            else
            {
                Console.Write(". ");
            }
        }
        Console.WriteLine();
    }
    Console.WriteLine(" ");
}

Point tailmoving(Point head, Point tail)
{
    int hx = head.x;
    int hy = head.y;
    int tx = tail.x;
    int ty = tail.y;

    int xdistance = tx - hx;
    int ydistance = ty - hy;

    Console.WriteLine("X: " + xdistance);
    Console.WriteLine("Y: " + ydistance);
    if (Math.Abs(xdistance) <= 1 && Math.Abs(ydistance) <= 1)
    {
        Console.WriteLine("Don't move");
        return tail;
    }
    if(xdistance != 0)
    {
        if(xdistance > 1)
        {
            xdistance--;
        }
        else if (xdistance < -1)
        {
            xdistance++;
        }
    }
    if (ydistance != 0)
    {
        if (ydistance > 1)
        {
            ydistance--;
        }
        else if(ydistance < -1)
        {
            ydistance++;
        }
    }
    tail.tail = false;
    Console.WriteLine("Moving X: " + xdistance);
    Console.WriteLine("Moving Y: " + ydistance);
    tail = grid[tail.x - xdistance][tail.y - ydistance];
    tail.tail = true;
    tail.visiteed = true;
    return tail;
}

Point pointmoving(Point a, Point b)
{
    int hx = a.x;
    int hy = a.y;
    int tx = b.x;
    int ty = b.y;

    int xdistance = tx - hx;
    int ydistance = ty - hy;

    Console.WriteLine("X: " + xdistance);
    Console.WriteLine("Y: " + ydistance);
    if (Math.Abs(xdistance) <= 1 && Math.Abs(ydistance) <= 1)
    {
        Console.WriteLine("Don't move");
        return b;
    }
    if (xdistance != 0)
    {
        if (xdistance > 1)
        {
            xdistance--;
        }
        else if (xdistance < -1)
        {
            xdistance++;
        }
    }
    if (ydistance != 0)
    {
        if (ydistance > 1)
        {
            ydistance--;
        }
        else if (ydistance < -1)
        {
            ydistance++;
        }
    }
    b.tail = false;
    Console.WriteLine("Moving X: " + xdistance);
    Console.WriteLine("Moving Y: " + ydistance);
    b = grid[b.x - xdistance][b.y - ydistance];
    b.tail = true;
    //b.visiteed = true;
    return b;
}