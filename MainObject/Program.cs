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

            //string str = "((-2-3)/-4) + (5*-6) -2";
            //string str = "-10 * sin(1/(6 - 5) ) - 2";
            //string str = "-2 * ((6/-3))";
            //string str = "sin(x) + 10 / -3";
            ParserString prStr = new ParserString();
            PolishReverseRecord prr = new PolishReverseRecord();

            Console.Write("Введите формулу:");

            double arg1 = 0;
            double arg2 = 0;
            double step = 0;

            string str = string.Empty;
            str = Console.ReadLine();

            if (str.IndexOf('x') != -1)
            {

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

                for (double i = arg1; i <= arg2; i = Math.Round(i, 2)+step)
                {
                    prStr.SetSourceString(str.Replace("x", i.ToString()));
                    prStr.Parse();
                    prr.SetOutputQueue(prStr.GetPolishReverseString());
                    
                    double result = prr.Calculation();
                    if (result != double.MaxValue)
                    {
                        Console.Write("{0, 5} {1, 5:0.000} \n", i, result);
                    }
                    else
                    {
                        Console.Write("{0, 5} {1, 5:0.000} \n", i, "null");
                    }
                }

            }
            else
            {
                prStr.SetSourceString(str);
                prStr.Parse();
                prr.SetOutputQueue(prStr.GetPolishReverseString());
                double result = prr.Calculation();
                if (result != double.MaxValue)
                {
                    Console.Write("{0, 5:0.000} \n", result);
                }
                else
                {
                    Console.Write("{0, 5:0.000} \n", "null");
                }
            }
            Console.ReadLine();
        }
    }
}
