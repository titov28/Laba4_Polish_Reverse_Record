using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class ParserString
    {
        private string sourceString;
        public string SourceString
        {
            get { return sourceString; }
            set { sourceString = value;}
        }

        public Queue<Token> outputString;

        public Queue<Token> sourceQueue;

        public ParserString()
        {
            outputString = null;
            sourceQueue = null;
            sourceString = null;
        }

        public void Parse(string str)
        {
            sourceQueue = new Queue<Token>();

            char[] locCharString = str.ToArray();

            string tempString = string.Empty;

            for(int i = 0; i < locCharString.Length; i++)
            {
                if (!StaticToken.ContainsIt(locCharString[i].ToString()))
                {
                    tempString += locCharString[i].ToString();



                    if (i != locCharString.Length)
                    {
                        if (StaticToken.ContainsIt(locCharString[i + 1].ToString()))
                        {
                            sourceQueue.Push(new Token(tempString));
                            tempString = string.Empty;
                        }
                    }
                    else
                    {
                        sourceQueue.Push(new Token(tempString));
                        tempString = string.Empty;
                    }

                }
                else
                {
                    sourceQueue.Push(new Token(locCharString[i].ToString(), StaticToken.GetPriority(locCharString[i].ToString())));
                }
                
            }


        }

    }
}
