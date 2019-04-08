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
        public string Result { get; set; }

        public PolishReverseRecord()
        {
            elementStack = null;
            outputQueue = null;
            Result = string.Empty;
        }

        public void SetOutputQueue(Queue q)
        {
            outputQueue = q;
        }

        public string Calculation()
        {
            elementStack = new Stack();

            while (!outputQueue.IsEmpty())
            {
                while (!outputQueue.GetHead().OperationFlag)
                {
                    elementStack.Push(outputQueue.Pop());
                }

                string operationKey = outputQueue.Pop().Element;
                double arg2 = 0;
                double arg1 = 0;
                if (operationKey != "sin")
                {
                    arg2 = Convert.ToDouble(elementStack.Pop().Element);
                    arg1 = Convert.ToDouble(elementStack.Pop().Element);
                }

                switch (operationKey)
                {
                    case "+":
                        elementStack.Push(new Token(Convert.ToString(arg1 + arg2)));
                        break;
                    case "-":
                        elementStack.Push(new Token(Convert.ToString(arg1 - arg2)));
                        break;
                    case "*":
                        elementStack.Push(new Token(Convert.ToString(arg1 * arg2)));
                        break;
                    case "/":
                        if (arg2 != 0)
                        {
                            elementStack.Push(new Token(Convert.ToString(arg1 / arg2)));
                        }
                        else
                        {
                            return "null";
                        }
                        break;
                    case "^":
                        elementStack.Push(new Token(Convert.ToString(Math.Pow(arg1, arg2))));
                        break;
                    case "sin":
                        arg1 = Convert.ToDouble(elementStack.Pop().Element);
                        elementStack.Push(new Token(Convert.ToString(Math.Sin(arg1))));
                        break;
                }

            }

            Result = elementStack.Pop().Element;

            return Result;
        }
    }
}
