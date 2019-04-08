using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class PolishReverseRecord
    {
        private Queue outputQueue;
        private Stack elementStack;
        public double Result { get; set; }

        public PolishReverseRecord()
        {
            elementStack = null;
            outputQueue = null;
            Result = 0;
        }

        public void SetOutputQueue(Queue q)
        {
            outputQueue = q;
        }

        public double Calculation()
        {
            elementStack = new Stack();

            while (!outputQueue.IsEmpty())
            {
                while (!outputQueue.GetHead().OperationFlag)
                {
                    elementStack.Push(outputQueue.Pop());
                }

                string operationKey = outputQueue.Pop().Operation;
                double arg2 = 0;
                double arg1 = 0;
                if (operationKey != "sin")
                {
                    arg2 = elementStack.Pop().Number;
                    arg1 = elementStack.Pop().Number;
                }

                switch (operationKey)
                {
                    case "+":
                        elementStack.Push(new Token(arg1 + arg2));
                        break;
                    case "-":
                        elementStack.Push(new Token(arg1 - arg2));
                        break;
                    case "*":
                        elementStack.Push(new Token(arg1 * arg2));
                        break;
                    case "/":
                        if (arg2 != 0)
                        {
                            elementStack.Push(new Token(arg1 / arg2));
                        }
                        else
                        {
                            return double.MaxValue;
                        }
                        break;
                    case "^":
                        elementStack.Push(new Token(Math.Pow(arg1, arg2)));
                        break;
                    case "sin":
                        arg1 = elementStack.Pop().Number;
                        elementStack.Push(new Token(Math.Sin(arg1)));
                        break;
                }

            }

            Result = elementStack.Pop().Number;

            return Result;
        }
    }
}
