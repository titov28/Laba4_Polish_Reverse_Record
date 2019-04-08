using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace MainObject
{
    class Program
    {
        static void Main(string[] args)
        {

            //string str = "((2+3)/4) + (5*6)";
            //string str = "sin(2) + 2";
            ParserString prStr = new ParserString();
            PolishReverseRecord prr = new PolishReverseRecord();

            Console.Write("Введите формулу:");

            string str = string.Empty;
            double arg1 = 0;
            double arg2 = 0;
            double step = 0;

            str = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Введите диапазон :\n");

            Console.Write("от ");
            arg1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("до ");
            arg2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();


            Console.Write("Введите шаг: ");
            step = Convert.ToDouble(Console.ReadLine());

            Console.Write("Результат: \n");
            Console.WriteLine();

            for (double i = arg1; i <= arg2; i += step)
            {
                prStr.SetSourceString(str.Replace("x", i.ToString()));
                prStr.Parse();
                prr.SetOutputQueue(prStr.GetPolishReverseString());
                Console.Write("{0, 5} {1:0.000 , 5} \n", i, prr.Calculation());

            }

            Console.ReadLine();
        }
    }
}
