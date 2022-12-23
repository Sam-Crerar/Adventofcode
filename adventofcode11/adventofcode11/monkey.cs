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
            throw new NotImplementedException();
        }

        internal int whichmonkeytogive()
        {
            throw new NotImplementedException();
        }
    }
}
