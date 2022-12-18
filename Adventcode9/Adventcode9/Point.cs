using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventcode9
{
    internal class Point
    {
        public bool head;
        public bool tail;
        public bool visiteed;
        public List<int> ropes;
        public int x;
        public int y;

        public Point(int X, int Y)
        {
            visiteed = false;
            x = X;
            y = Y;
            ropes = new List<int>();
        }
    }
}
