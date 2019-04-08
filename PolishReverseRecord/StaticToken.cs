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
                        return flag;
                    }
                }
            }

            for(int i = 0; i < AdditionalTokens.Length; i++)
            {
                if(AdditionalTokens[i] == it)
                {
                    flag = true;
                    return flag;
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

        public static int[] GetIndexNext(string str)
        {

            List<int> minList = new List<int>();
            char[] charString = str.ToArray();

           for(int m = 0; m < charString.Length; m++)
            {
                for (int i = 0; i < PriorityArray.Length; i++)
                {
                    for (int j = 0; j < PriorityArray[i].Length; j++)
                    {
                        int counter = 0;
                        char[] charArray = PriorityArray[i][j].ToArray();
                        for (int k = 0; k < charArray.Length; k++)
                        {
                            if (m + charArray.Length <= charString.Length)
                            {
                                if (charString[m + k] == charArray[k])
                                {
                                    if (minList.Count > 0)
                                    {
                                        //игнорирование унарного минуса если список не пуст
                                        if (m + k != minList.ElementAt(minList.Count - 1) && charArray[k] != '-')
                                        {
                                            counter++;
                                        }
                                    }
                                    else
                                    {
                                        //игнорирование унарного минуса если список пуст
                                        if (charArray[k] != '-')
                                        {
                                            counter++;
                                        }
                                    }
                                }

                            }
                            else
                            {
                                break;
                            }
                        }

                        if(counter == charArray.Length)
                        {
                            minList.Add(m);
                            minList.Add(m + counter);
                        }
                    }
                }
            }

            for (int m = 0; m < charString.Length; m++)
            {
                for (int i = 0; i < AdditionalTokens.Length; i++)
                {
                    int counter = 0;
                    char[] charArray = AdditionalTokens[i].ToArray();
                    for (int k = 0; k < charArray.Length; k++)
                    {
                        if (m + charArray.Length <= charString.Length)
                        {
                            if (charString[m + k] == charArray[k])
                            {
                                counter++;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (counter == charArray.Length)
                    {
                        minList.Add(m);
                        minList.Add(m + counter);
                    }

                }
            }




            minList.Sort();

            return minList.ToArray();

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
