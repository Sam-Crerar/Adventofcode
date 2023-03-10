using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventcode3
{
    internal class Group
    {
        public string elf1 { get; set; }
        public string elf2 { get; set; }
        public string elf3 { get; set; }

        private char comanality;

        public void calculatecom()
        {

            // Convert the strings to character arrays
            char[] charArr1 = elf1.ToCharArray();
            char[] charArr2 = elf2.ToCharArray();
            char[] charArr3 = elf3.ToCharArray();

            // Use LINQ's Intersect method to find the common characters between the three arrays
            var commonChars = charArr1.Intersect(charArr2).Intersect(charArr3);
            string x = string.Join(", ", commonChars);
            comanality = x[0];
            // Print out the common characters
            Console.WriteLine("Common characters: " + string.Join(", ", commonChars));
        }
        public int getComanality()
        {
            switch (comanality)
            {
                case ('a'):
                    return 1;
                case ('b'):
                    return 2;
                case ('c'):
                    return 3;
                case ('d'):
                    return 4;
                case ('e'):
                    return 5;
                case ('f'):
                    return 6;
                case ('g'):
                    return 7;
                case ('h'):
                    return 8;
                case ('i'):
                    return 9;
                case ('j'):
                    return 10;
                case ('k'):
                    return 11;
                case ('l'):
                    return 12;
                case ('m'):
                    return 13;
                case ('n'):
                    return 14;
                case ('o'):
                    return 15;
                case ('p'):
                    return 16;
                case ('q'):
                    return 17;
                case ('r'):
                    return 18;
                case ('s'):
                    return 19;
                case ('t'):
                    return 20;
                case ('u'):
                    return 21;
                case ('v'):
                    return 22;
                case ('w'):
                    return 23;
                case ('x'):
                    return 24;
                case ('y'):
                    return 25;
                case ('z'):
                    return 26;
                case ('A'):
                    return 27;
                case ('B'):
                    return 28;
                case ('C'):
                    return 29;
                case ('D'):
                    return 30;
                case ('E'):
                    return 31;
                case ('F'):
                    return 32;
                case ('G'):
                    return 33;
                case ('H'):
                    return 34;
                case ('I'):
                    return 35;
                case ('J'):
                    return 36;
                case ('K'):
                    return 37;
                case ('L'):
                    return 38;
                case ('M'):
                    return 39;
                case ('N'):
                    return 40;
                case ('O'):
                    return 41;
                case ('P'):
                    return 42;
                case ('Q'):
                    return 43;
                case ('R'):
                    return 44;
                case ('S'):
                    return 45;
                case ('T'):
                    return 46;
                case ('U'):
                    return 47;
                case ('V'):
                    return 48;
                case ('W'):
                    return 49;
                case ('X'):
                    return 50;
                case ('Y'):
                    return 51;
                case ('Z'):
                    return 52;
            }
            return 0;
        }
    }
}
