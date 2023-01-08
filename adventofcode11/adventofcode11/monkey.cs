using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode11
{
    internal class monkey
    {
        public List<BigInteger> items = new List<BigInteger>();
        public char operationtype;
        public string operationvalue;
        public long testvalue;
        public long trueto;
        public long falseto;
        public long inspection;

        public monkey(List<BigInteger> Items, char Operationtype, string Operationvalue, long Testvalue, long Trueto, long Falseto)
        {
            items = Items;
            operationtype = Operationtype;
            operationvalue = Operationvalue;
            testvalue = Testvalue;
            trueto = Trueto;
            falseto = Falseto;
        }

        public BigInteger calculateworry()
        {
            BigInteger value = 0;
            inspection++;
            if (operationvalue == "old")
            {
                value = items[0];
            }
            else
            {
                value = BigInteger.Parse(operationvalue);
            }
            switch (operationtype) {
                case ('+'):
                    BigInteger temp = items[0];
                    items.RemoveAt(0);
                    temp = temp + value;
                    temp %= 96577;
                    return temp;
                case ('-'):
                    temp = items[0];
                    items.RemoveAt(0);
                    temp = temp - value;
                    temp %= 96577;
                    return temp;
                case ('*'):
                    temp = items[0];
                    items.RemoveAt(0);
                    temp = temp * value;
                    temp %= 96577;
                    return temp;
                case ('/'):
                    temp = items[0];
                    items.RemoveAt(0);
                    temp = temp / value;
                    temp %= 96577;
                    return temp;
            }

            return -1;
        }

        internal int whichmonkeytogive(BigInteger worry)
        {
            if(worry % testvalue == 0)
            {
                return int.Parse(trueto.ToString());
            }
            return int.Parse(falseto.ToString());
        }
    }
}
