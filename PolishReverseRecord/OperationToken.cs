using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class OperationToken : NumberToken<char>
    {
        public int Priority { get; set; }



        public OperationToken(char el, int pr) : base(el)
        {
            this.Priority = pr;
        }

        private static readonly char[][] PriorityArray = new char[][]
        {
            new char[] {'+', '-'},
            new char[] {'*', '/'},
            new char[] {'^'}
        };


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
