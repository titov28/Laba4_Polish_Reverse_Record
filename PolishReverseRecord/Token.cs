using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Token
    {
        public string Operation { get; set; }
        public double Number { get; set; }
        public int Priority { get; set; }


        public bool OperationFlag { get; set; }

        public Token(double value)
        {
            this.Number = value;
            OperationFlag = false;
        }

        public Token(string el, int pr)
        {
            this.Operation = el;
            this.Priority = pr;
            OperationFlag = true;
        }

    }

}
