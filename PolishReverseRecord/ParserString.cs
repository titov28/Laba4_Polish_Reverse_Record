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

        public Token outputString;

        public ParserString()
        {
            sourceString = null;
        }

        public void Parse(string str)
        {
            char[] locCharString = str.ToArray();

            for(int i = 0; i < locCharString.Length; i++)
            {
                if(locCharString[i] == )
            }


        }

    }
}
