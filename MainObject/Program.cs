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

            ClassLibrary.Stack<int> myStack = new ClassLibrary.Stack<int>();


            myStack.Push(10);
            myStack.Show();

            myStack.Push(9);
            myStack.Show();

            myStack.Push(8);
            myStack.Show();

            myStack.Push(7);
            myStack.Show();

            myStack.Pop();
            myStack.Show();

            myStack.Pop();
            myStack.Show();

            myStack.Pop();
            myStack.Show();

            myStack.Pop();
            myStack.Show();

            myStack.Pop();
            myStack.Show();


            Console.ReadLine();
        }
    }
}
