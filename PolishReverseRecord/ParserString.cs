using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ParserString
    {
        private string sourceString;

        public Queue outputQueue;

        public Queue sourceQueue;

        public Stack operarionStack;

        public ParserString()
        {
            outputQueue = null;// очередь выходной строки
            operarionStack = null; // стек для операций

            sourceQueue = null; // очередь исходной строки
            sourceString = null;// исходная строка
        }

       public void SetSourceString(string str)
        {
            char[] charString = str.ToArray();
            string tempString = string.Empty;

            //избавляемся от пробелов
            for (int i = 0; i < charString.Length; i++)
            {
                if (charString[i] != ' ')
                {
                    tempString += charString[i];
                }
            }

            sourceString = tempString;
        }

        public void Parse()
        {
            sourceQueue = new Queue();

            int[] indexArray = StaticToken.GetIndexNext(sourceString);

            int index = 0;

            string tempString = string.Empty;

            for(int i = 0; i <= indexArray.Length; )
            {
                if (i < indexArray.Length)
                {
                    if (indexArray[i] == index)
                    {
                        // добавляем операцию в очередь
                        tempString = sourceString.Substring(index, indexArray[i + 1] - index);
                        sourceQueue.Push(new Token(tempString, StaticToken.GetPriority(tempString)));
                        index = indexArray[i + 1];
                        i += 2;
                    }
                    else
                    {
                        //добавляем число в очередь
                        tempString = sourceString.Substring(index, indexArray[i] - index);
                        sourceQueue.Push(new Token(tempString.Trim()));
                        index = indexArray[i];
                    }
                }
                else
                {
                    //добавляем остаток строки в очередь
                    tempString = sourceString.Substring(index);
                    if (tempString != string.Empty)
                        sourceQueue.Push(new Token(tempString.Trim()));
                    i += 2;
                }

                
            }

            //sourceQueue.Show();
        }

        public Queue GetPolishReverseString()
        {
            outputQueue = new Queue();
            operarionStack = new Stack();


            if (sourceQueue != null)
            {
                //цикл пока очередь не пуста
                while (!sourceQueue.IsEmpty())
                {
                    // Если число
                    if (!sourceQueue.GetHead().OperationFlag)
                    {
                        // Выталкиваем элемент из входной строки в выходную
                        outputQueue.Push(sourceQueue.Pop());


                    } //иначе если текущий элемент "("
                    else if (sourceQueue.GetHead().Element == "(")
                    {
                        // выталкиваем в стек
                        operarionStack.Push(sourceQueue.Pop());

                    } //иначе если текущий элемент ")"
                    else if(sourceQueue.GetHead().Element == ")")
                    {
                        //уничтожаем закрывающую скобку
                        sourceQueue.Pop();

                        //выталкиваем из стека в выходную строку пока не встретим "("
                        while(operarionStack.GetHead().Element != "(")
                        {
                            outputQueue.Push(operarionStack.Pop());
                        }

                        //уничтожаем открывающую скобку
                        operarionStack.Pop();

                    } // если операция
                    else if (sourceQueue.GetHead().OperationFlag)
                    {
                        //если стек пуст
                        if (operarionStack.IsEmpty())
                        {
                            // помещаем операцию в стек
                            operarionStack.Push(sourceQueue.Pop());
                        } // иначе если приоритет занка в стеке меньше , чем в строке
                        else if(operarionStack.GetHead().Priority < sourceQueue.GetHead().Priority)
                        {
                            //добавляем операцию в стек
                            operarionStack.Push(sourceQueue.Pop());
                        } // иначе 
                        else
                        {
                            // выталкиваем операцию из тека в выходную строоку
                            outputQueue.Push(operarionStack.Pop());
                        }
                    }
                }

                //когда закончилась входная строка, в цикле выталкиваем оставшиеся операции из стека в выходную строку 
                while (!operarionStack.IsEmpty())
                {
                    outputQueue.Push(operarionStack.Pop());
                }

                //outputQueue.Show();

                return outputQueue;
            }
            else
            {
                Console.Write("\n");
                Console.WriteLine("Нет входной строки");
                return default(Queue);
            }
        }


    }
}
