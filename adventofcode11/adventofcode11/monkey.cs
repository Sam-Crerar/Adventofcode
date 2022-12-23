using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode11
{
    internal class monkey
    {
        public List<int> items = new List<int>();
        public char operationtype;
        public string operationvalue;
        public int testvalue;
        public int trueto;
        public int falseto;

        public monkey(List<int> Items, char Operationtype, string Operationvalue, int Testvalue, int Trueto, int Falseto)
        {
            items = Items;
            operationtype = Operationtype;
            operationvalue = Operationvalue;
            testvalue = Testvalue;
            trueto = Trueto;
            falseto = Falseto;
        }

        internal void calculateworry()
        {
            if (items.count == 0)
            {
                return null;
            }
            int value = 0;
            if(Operationvalue == "old")
            {
                value = items[0];
            }
            else
            {
                value = int.parse(operationvalue);
            }
            switch (operationtype) {
                case ('+'):
                    int temp = items[0];
                    items.RemoveAt(0);
                    return temp + value;
                case ('-'):
                    int temp = items[0];
                    items.RemoveAt(0);
                    return temp - value;
                case ('*'):
                    int temp = items[0];
                    items.RemoveAt(0);
                    return temp * value;
                case ('/'):
                    int temp = items[0];
                    items.RemoveAt(0);
                    return temp / value;
            }
        }

        internal int whichmonkeytogive(int worry)
        {
            if(worry % testvalue == 0)
            {
                return trueto;
            }
            return falseto;
        }
    }
}
