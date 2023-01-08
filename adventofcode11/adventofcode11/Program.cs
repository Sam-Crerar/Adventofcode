using adventofcode11;
using System.Numerics;

namespace adventofcode11
{
    public class Program
    {
        public static void Main()
        {
            string textFile = @"file.txt";
            string[] lines = File.ReadAllLines(textFile);
            List<monkey> monkeys = new List<monkey>();
            long rounds = 10000;

            for (long i = 0; i < lines.Length; i += 7)
            {
                List<BigInteger> items = new List<BigInteger>();
                string[] subs = lines[i + 1].Split(' ');
                for (long j = 4; j < subs.Length; j++)
                {string holder = subs[j].Replace(",", "");
                    items.Add(long.Parse(holder));
                }
                subs = lines[i + 2].Split(' ');
                char operationtype = char.Parse(subs[6]);
                string operationvalue = subs[7];
                subs = lines[i + 3].Split(' ');
                long testvalue = long.Parse(subs[5]);
                subs = lines[i + 4].Split(' ');
                long trueto = long.Parse(subs[9]);
                subs = lines[i + 5].Split(' ');
                long falseto = long.Parse(subs[9]);
                monkey x = new monkey(items, operationtype, operationvalue, testvalue, trueto, falseto);
                monkeys.Add(x);
            }
            for (int i = 0; i < rounds; i++)
            {
                for (int j = 0; j < monkeys.Count; j++)
                {
                    long amount = monkeys[j].items.Count;
                    for (long k = 0; k < amount; k++)
                    {
                        BigInteger worry = monkeys[j].calculateworry();
                        //worry /= 3;
                        worry = BigInteger.Parse((Math.Floor(decimal.Parse(worry.ToString()))).ToString());
                        int monk = monkeys[j].whichmonkeytogive(BigInteger.Parse(worry.ToString()));
                        monkeys[monk].items.Add(BigInteger.Parse(worry.ToString()));
                            
                    }

                }
                Console.WriteLine("On Round: " + i);
                for (int j = 0; j < monkeys.Count; j++)
                {
                    Console.Write("Monkey Number: " + j + " List: ");
                    for (int k = 0; k < monkeys[j].items.Count; k++)
                    {
                        Console.Write(monkeys[j].items[k] + ", ");
                    }
                    Console.WriteLine();

                }
                List<long> vs = new List<long>();
                foreach(monkey monkey in monkeys)
                {
                    vs.Add(monkey.inspection);
                }
                long[] sortedNumbers = vs.OrderByDescending(x => x).ToArray();
                /*if (i % 10 == 0)
                {*/
                    Console.WriteLine("Monkey business : " + sortedNumbers[0] * sortedNumbers[1]);
                    Console.WriteLine("Round: " + (i+1).ToString());
                //}
            }
        }
    }
}