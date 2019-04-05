using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Token
    {
        public double Element { get; set; }
        public int Priority { get; set; }
        private static readonly char[][] PriorityArray = new char[][]
        {
            new char[] {'+', '-'},
            new char[] {'*', '/'},
            new char[] {'^'}
        };

        public bool OperationFlag { get; set;}


        public Token(double value)
        {
            this.Element = value;
            OperationFlag = false;
        }

        public Token(double el, int pr)
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

        public static char[] GetOperationArray()
        {
            List<char> lst = new List<char>;

            for (int i = 0; i < PriorityArray.Length; i++)
            {
                for (int j = 0; j < PriorityArray[i].Length; j++)
                {
                    lst.Add(PriorityArray[i][j]);
                }
            }

            return lst.ToArray();
        }

        public static int GetPriority(char symbol)
        {
            int temp = -1;
            for (int i = 0; i < PriorityArray.Length; i++)
            {
                for (int j = 0; j < PriorityArray[i].Length; j++)
                {
                    if (symbol == PriorityArray[i][j])
                    {
                        temp = i;
                        break;
                    }
                }

                if (temp != -1)
                {
                    break;
                }
            }

            return temp;
        }


    }

}
