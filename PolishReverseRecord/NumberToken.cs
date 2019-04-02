using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class NumberToken<T>
    {
        public T Element { get; set; }

        public NumberToken(T value)
        {
            this.Element = value;
        }


    }

}
