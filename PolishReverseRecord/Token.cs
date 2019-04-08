using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Token
    {
        public string Element { get; set; }
        public int Priority { get; set; }


        public bool OperationFlag { get; set; }

        public Token(string value)
        {
            this.Element = value;
            OperationFlag = false;
        }

        public Token(string el, int pr)
        {
            this.Element = el;
            this.Priority = pr;
            OperationFlag = true;
        }

        public Token(Token token)
        {
            if (token.OperationFlag)
            {
                this.Element = token.Element;
                this.Priority = token.Priority;
                this.OperationFlag = true;
            }
            else
            {
                this.Element = token.Element;
                OperationFlag = false;
            }
        }
    


    }

}
