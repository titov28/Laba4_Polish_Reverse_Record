using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class StaticToken
    {
        private static readonly string[][] PriorityArray = new string[][]
        {
            new string[] {"+", "-"},
            new string[] {"*", "/"},
            new string[] {"^"},
            new string[] {"sin"} 
        };

        private static readonly string[] AdditionalTokens = {"(", ")"};

        public static bool ContainsIt(string it)
        {
            bool flag = false;

            for (int i = 0; i < PriorityArray.Length; i++)
            {
                for (int j = 0; j < PriorityArray[i].Length; j++)
                {
                    if(PriorityArray[i][j] == it)
                    {
                        flag = true;
                    }
                }
            }

            for(int i = 0; i < AdditionalTokens.Length; i++)
            {
                if(AdditionalTokens[i] == it)
                {
                    flag = true;
                }
            }

            return flag;
        }

        public static string[] GetOperationArray()
        {
            List<string> lst = new List<string>();

            for (int i = 0; i < PriorityArray.Length; i++)
            {
                for (int j = 0; j < PriorityArray[i].Length; j++)
                {
                    lst.Add(PriorityArray[i][j]);
                }
            }

            return lst.ToArray();
        }

        public static int GetPriority(string symbol)
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
